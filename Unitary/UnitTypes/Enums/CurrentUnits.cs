namespace Unitary
{
    public enum CurrentUnits
    {
        [UnitSymbol("A", 1.0)]
        Amperes = 0,

        [UnitSymbol("mA", 1.0 / 1_000)]
        Milliamps = 1,
    }
}
