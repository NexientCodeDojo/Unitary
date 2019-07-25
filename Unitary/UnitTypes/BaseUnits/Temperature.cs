namespace Unitary
{
    public class Temperature : SimpleUnit<Temperature, TemperatureUnits>
    {
        public Temperature(double magnitude, TemperatureUnits units)
            : base(magnitude, units, (m, u) => new Temperature(m, u))
        { }

        public Temperature Kelvin => ConvertTo(TemperatureUnits.Kelvin);
        public Temperature Celsius => ConvertTo(TemperatureUnits.Celsius);
        public Temperature Fahrenheit => ConvertTo(TemperatureUnits.Fahrenheit);
        public Temperature Rankine => ConvertTo(TemperatureUnits.Rankine);
    }
}
