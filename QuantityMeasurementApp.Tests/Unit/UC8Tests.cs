using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
namespace QuantityMeasurementApp.Tests.Unit
{
    [TestClass]
    public class UC8Tests
    {
        [TestMethod]
        public void ConvertToBase_InchesToFeet()
        {
            double feet = LengthUnitConverter.ConvertToBase(12, LengthUnit.INCH);
            Assert.AreEqual(1, feet);
        }

        [TestMethod]
        public void ConvertFromBase_FeetToYards()
        {
            double yards = LengthUnitConverter.ConvertFromBase(3, LengthUnit.YARDS);
            Assert.AreEqual(1, yards);
        }

        [TestMethod]
        public void QuantityLength_Equality_Refactored()
        {
            var a = new QuantityLength(1, LengthUnit.FEET);
            var b = new QuantityLength(12, LengthUnit.INCH);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void QuantityLength_Add_WithTarget_Refactored()
        {
            var a = new QuantityLength(1, LengthUnit.FEET);
            var b = new QuantityLength(12, LengthUnit.INCH);

            var result = a.Add(b, LengthUnit.YARDS);

            Assert.AreEqual(0.666, result.Value, 0.01);
        }
    }
}