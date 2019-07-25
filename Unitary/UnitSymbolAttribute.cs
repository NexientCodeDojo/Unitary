using System;

namespace Unitary
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class UnitSymbolAttribute : Attribute
    {
        public string Symbol { get; }
        public double ScaleFactor { get; }
        public double Offset { get; set; }

        private object _unit;

        public UnitSymbolAttribute(string symbol, double scaleFactor)
        {
            Symbol = symbol;
            ScaleFactor = scaleFactor;
        }

        public UnitSymbolAttribute ForUnit(object unit)
        {
            _unit = unit;
            return this;
        }

        public TUnit GetUnitType<TUnit>()
        {
            return (TUnit)_unit;
        }
    }
}
