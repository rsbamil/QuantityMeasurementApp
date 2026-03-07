using QuantityMeasurementApp.Interfaces;

namespace QuantityMeasurementApp.Enums
{
    /// <summary>
    /// Enum representing length units.
    /// Base unit = FEET
    /// </summary>
    public enum LengthUnit
    {
        FEET,
        INCH,
        YARDS,
        CENTIMETERS
    }

    /// <summary>
    /// Extension methods implementing IMeasurable behaviour for LengthUnit
    /// </summary>
    public static class LengthUnitExtensions
    {
        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            switch (unit)
            {
                case LengthUnit.FEET:
                    return value;

                case LengthUnit.INCH:
                    return value / 12;

                case LengthUnit.YARDS:
                    return value * 3;

                case LengthUnit.CENTIMETERS:
                    return value / 30.48;

                default:
                    throw new ArgumentException("Invalid length unit");
            }
        }

        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            switch (unit)
            {
                case LengthUnit.FEET:
                    return baseValue;

                case LengthUnit.INCH:
                    return baseValue * 12;

                case LengthUnit.YARDS:
                    return baseValue / 3;

                case LengthUnit.CENTIMETERS:
                    return baseValue * 30.48;

                default:
                    throw new ArgumentException("Invalid length unit");
            }
        }

        public static string GetUnitName(this LengthUnit unit)
        {
            return unit.ToString();
        }
    }
}