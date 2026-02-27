using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
namespace QuantityMeasurementApp.Tests.Unit
{
    // <summary>
    // The QuantityLengthTests class contains unit tests for the QuantityLength class, specifically focusing on equality comparisons between different length measurements. It includes tests for both same-unit and cross-unit comparisons, ensuring that the AreEqual method in the QuantityLengthUtility class correctly identifies when two measurements are equal or not, regardless of their units.
    // </summary>
    [TestClass]
    public class QuantityLengthTests
    {
        // Same Unit Equality Tests
        [TestMethod]
        public void testEquality_FeetToFeet_SameValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1, LengthUnit.FEET);
            QuantityLength l2 = new QuantityLength(1, LengthUnit.FEET);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void testEquality_InchToInch_SameValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(12.0, LengthUnit.INCH);
            QuantityLength l2 = new QuantityLength(12.0, LengthUnit.INCH);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }

        // Cross Unit Equality Tests
        [TestMethod]
        public void testEquality_FeetToInch_EqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLength l2 = new QuantityLength(12.0, LengthUnit.INCH);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void testEquality_InchToFeet_EqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(12.0, LengthUnit.INCH);
            QuantityLength l2 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }

        // Inequality Tests
        [TestMethod]
        public void testEquality_FeetToInch_NotEqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLength l2 = new QuantityLength(10.0, LengthUnit.INCH);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void testEquality_InchToFeet_NotEqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(10.0, LengthUnit.INCH);
            QuantityLength l2 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsFalse(result);
        }

        // Same Reference Test
        [TestMethod]
        public void testEquality_SameReference()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLength l2 = l1; // Same reference

            // Act
            bool result = l1.Equals(l2);

            // Assert
            Assert.IsTrue(result);
        }

        // Null Comparison Test
        [TestMethod]
        public void testEquality_NullComparison()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLength l2 = null;

            // Act
            bool result = l1.Equals(l2);

            // Assert
            Assert.IsFalse(result);
        }
    }

}