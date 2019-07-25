namespace Unitary
{
    public class Mass : SimpleUnit<Mass, MassUnits>
    {
        public Mass(double magnitude, MassUnits units)
            : base(magnitude, units, (m, u) => new Mass(m, u))
        { }

        public Mass Kilograms => ConvertTo(MassUnits.Kilograms);
        public Mass Grams => ConvertTo(MassUnits.Grams);
        public Mass Milligrams => ConvertTo(MassUnits.Milligrams);
        public Mass Micrograms => ConvertTo(MassUnits.Micrograms);
        public Mass Nanograms => ConvertTo(MassUnits.Nanograms);
        public Mass Pounds => ConvertTo(MassUnits.Pounds);
    }
}
