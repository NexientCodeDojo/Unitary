using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unitary.UnitTests")]

namespace Unitary
{
    internal static class UnitDataCache
    {
        private static readonly Dictionary<Type, Dictionary<int, UnitSymbolAttribute>> _unitSymbolCache
            = new Dictionary<Type, Dictionary<int, UnitSymbolAttribute>>();

        private static readonly Dictionary<Type, Dictionary<string, object>> _symbolUnitCache
            = new Dictionary<Type, Dictionary<string, object>>();

        private static readonly Dictionary<Type, Type> _unitTypeCache
            = new Dictionary<Type, Type>();

        public static UnitSymbolAttribute[] GetSymbolAttributes<T>() where T : Enum => GetSymbolAttributes(typeof(T));

        public static UnitSymbolAttribute[] GetSymbolAttributes(Type type)
        {
            CacheAttributes(type);
            return _unitSymbolCache[type].Values.ToArray();
        }

        public static string GetSymbol(object unitEnum) => GetFromCache(unitEnum.GetType(), unitEnum).Symbol;
        public static string GetSymbol(Type type, object unitEnum) => GetFromCache(type, unitEnum).Symbol;
        public static double GetScaleFactor<T>(T unitEnum) where T : Enum => GetScaleFactor(typeof(T), unitEnum);
        public static double GetScaleFactor(Type type, object unitEnum) => GetFromCache(type, unitEnum).ScaleFactor;
        public static double GetOffset<T>(T unitEnum) where T : Enum => GetOffset(typeof(T), unitEnum);
        public static double GetOffset(Type type, object unitEnum) => GetFromCache(type, unitEnum).Offset;
        public static T GetUnits<T>(string symbol) where T : Enum => (T)GetUnits(typeof(T), symbol);

        public static object GetUnits(Type type, string symbol)
        {
            CacheEnumValues(type);

            if (!_symbolUnitCache[type].ContainsKey(symbol))
                throw new SymbolNotFound(type, symbol);

            return _symbolUnitCache[type][symbol];
        }

        public static Type GetUnitTypeFromUnits(Type unitEnumType)
        {
            CacheUnitTypes();

            if (!_unitTypeCache.ContainsKey(unitEnumType))
                return null;

            return _unitTypeCache[unitEnumType];
        }

        private static UnitSymbolAttribute GetFromCache(Type type, object unitEnum)
        {
            CacheAttributes(type);
            return _unitSymbolCache[type][(int)unitEnum];
        }

        private static void CacheAttributes(Type type)
        {
            if (!_unitSymbolCache.ContainsKey(type))
            {
                var symbols = type.GetFields()
                    .Where(x => x.GetCustomAttribute<UnitSymbolAttribute>() != null)
                    .ToDictionary(
                        x => (int)x.GetValue(null),
                        x => x.GetCustomAttribute<UnitSymbolAttribute>().ForUnit(x.GetValue(null))
                    );

                _unitSymbolCache.Add(type, symbols);
            }
        }

        private static void CacheEnumValues(Type type)
        {
            if (!_symbolUnitCache.ContainsKey(type))
            {
                var units = type.GetFields()
                    .Where(x => x.GetCustomAttribute<UnitSymbolAttribute>() != null)
                    .ToDictionary(
                        x => x.GetCustomAttribute<UnitSymbolAttribute>().Symbol,
                        x => x.GetValue(null)
                    );

                _symbolUnitCache.Add(type, units);
            }
        }

        private static void CacheUnitTypes()
        {
            if (_unitTypeCache.Count != 0)
                return;

            Assembly.GetAssembly(typeof(UnitDataCache))
                .GetTypes()
                .Where(x => x.GetInterface("IUnit`2") != null)
                .Select(x => new { Key = x.GetInterface("IUnit`2").GenericTypeArguments[1], Value = x })
                .ToList()
                .ForEach(x => _unitTypeCache.Add(x.Key, x.Value));
        }

        public class SymbolNotFound : Exception
        {
            public SymbolNotFound(Type type, string symbol)
                : base($"Symbol {symbol} not found for type {type.Name}")
            { }
        }
    }
}
