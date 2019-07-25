namespace Unitary
{
    public class Luminosity : SimpleUnit<Luminosity, LuminosityUnits>
    {
        public Luminosity(double magnitude, LuminosityUnits units)
            : base(magnitude, units, (m, u) => new Luminosity(m, u))
        { }

        public Luminosity Candela => ConvertTo(LuminosityUnits.Candela);
        public Luminosity Candlepower => ConvertTo(LuminosityUnits.Candlepower);
        public Luminosity Hefnerkerze => ConvertTo(LuminosityUnits.Hefnerkerze);
    }
}
