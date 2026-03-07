using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.Enums
{
    /// <summary>
    /// Enum representing weight units.
    /// Base unit = KILOGRAM
    /// </summary>
    public enum WeightUnit
    {
        KILOGRAM,
        GRAM,
        POUND
    }

    /// <summary>
    /// Extension methods implementing IMeasurable behaviour for WeightUnit
    /// </summary>
    public static class WeightUnitExtensions
    {
        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            switch (unit)
            {
                case WeightUnit.KILOGRAM:
                    return value;

                case WeightUnit.GRAM:
                    return value * 0.001;

                case WeightUnit.POUND:
                    return value * 0.453592;

                default:
                    throw new ArgumentException("Invalid weight unit");
            }
        }

        public static double ConvertFromBaseUnit(this WeightUnit unit, double baseValue)
        {
            switch (unit)
            {
                case WeightUnit.KILOGRAM:
                    return baseValue;

                case WeightUnit.GRAM:
                    return baseValue / 0.001;

                case WeightUnit.POUND:
                    return baseValue / 0.453592;

                default:
                    throw new ArgumentException("Invalid weight unit");
            }
        }

        public static string GetUnitName(this WeightUnit unit)
        {
            return unit.ToString();
        }
    }
}