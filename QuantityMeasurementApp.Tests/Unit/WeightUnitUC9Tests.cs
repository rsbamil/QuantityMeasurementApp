using QuantityMeasurementApp.Enums;

using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Unit
{
    // <summary>
    // The WeightUnitUC9Tests class contains unit tests for the QuantityWeight class, specifically focusing on equality comparisons, unit conversions, and addition operations for weight measurements. It includes tests for both same-unit and cross-unit comparisons, ensuring that the Equals method in the QuantityWeight class correctly identifies when two measurements are equal or not, regardless of their units. Additionally, it tests the ConvertTo method for accurate unit conversions and the Add method for correct addition of weights.
    // </summary>
    [TestClass]
    public class WeightUnitUC9Tests
    {
        // Same Unit Equality Tests
        [TestMethod]
        public void Equality_KgToGram()
        {
            // Arrange
            var a = new QuantityWeight(1, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1000, WeightUnit.GRAM);

            // Act & Assert
            Assert.IsTrue(a.Equals(b));
        }

        // Cross Unit Equality Tests
        [TestMethod]
        public void Conversion_KgToPound()
        {
            // Arrange
            var kg = new QuantityWeight(1, WeightUnit.KILOGRAM);
            var pound = kg.ConvertTo(WeightUnit.POUND);

            // Act & Assert

            Assert.AreEqual(2.20462, pound.Value, 0.001);
        }

        // Addition Tests
        [TestMethod]
        public void Addition_KgPlusGram()
        {
            // Arrange
            var a = new QuantityWeight(1, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1000, WeightUnit.GRAM);

            // Act
            var result = a.Add(b);

            // Assert
            Assert.AreEqual(2, result.Value);
        }
    }
}