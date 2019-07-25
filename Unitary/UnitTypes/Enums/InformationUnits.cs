namespace Unitary
{
    public enum InformationUnits
    {
        [UnitSymbol("bit", 1.0)]
        Bits = 0,

        [UnitSymbol("B", 8.0)]
        Bytes = 1,

        [UnitSymbol("kB", 8.0 * 1_000)]
        Kilobytes = 2,

        [UnitSymbol("MB", 8.0 * 1_000_000)]
        Megabytes = 3,

        [UnitSymbol("GB", 8.0 * 1_000_000_000)]
        Gigabytes = 4,

        [UnitSymbol("TB", 8.0 * 1_000_000_000_000)]
        Terabytes = 5,

        [UnitSymbol("PB", 8.0 * 1_000_000_000_000_000)]
        Petabyte = 6,

        [UnitSymbol("EB", 8.0 * 1_000_000_000_000_000_000)]
        Exabytes = 7,

        [UnitSymbol("KiB", 8.0 * (1 << 10))]
        Kibibytes = 8,

        [UnitSymbol("MiB", 8.0 * (1 << 20))]
        Mebibytes = 9,

        [UnitSymbol("GiB", 8.0 * (1 << 30))]
        Gibibytes = 10,

        [UnitSymbol("TiB", 8.0 * (1 << 40))]
        Tebibytes = 11,

        [UnitSymbol("PiB", 8.0 * (1 << 50))]
        Pebibyte = 12,

        [UnitSymbol("EiB", 8.0 * (1 << 60))]
        Exbibytes = 13,
    }
}
