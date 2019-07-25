using System;
using System.Text.RegularExpressions;

namespace Unitary
{
    public struct Velocity : ICompoundUnit<Velocity, LengthUnits, TimeUnits>
    {
        public double Magnitude { get; }
        object IUnit.Units => LengthUnits;
        public LengthUnits LengthUnits { get; }
        public TimeUnits TimeUnits { get; }
        public string Symbol => $"{UnitDataCache.GetSymbol(LengthUnits)}/{UnitDataCache.GetSymbol(TimeUnits)}";

        public Velocity(double velocity, LengthUnits lengthUnits, TimeUnits timeUnits)
        {
            Magnitude = velocity;
            LengthUnits = lengthUnits;
            TimeUnits = timeUnits;
        }

        public static Velocity Parse(string velocityString)
        {
            return Unitary.Units.Parse<Velocity>(velocityString);
        }

        public static (LengthUnits, TimeUnits) GetUnits(string symbol)
        {
            const string matchPattern = @"^([a-zA-Z]+)\/([a-zA-Z]+)$";
            var match = Regex.Match(symbol, matchPattern);

            if (!match.Success)
            {
                throw new ArgumentException(nameof(symbol));
            }

            var length = match.Groups[1].Value;
            var time = match.Groups[2].Value;

            return (UnitDataCache.GetUnits<LengthUnits>(length), UnitDataCache.GetUnits<TimeUnits>(time));
        }

        public double GetScaleFactor(LengthUnits length, TimeUnits time)
        {
            var numeratorScale = new Length(1, LengthUnits).ConvertTo(length);
            var denominatorScale = new Time(1, TimeUnits).ConvertTo(time);

            return numeratorScale.Magnitude / denominatorScale.Magnitude;
        }

        public static explicit operator double(Velocity velocity) => velocity.Magnitude;
        public override string ToString() => $"{Magnitude:#.###}{Symbol}";

        IUnit IUnit.ConvertTo(Enum unit) => throw new NotImplementedException();
        IUnit IUnit.ConvertTo(string unit) => ConvertTo(unit);
        public Velocity ConvertTo(LengthUnits length, TimeUnits time)
            => new Velocity(Magnitude * GetScaleFactor(length, time), length, time);

        public Velocity ConvertTo(string units)
        {
            var match = Regex.Match(units, @"^([a-zA-Z]+)\/([a-zA-Z]+)$");
            if (!match.Success) throw new Exception($"Cannot convert to illegal format: {units}");

            var length = match.Groups[1].Value;
            var time = match.Groups[2].Value;

            return ConvertTo(UnitDataCache.GetUnits<LengthUnits>(length), UnitDataCache.GetUnits<TimeUnits>(time));
        }

        public Velocity MetersPerSecond => ConvertTo(LengthUnits.Meters, TimeUnits.Seconds);
        public Velocity KilometersPerHour => ConvertTo(LengthUnits.Kilometers, TimeUnits.Hours);
    }
}
