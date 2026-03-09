using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementAppTests
{
    [TestClass]
    public class TemperatureQuantityTests
    {

        // =====================================
        // TEMPERATURE EQUALITY TESTS
        // =====================================

        [TestMethod]
        public void TestTemperatureEquality_CelsiusToCelsius()
        {
            var t1 = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperatureEquality_CelsiusToFahrenheit()
        {
            var t1 = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(32, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperatureEquality_CelsiusToKelvin()
        {
            var t1 = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(273.15, TemperatureUnit.KELVIN);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperatureEquality_Negative40Equal()
        {
            var t1 = new Quantity<TemperatureUnit>(-40, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(-40, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperatureEquality_ReflexiveProperty()
        {
            var temp = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);

            Assert.IsTrue(temp.Equals(temp));
        }

        [TestMethod]
        public void TestTemperatureEquality_SymmetricProperty()
        {
            var t1 = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(212, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(t1.Equals(t2));
            Assert.IsTrue(t2.Equals(t1));
        }

        // =====================================
        // TEMPERATURE CONVERSION TESTS
        // =====================================

        [TestMethod]
        public void TestTemperatureConversion_CelsiusToFahrenheit()
        {
            var t = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);

            var result = t.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(212, result.Value, 0.01);
        }

        [TestMethod]
        public void TestTemperatureConversion_FahrenheitToCelsius()
        {
            var t = new Quantity<TemperatureUnit>(32, TemperatureUnit.FAHRENHEIT);

            var result = t.ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(0, result.Value, 0.01);
        }

        [TestMethod]
        public void TestTemperatureConversion_KelvinToCelsius()
        {
            var t = new Quantity<TemperatureUnit>(273.15, TemperatureUnit.KELVIN);

            var result = t.ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(0, result.Value, 0.01);
        }

        [TestMethod]
        public void TestTemperatureConversion_CelsiusToKelvin()
        {
            var t = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);

            var result = t.ConvertTo(TemperatureUnit.KELVIN);

            Assert.AreEqual(273.15, result.Value, 0.01);
        }

        [TestMethod]
        public void TestTemperatureConversion_RoundTrip()
        {
            var original = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);

            var converted = original
                .ConvertTo(TemperatureUnit.FAHRENHEIT)
                .ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(original.Value, converted.Value, 0.01);
        }

        [TestMethod]
        public void TestTemperatureConversion_NegativeValues()
        {
            var t = new Quantity<TemperatureUnit>(-20, TemperatureUnit.CELSIUS);

            var result = t.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(-4, result.Value, 0.01);
        }

        [TestMethod]
        public void TestTemperatureConversion_LargeValues()
        {
            var t = new Quantity<TemperatureUnit>(1000, TemperatureUnit.CELSIUS);

            var result = t.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(1832, result.Value, 0.01);
        }


        // =====================================
        // CROSS CATEGORY SAFETY TESTS
        // =====================================

        [TestMethod]
        public void TestTemperatureVsLengthComparison()
        {
            var temp = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);
            var length = new Quantity<LengthUnit>(100, LengthUnit.FEET);

            Assert.IsFalse(temp.Equals(length));
        }

        [TestMethod]
        public void TestTemperatureVsWeightComparison()
        {
            var temp = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);
            var weight = new Quantity<WeightUnit>(50, WeightUnit.KILOGRAM);

            Assert.IsFalse(temp.Equals(weight));
        }

        [TestMethod]
        public void TestTemperatureVsVolumeComparison()
        {
            var temp = new Quantity<TemperatureUnit>(25, TemperatureUnit.CELSIUS);
            var volume = new Quantity<VolumeUnit>(25, VolumeUnit.LITRE);

            Assert.IsFalse(temp.Equals(volume));
        }

        // =====================================
        // EDGE CASE TESTS
        // =====================================

        [TestMethod]
        public void TestTemperatureAbsoluteZero()
        {
            var t1 = new Quantity<TemperatureUnit>(-273.15, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(0, TemperatureUnit.KELVIN);

            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void TestTemperaturePrecisionTolerance()
        {
            var t1 = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(122.00001, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(t1.Equals(t2));
        }

    }
}