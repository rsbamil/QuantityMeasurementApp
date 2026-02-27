using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
namespace QuantityMeasurementApp.Tests.Unit
{
    [TestClass]
    public class AddLengthTestsUC7
    {
        [TestMethod]
        public void Add_WithTarget_Feet()
        {
            var a = new QuantityLength(1, LengthUnit.FEET);
            var b = new QuantityLength(12, LengthUnit.INCH);

            var result = a.Add(b, LengthUnit.FEET);

            Assert.AreEqual(2, result.Value);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_WithTarget_Inches()
        {
            var a = new QuantityLength(1, LengthUnit.FEET);
            var b = new QuantityLength(12, LengthUnit.INCH);

            var result = a.Add(b, LengthUnit.INCH);

            Assert.AreEqual(24, result.Value);
        }

        [TestMethod]
        public void Add_WithTarget_Yards()
        {
            var a = new QuantityLength(1, LengthUnit.FEET);
            var b = new QuantityLength(12, LengthUnit.INCH);

            var result = a.Add(b, LengthUnit.YARDS);

            Assert.AreEqual(0.6667, result.Value, 0.01);
        }

        [TestMethod]
        public void Add_Commutative_WithTarget()
        {
            var a = new QuantityLength(1, LengthUnit.FEET);
            var b = new QuantityLength(12, LengthUnit.INCH);

            var r1 = a.Add(b, LengthUnit.FEET);
            var r2 = b.Add(a, LengthUnit.FEET);

            Assert.AreEqual(r1.Value, r2.Value);
        }
    }
}