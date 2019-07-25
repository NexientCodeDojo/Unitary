namespace Unitary
{
    public class Information : SimpleUnit<Information, InformationUnits>
    {
        public Information(double magnitude, InformationUnits units)
            : base(magnitude, units, (m, u) => new Information(m, u))
        { }

        public Information Bits => ConvertTo(InformationUnits.Bits);
        public Information Bytes => ConvertTo(InformationUnits.Bytes);
        public Information Kilobytes => ConvertTo(InformationUnits.Kilobytes);
        public Information Megabytes => ConvertTo(InformationUnits.Megabytes);
        public Information Gigabytes => ConvertTo(InformationUnits.Gigabytes);
        public Information Terabytes => ConvertTo(InformationUnits.Terabytes);
        public Information Petabyte => ConvertTo(InformationUnits.Petabyte);
        public Information Exabyte => ConvertTo(InformationUnits.Exabytes);
        public Information Kibibytes => ConvertTo(InformationUnits.Kibibytes);
        public Information Mebibytes => ConvertTo(InformationUnits.Mebibytes);
        public Information Gibibytes => ConvertTo(InformationUnits.Gibibytes);
        public Information Tebibytes => ConvertTo(InformationUnits.Tebibytes);
        public Information Pebibyte => ConvertTo(InformationUnits.Pebibyte);
        public Information Exbibyte => ConvertTo(InformationUnits.Exbibytes);
    }
}
