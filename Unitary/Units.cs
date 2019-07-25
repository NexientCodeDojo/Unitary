using System;
using System.Text.RegularExpressions;

namespace Unitary
{
    public static class Units
    {
        public static T Parse<T>(string measurement) where T : IUnit
        {
            return (T)Parse(typeof(T), measurement);
        }

        public static IUnit Parse(Type unitType, string measurement)
        {
            const string matchPattern = @"^([+-]?\s*(?:\d+\.?\d*|\d*\.\d+))(\D+)$";
            var match = Regex.Match(measurement.Trim(), matchPattern);

            if (!match.Success)
            {
                throw new InvalidUnitFormat(measurement);
            }

            var magnitude = double.Parse(match.Groups[1].Value.Replace(" ", ""));
            var symbol = match.Groups[2].Value.Trim();

            switch (unitType.Name)
            {
                case nameof(Length):
                    return new Length(magnitude, UnitDataCache.GetUnits<LengthUnits>(symbol));
                case nameof(Time):
                    return new Time(magnitude, UnitDataCache.GetUnits<TimeUnits>(symbol));
                case nameof(Mass):
                    return new Mass(magnitude, UnitDataCache.GetUnits<MassUnits>(symbol));
                case nameof(Luminosity):
                    return new Luminosity(magnitude, UnitDataCache.GetUnits<LuminosityUnits>(symbol));
                case nameof(Temperature):
                    return new Temperature(magnitude, UnitDataCache.GetUnits<TemperatureUnits>(symbol));
                case nameof(Information):
                    return new Information(magnitude, UnitDataCache.GetUnits<InformationUnits>(symbol));
                case nameof(Current):
                    return new Current(magnitude, UnitDataCache.GetUnits<CurrentUnits>(symbol));
                case nameof(AmountOfSubstance):
                    return new AmountOfSubstance(magnitude, UnitDataCache.GetUnits<AmountOfSubstanceUnits>(symbol));
                case nameof(Velocity):
                    var (lengthUnits, timeUnits) = Velocity.GetUnits(symbol);
                    return new Velocity(magnitude, lengthUnits, timeUnits);
                default:
                    throw new UnknownUnitType(unitType);
            }
        }

        public static string GetSymbol<T>(T unitType) where T : Enum
        {
            return UnitDataCache.GetSymbol(unitType);
    }

        public class InvalidUnitFormat : Exception
        {
            public InvalidUnitFormat(string measurement)
                : base($"The format provided cannot be parsed into units.\nMeasurement: {measurement}")
            { }
        }

        public class UnknownUnitType : Exception
        {
            public UnknownUnitType(Type type)
                : base ($"Cannot determine type of unit {type.Name}")
            { }
        }
    }
}
