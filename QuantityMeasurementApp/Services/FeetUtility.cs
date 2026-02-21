using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    // The FeetUtility class provides a method to compare two Feet objects for equality. 
    public class FeetUtility
    {
        // The AreEqual method takes two Feet objects as parameters and returns a boolean indicating whether they are equal. It first checks if either of the Feet objects is null, returning false if that is the case. If both objects are non-null, it calls the Equals method on the first Feet object, passing the second Feet object as an argument to compare their values.
        public bool AreEqual(Feet feet1, Feet feet2)
        {
            if (feet1 == null || feet2 == null)
            {
                return false;
            }
            return feet1.Equals(feet2);
        }
    }
}