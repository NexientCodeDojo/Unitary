using FluentAssertions;
using NUnit.Framework;
using System;

namespace Unitary.UnitTests.ParsingTests
{
    [TestFixture(TypeArgs = new[] { typeof(Time), typeof(TimeUnits) })]
    [TestFixture(TypeArgs = new[] { typeof(Length), typeof(LengthUnits) })]
    [TestFixture(TypeArgs = new[] { typeof(Mass), typeof(MassUnits) })]
    [TestFixture(TypeArgs = new[] { typeof(Luminosity), typeof(LuminosityUnits) })]
    [TestFixture(TypeArgs = new[] { typeof(Temperature), typeof(TemperatureUnits) })]
    [TestFixture(TypeArgs = new[] { typeof(Information), typeof(InformationUnits) })]
    [TestFixture(TypeArgs = new[] { typeof(Current), typeof(CurrentUnits) })]
    [TestFixture(TypeArgs = new[] { typeof(AmountOfSubstance), typeof(AmountOfSubstanceUnits) })]
    public class BaseUnitParsing<T, TUnit> where T : IUnit<T, TUnit> where TUnit : Enum
    {
        [Test]
        public void CanParse_All_Units()
        {
            foreach (var unit in UnitDataCache.GetSymbolAttributes<TUnit>())
            {
                var unitString = $"12.34{unit.Symbol}";

                var parsed = Units.Parse<T>(unitString);
                AssertMagnitudeAndUnits(parsed, 12.34, unit.GetUnitType<TUnit>());
            }
        }

        private static void AssertMagnitudeAndUnits(T units, double magnitude, object expectedUnits)
        {
            units.Magnitude.Should().BeApproximately(magnitude, 1e-10, $"magnitude for {typeof(T).Name} in {expectedUnits} should be correct");
            units.Units.Should().Be(expectedUnits, $"unit symbols for {expectedUnits} should be correctly parsed");
            ((IUnit)units).Units.Should().BeOfType(expectedUnits.GetType());
        }
    }
}
