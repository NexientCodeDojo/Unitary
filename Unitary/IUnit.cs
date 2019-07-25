namespace Unitary
{
    public interface IUnit
    {
        double Magnitude { get; }
        object Units { get; }
        string Symbol { get; }
        IUnit ConvertTo(System.Enum unit);
        IUnit ConvertTo(string unit);
    }

    public interface IUnit<T, TUnit> : IUnit
    {
        new TUnit Units { get; }
        double GetScaleFactor(TUnit unit);
        T ConvertTo(TUnit unit);
        new T ConvertTo(string unit);
    }
}
