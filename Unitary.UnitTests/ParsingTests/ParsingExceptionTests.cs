using NUnit.Framework;
using System;

namespace Unitary.UnitTests.ParsingTests
{
    [TestFixture]
    public class ParsingExceptionTests
    {
        [TestCase(typeof(Time), "s1.23")]
        [TestCase(typeof(Length), "6'7\"")]
        [TestCase(typeof(Mass), "1.2.3lb")]
        [TestCase(typeof(Information), "4.55")]
        public void GivenBadInput_ParsingUnits_ThrowsException(Type type, string badInput)
        {
            Assert.Throws<Units.InvalidUnitFormat>(() => Units.Parse(type, badInput));
        }

        [TestCase(typeof(Time), "5 parsecs")]
        [TestCase(typeof(Length), "23.6 longness")]
        [TestCase(typeof(Mass), "1.23 MU")]
        [TestCase(typeof(Information), "4.55OB")]
        public void GivenNonExistentUnit_ParsingUnits_ThrowsException(Type type, string badInput)
        {
            Assert.Throws<UnitDataCache.SymbolNotFound>(() => Units.Parse(type, badInput));
        }

        [TestCase(typeof(string))]
        [TestCase(typeof(Guid))]
        [TestCase(typeof(IUnit))]
        [TestCase(typeof(Units))]
        public void GivenTypeThatIsNotAUnit_ParsingUnits_ThrowsException(Type type)
        {
            Assert.Throws<Units.UnknownUnitType>(() => Units.Parse(type, "5s"));
        }
    }
}
