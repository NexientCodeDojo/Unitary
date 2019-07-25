using FluentAssertions;
using NUnit.Framework;
using System;

namespace Unitary.UnitTests.ConversionTests
{
    [TestFixture]
    public class MagnitudeConversions
    {
        [TestCase("60s", 1, TimeUnits.Minutes)]
        [TestCase("3600s", 60, TimeUnits.Minutes)]
        [TestCase("3600s", 1, TimeUnits.Hours)]
        [TestCase("24h", 1, TimeUnits.Days)]
        [TestCase("5s", 5000, TimeUnits.Milliseconds)]
        [TestCase("0s", 0, TimeUnits.Days)]
        public void CanConvert_Time_Units(string timeString, double expectedMagnitude, TimeUnits toUnits)
        {
            var time = Units.Parse<Time>(timeString);
            var converted = time.ConvertTo(toUnits);
            converted.Magnitude.Should().BeApproximately(expectedMagnitude, 1e-10);
        }

        [TestCase("1K", 1, TemperatureUnits.Kelvin)]
        [TestCase("0K", -273.15, TemperatureUnits.Celsius)]
        [TestCase("0C", 32.0, TemperatureUnits.Fahrenheit)]
        [TestCase("100C", 212.0, TemperatureUnits.Fahrenheit)]
        [TestCase("0K", -459.67, TemperatureUnits.Fahrenheit)]
        public void CanConvert_Temperature_Units(string temperatureString, double expectedMagnitude, TemperatureUnits toUnits)
        {
            var temperature = Units.Parse<Temperature>(temperatureString);
            var converted = temperature.ConvertTo(toUnits);
            converted.Magnitude.Should().BeApproximately(expectedMagnitude, 1e-10);
        }

        [TestCase(1, AmountOfSubstanceUnits.PoundMoles, 453.59237, AmountOfSubstanceUnits.Moles)]
        [TestCase(1, CurrentUnits.Amperes, 1000, CurrentUnits.Milliamps)]
        public void CanConvert_Various_SpotCheck(double initialMagnitude, Enum initialUnits, double newMagnitude, Enum newUnits)
        {
            var unitType = UnitDataCache.GetUnitTypeFromUnits(initialUnits.GetType());
            var units = Units.Parse(unitType, $"{initialMagnitude}{UnitDataCache.GetSymbol(initialUnits)}");
            var converted = units.ConvertTo(newUnits);
            converted.Magnitude.Should().BeApproximately(newMagnitude, double.Epsilon);
            converted.Units.Should().BeOfType(newUnits.GetType());
        }

        [Test]
        public void CanConvert_Units_ToDouble()
        {
            ((double)Units.Parse<Time>("5s")).Should().Be(5);
            ((double)Units.Parse<Information>("1024KiB")).Should().Be(1024);

        }
    }
}
