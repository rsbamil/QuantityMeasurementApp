using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
namespace QuantityMeasurementApp.Tests.Unit
{

    [TestClass]
    public class QuantityLengthAdditionTests
    {
        [TestMethod]
        public void FeetPlusFeet()
        {
            QuantityLength a = new QuantityLength(1, LengthUnit.FEET);
            QuantityLength b = new QuantityLength(2, LengthUnit.FEET);

            QuantityLength result = a.Add(b);

            Assert.AreEqual(3, result.Value);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void FeetPlusInches()
        {
            QuantityLength a = new QuantityLength(1, LengthUnit.FEET);
            QuantityLength b = new QuantityLength(12, LengthUnit.INCH);

            QuantityLength result = a.Add(b);

            Assert.AreEqual(2, result.Value);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void InchesPlusFeet()
        {
            QuantityLength a = new QuantityLength(12, LengthUnit.INCH);
            QuantityLength b = new QuantityLength(1, LengthUnit.FEET);

            QuantityLength result = a.Add(b);

            Assert.AreEqual(24, result.Value);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void YardPlusFeet()
        {
            QuantityLength a = new QuantityLength(1, LengthUnit.YARDS);
            QuantityLength b = new QuantityLength(3, LengthUnit.FEET);

            QuantityLength result = a.Add(b);

            Assert.AreEqual(2, result.Value);
            Assert.AreEqual(LengthUnit.YARDS, result.Unit);
        }

        [TestMethod]
        public void CentimeterPlusInch()
        {
            QuantityLength a = new QuantityLength(2.54, LengthUnit.CENTIMETERS);
            QuantityLength b = new QuantityLength(1, LengthUnit.INCH);

            QuantityLength result = a.Add(b);

            Assert.AreEqual(5.08, result.Value, 0.01);
        }

    }
}