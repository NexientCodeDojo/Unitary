using System;

namespace Unitary
{
    public abstract class SimpleUnit<T, TUnits> : IUnit<T, TUnits> where T : IUnit where TUnits : Enum
    {
        public virtual double Magnitude { get; }
        object IUnit.Units => Units;
        public virtual TUnits Units { get; }
        public virtual string Symbol => UnitDataCache.GetSymbol(Units);

        private readonly Func<double, TUnits, T> _constructorFunc;

        // The _constructorFunc is pretty janky overall, doesn't feel right.
        // Could use Activator, but that's slow
        protected SimpleUnit(double magnitude, TUnits units, Func<double, TUnits, T> constructorFunc)
        {
            Magnitude = magnitude;
            Units = units;
            _constructorFunc = constructorFunc;
        }

        public static explicit operator double(SimpleUnit<T, TUnits> unit) => unit.Magnitude;

        public override string ToString() => $"{Magnitude:#.###}{Symbol}";
        public virtual double GetScaleFactor(TUnits unit) => UnitDataCache.GetScaleFactor(unit);
        IUnit IUnit.ConvertTo(Enum unit) => ConvertTo((TUnits)unit);
        IUnit IUnit.ConvertTo(string unit) => ConvertTo(unit);
        public virtual T ConvertTo(string unit) => ConvertTo(UnitDataCache.GetUnits<TUnits>(unit));

        public virtual T ConvertTo(TUnits unit)
        {
            var baseMagnitude = Magnitude * GetScaleFactor(Units) - UnitDataCache.GetOffset(Units);
            var scale = GetScaleFactor(unit);
            var offset = UnitDataCache.GetOffset(unit);
            return _constructorFunc(baseMagnitude / scale + offset, unit);
        }
    }
}
