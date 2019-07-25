namespace Unitary
{
    public interface ICompoundUnit<T, TUnitOne, TUnitTwo> : IUnit
    {
        double GetScaleFactor(TUnitOne unitOne, TUnitTwo unitTwo);
        T ConvertTo(TUnitOne unitOne, TUnitTwo unitTwo);
        T ConvertTo(string units);
    }
}
