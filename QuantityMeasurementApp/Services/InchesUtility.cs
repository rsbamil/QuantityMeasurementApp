using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class InchesUtility
    {
        // The InchesUtility class provides a method to compare two Inches objects for equality.
        public bool AreEqual(Inches inch1, Inches inch2)
        {
            if (inch1 == null || inch2 == null)
            {
                return false;
            }
            return inch1.Equals(inch2);
        }
    }
}