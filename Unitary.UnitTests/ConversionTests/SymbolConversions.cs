using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Unitary.UnitTests.ConversionTests
{
    [TestFixture]
    public class SymbolConversions
    {
        private readonly List<Type> _unitTypeEnums;

        private readonly List<object> _testedSymbolsFromUnits;
        private readonly List<object> _testedUnitsFromSymbols;

        public SymbolConversions()
        {
            _unitTypeEnums = Assembly.GetAssembly(typeof(Units))
                .GetTypes()
                .Select(x => x.GetInterface("IUnit`2")?.GenericTypeArguments[1].UnderlyingSystemType)
                .Where(x => x != null)
                .ToList();

            _testedSymbolsFromUnits = new List<object>(_unitTypeEnums.Count);
            _testedUnitsFromSymbols = new List<object>(_unitTypeEnums.Count);
        }

        [Order(1)]
        [TestCase("s", TimeUnits.Seconds)]
        [TestCase("ms", TimeUnits.Milliseconds)]
        [TestCase("us", TimeUnits.Microseconds)]
        [TestCase("ns", TimeUnits.Nanoseconds)]
        [TestCase("m", TimeUnits.Minutes)]
        [TestCase("h", TimeUnits.Hours)]
        [TestCase("d", TimeUnits.Days)]

        [TestCase("m", LengthUnits.Meters)]
        [TestCase("dm", LengthUnits.Decimeters)]
        [TestCase("cm", LengthUnits.Centimeters)]
        [TestCase("mm", LengthUnits.Millimeters)]
        [TestCase("um", LengthUnits.Micrometers)]
        [TestCase("nm", LengthUnits.Nanometers)]
        [TestCase("km", LengthUnits.Kilometers)]
        [TestCase("Mm", LengthUnits.Megameters)]
        [TestCase("Gm", LengthUnits.Gigameters)]
        [TestCase("ft", LengthUnits.Feet)]
        [TestCase("yd", LengthUnits.Yards)]
        [TestCase("mi", LengthUnits.Miles)]
        [TestCase("ly", LengthUnits.Lightyears)]
        [TestCase("pc", LengthUnits.Parsecs)]
        [TestCase("AU", LengthUnits.AstronomicalUnits)]

        [TestCase("kg", MassUnits.Kilograms)]
        [TestCase("g", MassUnits.Grams)]
        [TestCase("mg", MassUnits.Milligrams)]
        [TestCase("ug", MassUnits.Micrograms)]
        [TestCase("ng", MassUnits.Nanograms)]
        [TestCase("lb", MassUnits.Pounds)]

        [TestCase("cd", LuminosityUnits.Candela)]
        [TestCase("cp", LuminosityUnits.Candlepower)]
        [TestCase("HK", LuminosityUnits.Hefnerkerze)]

        [TestCase("K", TemperatureUnits.Kelvin)]
        [TestCase("C", TemperatureUnits.Celsius)]
        [TestCase("F", TemperatureUnits.Fahrenheit)]
        [TestCase("R", TemperatureUnits.Rankine)]

        [TestCase("bit", InformationUnits.Bits)]
        [TestCase("B", InformationUnits.Bytes)]
        [TestCase("kB", InformationUnits.Kilobytes)]
        [TestCase("MB", InformationUnits.Megabytes)]
        [TestCase("GB", InformationUnits.Gigabytes)]
        [TestCase("TB", InformationUnits.Terabytes)]
        [TestCase("PB", InformationUnits.Petabyte)]
        [TestCase("EB", InformationUnits.Exabytes)]
        [TestCase("KiB", InformationUnits.Kibibytes)]
        [TestCase("MiB", InformationUnits.Mebibytes)]
        [TestCase("GiB", InformationUnits.Gibibytes)]
        [TestCase("TiB", InformationUnits.Tebibytes)]
        [TestCase("PiB", InformationUnits.Pebibyte)]
        [TestCase("EiB", InformationUnits.Exbibytes)]

        [TestCase("A", CurrentUnits.Amperes)]
        [TestCase("mA", CurrentUnits.Milliamps)]

        [TestCase("mol", AmountOfSubstanceUnits.Moles)]
        [TestCase("lb-mol", AmountOfSubstanceUnits.PoundMoles)]
        public void CanConvert_Between_SymbolAndEnum(string symbol, object expectedUnits)
        {
            var typeOfExpectedUnits = expectedUnits.GetType();

            AssertSymbolFromEnumIsCorrect(symbol, expectedUnits, typeOfExpectedUnits);
            AssertEnumFromSymbolIsCorrect(symbol, expectedUnits, typeOfExpectedUnits);
        }

        private void AssertSymbolFromEnumIsCorrect(string symbol, object expectedUnits, Type typeOfExpectedUnits)
        {
            _testedSymbolsFromUnits.Add(expectedUnits);
            var actualSymbol = UnitDataCache.GetSymbol(typeOfExpectedUnits, expectedUnits);
            actualSymbol.Should().Be(symbol);

            actualSymbol = UnitDataCache.GetSymbol((Enum)expectedUnits);
            actualSymbol.Should().Be(symbol);
        }

        private void AssertEnumFromSymbolIsCorrect(string symbol, object expectedUnits, Type typeOfExpectedUnits)
        {
            _testedUnitsFromSymbols.Add(expectedUnits);
            var units = UnitDataCache.GetUnits(typeOfExpectedUnits, symbol);
            units.Should().Be(expectedUnits);
        }

        [Test, Order(2)]
        public void Tested_All_Units()
        {
            var allMembers = _unitTypeEnums
                .SelectMany(x => x.GetFields().Where(f => f.CustomAttributes.Any()).Select(f => f.GetValue(null)));

            foreach (var member in allMembers)
            {
                _testedSymbolsFromUnits.FirstOrDefault(x => x.Equals(member)).Should().NotBeNull($"{member} must be tested");
                _testedUnitsFromSymbols.FirstOrDefault(x => x.Equals(member)).Should().NotBeNull($"{member} must be tested");
            }
        }
    }
}
