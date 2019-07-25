namespace Unitary
{
    public enum LengthUnits
    {
        [UnitSymbol("m", 1.0)]
        Meters = 0,

        [UnitSymbol("dm", 1.0 / 10)]
        Decimeters = 1,

        [UnitSymbol("cm", 1.0 / 100)]
        Centimeters = 2,

        [UnitSymbol("mm", 1.0 / 1_000)]
        Millimeters = 3,

        [UnitSymbol("um", 1.0 / 1_000_000)]
        Micrometers = 4,

        [UnitSymbol("nm", 1.0 / 1_000_000_000)]
        Nanometers = 5,

        [UnitSymbol("km", 1_000)]
        Kilometers = 6,

        [UnitSymbol("Mm", 1_000_000)]
        Megameters = 7,

        [UnitSymbol("Gm", 1_000_000_000)]
        Gigameters = 8,

        [UnitSymbol("ft", 1.0 / 3.28084)]
        Feet = 9,

        [UnitSymbol("yd", 1.0 / 1.09361)]
        Yards = 10,

        [UnitSymbol("mi", 1.0 / 0.000621371)]
        Miles = 11,

        [UnitSymbol("ly", 1.0 / 1.057e-16)]
        Lightyears = 12,

        [UnitSymbol("pc", 1.0 / 3.24078e-17)]
        Parsecs = 13,

        [UnitSymbol("AU", 1.0 / 6.68459e-12)]
        AstronomicalUnits = 14,
    }
}
