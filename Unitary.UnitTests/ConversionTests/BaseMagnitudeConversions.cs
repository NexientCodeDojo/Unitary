using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Unitary.UnitTests.ConversionTests
{
    [TestFixture("1s", TypeArgs = new[] { typeof(Time), typeof(TimeUnits) })]
    [TestFixture("1m", TypeArgs = new[] { typeof(Length), typeof(LengthUnits) })]
    [TestFixture("1kg", TypeArgs = new[] { typeof(Mass), typeof(MassUnits) })]
    [TestFixture("1cd", TypeArgs = new[] { typeof(Luminosity), typeof(LuminosityUnits) })]
    [TestFixture("1C", TypeArgs = new[] { typeof(Temperature), typeof(TemperatureUnits) })]
    [TestFixture("1bit", TypeArgs = new[] { typeof(Information), typeof(InformationUnits) })]
    [TestFixture("1A", TypeArgs = new[] { typeof(Current), typeof(CurrentUnits) })]
    [TestFixture("1 mol", TypeArgs = new[] { typeof(AmountOfSubstance), typeof(AmountOfSubstanceUnits) })]
    public class BaseMagnitudeConversions<T, TUnit> where T : IUnit<T, TUnit> where TUnit : Enum
    {
        private T BaseUnit { get; }

        public BaseMagnitudeConversions(string baseUnitString)
        {
            BaseUnit = Units.Parse<T>(baseUnitString);
        }

        [Test]
        public void CanConvert_BaseUnit_ToAllOtherUnits()
        {
            var allOtherUnits = UnitDataCache.GetSymbolAttributes<TUnit>()
                    .Where(x => (int)(object)x.GetUnitType<TUnit>() != (int)(object)BaseUnit.Units);

            allOtherUnits.Should().NotBeEmpty();

            foreach (var unit in allOtherUnits)
            {
                var converted = BaseUnit.ConvertTo(unit.GetUnitType<TUnit>());
                converted.Magnitude.Should().BeApproximately(1.0 / unit.ScaleFactor + unit.Offset, 1e-10);

                converted = BaseUnit.ConvertTo(unit.Symbol);
                converted.Magnitude.Should().BeApproximately(1.0 / unit.ScaleFactor + unit.Offset, 1e-10);
            }
        }
    }
}
