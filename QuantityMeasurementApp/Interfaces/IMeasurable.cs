namespace QuantityMeasurementApp.Interfaces
{
    /// <summary>
    /// The IMeasurable interface defines a common contract for all unit enums.
    /// Any measurement unit (LengthUnit, WeightUnit, etc.) must implement
    /// conversion to and from a base unit.
    /// </summary>
    public interface IMeasurable
    {
        double ConvertToBaseUnit(double value);

        double ConvertFromBaseUnit(double baseValue);

        string GetUnitName();
    }
}