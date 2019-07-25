using FluentAssertions;
using NUnit.Framework;
using System;

namespace Unitary.UnitTests.ParsingTests
{
    [TestFixture]
    public class CompoundUnitParsing
    {
        [TestCase("42.55m/s", typeof(Velocity), 42.55)]
        public void CanParse_CompoundUnits(string measurement, Type unitType, double expectedMagnitude)
        {
            var units = Units.Parse(unitType, measurement);

            units.Magnitude.Should().BeApproximately(42.55, double.Epsilon);
        }
    }
}
