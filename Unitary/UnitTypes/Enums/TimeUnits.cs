namespace Unitary
{
    public enum TimeUnits
    {
        [UnitSymbol("s", 1.0)]
        Seconds = 0,

        [UnitSymbol("ms", 1.0 / 1_000)]
        Milliseconds = 1,

        [UnitSymbol("us", 1.0 / 1_000_000)]
        Microseconds = 2,

        [UnitSymbol("ns", 1.0 / 1_000_000_000)]
        Nanoseconds = 3,

        [UnitSymbol("m", 60)]
        Minutes = 4,

        [UnitSymbol("h", 60 * 60)]
        Hours = 5,

        [UnitSymbol("d", 60 * 60 * 24)]
        Days = 6,
    }
}
