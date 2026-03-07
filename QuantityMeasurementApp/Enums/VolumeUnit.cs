namespace QuantityMeasurementApp.Enums
{
    /// <summary>
    /// Enum representing volume units
    /// </summary>
    public enum VolumeUnit
    {
        LITRE,
        MILLILITRE,
        GALLON
    }

    /// <summary>
    /// Static class for converting volume units to and from base unit (LITRE)
    /// </summary>
    public static class VolumeUnitConverter
    {
        /// <summary>
        /// Converts given unit value → base unit (LITRE)
        /// </summary>

        public static double ConvertToBaseUnit(VolumeUnit unit, double value)
        {
            switch (unit)
            {
                case VolumeUnit.LITRE:
                    return value;

                case VolumeUnit.MILLILITRE:
                    return value * 0.001;

                case VolumeUnit.GALLON:
                    return value * 3.78541;

                default:
                    throw new ArgumentException("Invalid volume unit");
            }
        }
        /// <summary>
        /// Converts base unit (LITRE) → target unit
        /// </summary>
        public static double ConvertFromBase(double litreValue, VolumeUnit unit)
        {
            switch (unit)
            {
                case VolumeUnit.LITRE:
                    return litreValue;

                case VolumeUnit.MILLILITRE:
                    return litreValue / 0.001;

                case VolumeUnit.GALLON:
                    return litreValue / 3.78541;

                default:
                    throw new ArgumentException("Invalid volume unit");
            }
        }
    }
}