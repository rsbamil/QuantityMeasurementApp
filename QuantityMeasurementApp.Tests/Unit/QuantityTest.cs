using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementAppTests
{
    [TestClass]
    public class QuantityTests
    {

        // ==============================
        // LENGTH TESTS
        // ==============================

        [TestMethod]
        public void TestLengthEquality_FeetAndInch_ShouldReturnTrue()
        {
            var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12, LengthUnit.INCH);

            Assert.IsTrue(q1.Equals(q2));
        }



        [TestMethod]
        public void TestLengthAddition()
        {
            var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12, LengthUnit.INCH);

            var result = q1.Add(q2);

            Assert.AreEqual(2, result.Value, 0.01);
        }

        // ==============================
        // SUBTRACTION TESTS (UC12)
        // ==============================

        [TestMethod]
        public void TestSubtraction_SameUnit_Feet()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

            var result = q1.Subtract(q2);

            Assert.AreEqual(5, result.Value, 0.01);
        }

        [TestMethod]
        public void TestSubtraction_CrossUnit_FeetMinusInch()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(6, LengthUnit.INCH);

            var result = q1.Subtract(q2);

            Assert.AreEqual(9.5, result.Value, 0.01);
        }

        [TestMethod]
        public void TestSubtraction_ResultNegative()
        {
            var q1 = new Quantity<LengthUnit>(5, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            var result = q1.Subtract(q2);

            Assert.AreEqual(-5, result.Value, 0.01);
        }

        [TestMethod]
        public void TestSubtraction_ResultZero()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(120, LengthUnit.INCH);

            var result = q1.Subtract(q2);

            Assert.AreEqual(0, result.Value, 0.01);
        }

        // ==============================
        // DIVISION TESTS (UC12)
        // ==============================

        [TestMethod]
        public void TestDivision_SameUnit()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(2, LengthUnit.FEET);

            double result = q1.Divide(q2);

            Assert.AreEqual(5, result, 0.01);
        }

        [TestMethod]
        public void TestDivision_CrossUnit()
        {
            var q1 = new Quantity<LengthUnit>(24, LengthUnit.INCH);
            var q2 = new Quantity<LengthUnit>(2, LengthUnit.FEET);

            double result = q1.Divide(q2);

            Assert.AreEqual(1, result, 0.01);
        }

        [TestMethod]
        public void TestDivision_RatioLessThanOne()
        {
            var q1 = new Quantity<LengthUnit>(5, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(10, LengthUnit.FEET);

            double result = q1.Divide(q2);

            Assert.AreEqual(0.5, result, 0.01);
        }

        // ==============================
        // WEIGHT TESTS
        // ==============================

        [TestMethod]
        public void TestWeightEquality_KgAndGram()
        {
            var w1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

            Assert.IsTrue(w1.Equals(w2));
        }

        [TestMethod]
        public void TestWeightAddition()
        {
            var w1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

            var result = w1.Add(w2);

            Assert.AreEqual(2, result.Value, 0.01);
        }

        [TestMethod]
        public void TestWeightSubtraction()
        {
            var w1 = new Quantity<WeightUnit>(10, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(5000, WeightUnit.GRAM);

            var result = w1.Subtract(w2);

            Assert.AreEqual(5, result.Value, 0.01);
        }

        [TestMethod]
        public void TestWeightDivision()
        {
            var w1 = new Quantity<WeightUnit>(10, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(5, WeightUnit.KILOGRAM);

            double result = w1.Divide(w2);

            Assert.AreEqual(2, result, 0.01);
        }

        // ==============================
        // VOLUME TESTS
        // ==============================

        [TestMethod]
        public void TestVolumeEquality_LitreAndMilliLitre()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            Assert.IsTrue(v1.Equals(v2));
        }

        [TestMethod]
        public void TestVolumeAddition()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            var result = v1.Add(v2);

            Assert.AreEqual(2, result.Value, 0.01);
        }

        [TestMethod]
        public void TestVolumeSubtraction()
        {
            var v1 = new Quantity<VolumeUnit>(5, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(500, VolumeUnit.MILLILITRE);

            var result = v1.Subtract(v2);

            Assert.AreEqual(4.5, result.Value, 0.01);
        }

        [TestMethod]
        public void TestVolumeDivision()
        {
            var v1 = new Quantity<VolumeUnit>(5, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(10, VolumeUnit.LITRE);

            double result = v1.Divide(v2);

            Assert.AreEqual(0.5, result, 0.01);
        }

    }
}