using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.Enums
{
    /// <summary>
    /// Temperature units with conversion formulas
    /// Celsius is base unit
    /// </summary>
    public enum TemperatureUnit
    {
        CELSIUS,
        FAHRENHEIT,
        KELVIN
    }

    public static class TemperatureUnitConverter
    {
        public static double ConvertToBase(double value, TemperatureUnit unit)
        {
            switch (unit)
            {
                case TemperatureUnit.CELSIUS:
                    return value;

                case TemperatureUnit.FAHRENHEIT:
                    return (value - 32) * 5 / 9;

                case TemperatureUnit.KELVIN:
                    return value - 273.15;

                default:
                    throw new ArgumentException("Invalid temperature unit");
            }
        }

        public static double ConvertFromBase(double baseValue, TemperatureUnit unit)
        {
            switch (unit)
            {
                case TemperatureUnit.CELSIUS:
                    return baseValue;

                case TemperatureUnit.FAHRENHEIT:
                    return (baseValue * 9 / 5) + 32;

                case TemperatureUnit.KELVIN:
                    return baseValue + 273.15;

                default:
                    throw new ArgumentException("Invalid temperature unit");
            }
        }
    }

    /// <summary>
    /// Temperature does NOT support arithmetic operations
    /// </summary>
    public static class TemperatureValidation
    {
        public static void ValidateOperation(string operation)
        {
            throw new UnsupportedOperationException(
                $"Temperature does not support {operation} operation.");
        }
    }

    public class UnsupportedOperationException : Exception
    {
        public UnsupportedOperationException(string message) : base(message)
        {
        }
    }
}