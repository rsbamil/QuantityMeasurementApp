using QuantityMeasurementApp.Models;
namespace QuantityMeasurementApp.Services
{
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