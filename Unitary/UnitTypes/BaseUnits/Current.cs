namespace Unitary
{
    public class Current : SimpleUnit<Current, CurrentUnits>
    {
        public Current(double magnitude, CurrentUnits units)
            : base(magnitude, units, (m, u) => new Current(m, u))
        { }

        public Current Ampere => ConvertTo(CurrentUnits.Amperes);
        public Current Milliamp => ConvertTo(CurrentUnits.Milliamps);
    }
}
