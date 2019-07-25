namespace Unitary
{
    public class Time : SimpleUnit<Time, TimeUnits>
    {
        public Time(double magnitude, TimeUnits units)
            : base(magnitude, units, (m, u) => new Time(m, u))
        { }

        public Time Seconds => ConvertTo(TimeUnits.Seconds);
        public Time Milliseconds => ConvertTo(TimeUnits.Milliseconds);
        public Time Microseconds => ConvertTo(TimeUnits.Microseconds);
        public Time Nanoseconds => ConvertTo(TimeUnits.Nanoseconds);
        public Time Minutes => ConvertTo(TimeUnits.Minutes);
        public Time Hours => ConvertTo(TimeUnits.Hours);
        public Time Days => ConvertTo(TimeUnits.Days);
    }
}
