namespace QuantityMeasurementApp.Enums
{
    // <summary>
    // Enum representing weight units 
    // </summary>
    public enum WeightUnit
    {
        KILOGRAM,
        GRAM,
        POUND
    }

    // <summary>
    // Static class for converting weight units to and from a base unit (kilogram)
    // </summary>
    public static class WeightUnitConverter
    {
        public static double ConvertToBase(double value, WeightUnit unit)
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

        // <summary>
        // Converts a value from the base unit (kilogram) to the specified weight unit
        // </summary>
        public static double ConvertFromBase(double value, WeightUnit unit)
        {
            switch (unit)
            {
                case WeightUnit.KILOGRAM:
                    return value;
                case WeightUnit.GRAM:
                    return value / 0.001;
                case WeightUnit.POUND:
                    return value / 0.453592;
                default:
                    throw new ArgumentException("Invalid weight unit");
            }
        }
    }
}