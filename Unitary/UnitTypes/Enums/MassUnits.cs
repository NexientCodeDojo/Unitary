namespace Unitary
{
    public enum MassUnits
    {
        [UnitSymbol("kg", 1.0)]
        Kilograms = 0,

        [UnitSymbol("g", 1.0 / 1_000)]
        Grams = 1,

        [UnitSymbol("mg", 1.0 / 1_000_000)]
        Milligrams = 2,

        [UnitSymbol("ug", 1.0 / 1_000_000_000)]
        Micrograms = 3,

        [UnitSymbol("ng", 1.0 / 1_000_000_000_000)]
        Nanograms = 4,

        [UnitSymbol("lb", 0.453592)]
        Pounds = 5,
    }
}
