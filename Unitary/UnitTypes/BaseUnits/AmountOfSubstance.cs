namespace Unitary
{
    public class AmountOfSubstance : SimpleUnit<AmountOfSubstance, AmountOfSubstanceUnits>
    {
        public AmountOfSubstance(double magnitude, AmountOfSubstanceUnits units)
            : base(magnitude, units, (m, u) => new AmountOfSubstance(m, u))
        { }

        public AmountOfSubstance PoundMoles => ConvertTo(AmountOfSubstanceUnits.PoundMoles);
    }
}
