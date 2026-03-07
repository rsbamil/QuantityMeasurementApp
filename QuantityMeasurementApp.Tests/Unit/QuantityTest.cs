using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests
{
    /// <summary>
    /// Test class for Generic Quantity<U> implementation (UC10)
    /// </summary>
    [TestClass]
    public class QuantityTest
    {

        // -------------------------
        // LENGTH EQUALITY TESTS
        // -------------------------

        [TestMethod]
        public void testEquality_FeetToFeet_SameValue()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_InchToInch_SameValue()
        {
            var q1 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_FeetToInch_EquivalentValue()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_YardToFeet_EquivalentValue()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.YARDS);
            var q2 = new Quantity<LengthUnit>(3.0, LengthUnit.FEET);

            Assert.IsTrue(q1.Equals(q2));
        }


        // -------------------------
        // LENGTH CONVERSION TESTS
        // -------------------------

        [TestMethod]
        public void testConversion_FeetToInches()
        {
            var q = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            var result = q.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, result.Value, 0.0001);
        }

        [TestMethod]
        public void testConversion_InchesToFeet()
        {
            var q = new Quantity<LengthUnit>(24.0, LengthUnit.INCH);

            var result = q.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(2.0, result.Value, 0.0001);
        }


        // -------------------------
        // LENGTH ADDITION TESTS
        // -------------------------

        [TestMethod]
        public void testAddition_FeetPlusFeet()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, 0.0001);
        }

        [TestMethod]
        public void testAddition_FeetPlusInches()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = q1.Add(q2);

            Assert.AreEqual(2.0, result.Value, 0.0001);
        }

        [TestMethod]
        public void testAddition_WithTargetUnit()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = q1.Add(q2, LengthUnit.INCH);

            Assert.AreEqual(24.0, result.Value, 0.0001);
        }


        // -------------------------
        // WEIGHT EQUALITY TESTS
        // -------------------------

        [TestMethod]
        public void testEquality_KgToKg_SameValue()
        {
            var w1 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            Assert.IsTrue(w1.Equals(w2));
        }

        [TestMethod]
        public void testEquality_KgToGram_EquivalentValue()
        {
            var w1 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            Assert.IsTrue(w1.Equals(w2));
        }


        // -------------------------
        // WEIGHT CONVERSION TESTS
        // -------------------------

        [TestMethod]
        public void testConversion_KgToGram()
        {
            var w = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            var result = w.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(1000.0, result.Value, 0.0001);
        }

        [TestMethod]
        public void testConversion_PoundToKg()
        {
            var w = new Quantity<WeightUnit>(2.20462, WeightUnit.POUND);

            var result = w.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(1.0, result.Value, 0.01);
        }


        // -------------------------
        // WEIGHT ADDITION TESTS
        // -------------------------

        [TestMethod]
        public void testAddition_KgPlusGram()
        {
            var w1 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var w2 = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            var result = w1.Add(w2);

            Assert.AreEqual(2.0, result.Value, 0.0001);
        }


        // -------------------------
        // CROSS CATEGORY TEST
        // -------------------------

        [TestMethod]
        public void testCrossCategory_LengthVsWeight_NotEqual()
        {
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var weight = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            Assert.IsFalse(length.Equals(weight));
        }
    }
}