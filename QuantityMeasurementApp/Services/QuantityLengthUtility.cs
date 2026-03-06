using QuantityMeasurementApp.Models;
namespace QuantityMeasurementApp.Services
{
    // <summary>
    // The QuantityLengthUtility class provides a method to compare two QuantityLength objects for equality. It checks if either of the objects is null and returns false if so. Otherwise, it uses the overridden Equals method of the QuantityLength class to determine if the two measurements are equal, allowing for comparisons across different units of length.
    // </summary>
    public class QuantityLengthUtility
    {
        public bool AreEqual(QuantityLength l1, QuantityLength l2)
        {
            if (l1 == null || l2 == null)
            {
                return false;
            }
            return l1.Equals(l2);
        }
    }
}