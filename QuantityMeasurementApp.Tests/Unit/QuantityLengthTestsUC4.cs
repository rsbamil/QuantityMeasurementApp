using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
namespace QuantityMeasurementApp.Tests.Unit
{
    // <summary>
    // The QuantityLengthTestsUC4 class contains unit tests for the QuantityLength class, specifically focusing on equality comparisons between different length measurements. It includes tests for both same-unit and cross-unit comparisons, ensuring that the AreEqual method in the QuantityLengthUtility class correctly identifies when two measurements are equal or not, regardless of their units.
    // </summary>
    [TestClass]
    public class QuantityLengthTestsUC4
    {
        // Yard Equality Tests
        [TestMethod]
        public void testEquality_YardsToYards_SameValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1.0, LengthUnit.YARDS);
            QuantityLength l2 = new QuantityLength(1.0, LengthUnit.YARDS);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void testEquality_YardsToYards_DifferentValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1.0, LengthUnit.YARDS);
            QuantityLength l2 = new QuantityLength(2.0, LengthUnit.YARDS);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsFalse(result);
        }


        // Yard Cross Unit Equality Tests
        [TestMethod]
        public void testEquality_YardsToFeet_EqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1.0, LengthUnit.YARDS);
            QuantityLength l2 = new QuantityLength(3.0, LengthUnit.FEET);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void testEquality_FeetToYards_EqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(3.0, LengthUnit.FEET);
            QuantityLength l2 = new QuantityLength(1.0, LengthUnit.YARDS);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void testEquality_YardsToInch_EqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1.0, LengthUnit.YARDS);
            QuantityLength l2 = new QuantityLength(36.0, LengthUnit.INCH);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void testEquality_InchToYards_EqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(36.0, LengthUnit.INCH);
            QuantityLength l2 = new QuantityLength(1.0, LengthUnit.YARDS);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }

        // Centimeter Equality Tests
        [TestMethod]
        public void testEquality_CentimetersToCentimeters_SameValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(100.0, LengthUnit.CENTIMETERS);
            QuantityLength l2 = new QuantityLength(100.0, LengthUnit.CENTIMETERS);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void testEquality_CentimetersToCentimeters_DifferentValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(100.0, LengthUnit.CENTIMETERS);
            QuantityLength l2 = new QuantityLength(200.0, LengthUnit.CENTIMETERS);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsFalse(result);
        }

        // Centimeter Cross Unit Equality Tests
        [TestMethod]
        public void testEquality_CentimetersToFeet_EqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(30.48, LengthUnit.CENTIMETERS);
            QuantityLength l2 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void testEquality_FeetToCentimeters_EqualValue()
        {
            // Arrange
            QuantityLength l1 = new QuantityLength(1.0, LengthUnit.FEET);
            QuantityLength l2 = new QuantityLength(30.48, LengthUnit.CENTIMETERS);
            QuantityLengthUtility utility = new QuantityLengthUtility();

            // Act
            bool result = utility.AreEqual(l1, l2);

            // Assert
            Assert.IsFalse(result);
        }

    }
}