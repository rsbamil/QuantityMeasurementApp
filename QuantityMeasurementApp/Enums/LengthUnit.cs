using System;

namespace QuantityMeasurementApp.Enums
{
    public enum LengthUnit
    {
        FEET,
        INCH,
        YARDS,
        CENTIMETERS
    }

    // <summary>
    // The LengthUnitConverter class provides static methods to convert length measurements between different units. It includes methods to convert a value from a specified unit to the base unit (feet) and to convert a value from the base unit back to a target unit. This allows for consistent handling of length measurements across different units in the application.
    // </summary>
    public static class LengthUnitConverter
    {
        // Convert value in given unit → FEET (base unit)
        public static double ConvertToBase(double value, LengthUnit unit)
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
                    return (value * 0.393701) / 12;

                default:
                    throw new ArgumentException("Invalid length unit");
            }
        }

        // Convert value from FEET (base unit) → target unit
        public static double ConvertFromBase(double feetValue, LengthUnit unit)
        {
            switch (unit)
            {
                case LengthUnit.FEET:
                    return feetValue;

                case LengthUnit.INCH:
                    return feetValue * 12;

                case LengthUnit.YARDS:
                    return feetValue / 3;

                case LengthUnit.CENTIMETERS:
                    return (feetValue * 12) / 0.393701;

                default:
                    throw new ArgumentException("Invalid length unit");
            }
        }
    }
}