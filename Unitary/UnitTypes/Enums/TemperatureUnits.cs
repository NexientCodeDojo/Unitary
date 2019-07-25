namespace Unitary
{
    public enum TemperatureUnits
    {
        [UnitSymbol("C", 1.0)]
        Celsius = 0,

        [UnitSymbol("K", 1.0, Offset = 273.15)]
        Kelvin = 1,

        [UnitSymbol("F", 5.0 / 9.0, Offset = 32.0)]
        Fahrenheit = 2,

        [UnitSymbol("R", 5.0 / 9.0)]
        Rankine = 3,
    }
}
