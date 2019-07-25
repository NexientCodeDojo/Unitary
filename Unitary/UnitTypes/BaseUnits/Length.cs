namespace Unitary
{
    public class Length : SimpleUnit<Length, LengthUnits>
    {
        public Length(double magnitude, LengthUnits units)
            : base(magnitude, units, (m, u) => new Length(m, u))
        { }

        public static Velocity operator /(Length left, Time right)
        {
            return new Velocity(left.Magnitude / right.Magnitude, left.Units, right.Units);
        }

        public Length Meters => ConvertTo(LengthUnits.Meters);
        public Length Decimeters => ConvertTo(LengthUnits.Decimeters);
        public Length Centimeters => ConvertTo(LengthUnits.Centimeters);
        public Length Millimeters => ConvertTo(LengthUnits.Millimeters);
        public Length Micrometers => ConvertTo(LengthUnits.Micrometers);
        public Length Nanometers => ConvertTo(LengthUnits.Nanometers);
        public Length Kilometers => ConvertTo(LengthUnits.Kilometers);
        public Length Megameters => ConvertTo(LengthUnits.Megameters);
        public Length Gigameters => ConvertTo(LengthUnits.Gigameters);
        public Length Feet => ConvertTo(LengthUnits.Feet);
        public Length Yards => ConvertTo(LengthUnits.Yards);
        public Length Miles => ConvertTo(LengthUnits.Miles);
        public Length Lightyears => ConvertTo(LengthUnits.Lightyears);
        public Length Parsecs => ConvertTo(LengthUnits.Parsecs);
        public Length AstronomicalUnits => ConvertTo(LengthUnits.AstronomicalUnits);
    }
}
