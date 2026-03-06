using QuantityMeasurementApp.Services;
using QuantityMeasurementApp.Models;
namespace QuantityMeasurementApp.Tests.Unit
{
    // <summary>
    // The FeetEqualityTests class contains unit tests for the Feet class, specifically focusing on equality comparisons between different feet measurements. It includes tests for both same-value and different-value comparisons, as well as null and reference comparisons, ensuring that the AreEqual method in the FeetUtility class correctly identifies when two feet measurements are equal or not.
    // </summary>
    [TestClass]
    public class FeetEqualityTests
    {
        private FeetUtility? _feetUtility;

        [TestInitialize]
        public void Setup()
        {
            _feetUtility = new FeetUtility();
        }

        [TestMethod]
        public void GivenTwoFeetMeasurements_WhenEqual_ShouldReturnTrue()
        {
            // Arrange
            Feet feet1 = new Feet(5.0);
            Feet feet2 = new Feet(5.0);

            // Act
            bool result = _feetUtility.AreEqual(feet1, feet2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoFeetMeasurements_WhenNotEqual_ShouldReturnFalse()
        {
            // Arrange
            Feet feet1 = new Feet(5.0);
            Feet feet2 = new Feet(6.0);

            // Act
            bool result = _feetUtility.AreEqual(feet1, feet2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenOneFeetMeasurementIsNull_WhenComparing_ShouldReturnFalse()
        {
            // Arrange
            Feet feet1 = new Feet(5.0);
            Feet? feet2 = null;

            // Act
            bool result = _feetUtility.AreEqual(feet1, feet2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSameReferenceFeetMeasurements_WhenComparing_ShouldReturnTrue()
        {
            // Arrange
            Feet feet1 = new Feet(5.0);
            Feet feet2 = feet1; // Same reference

            // Act
            bool result = _feetUtility.AreEqual(feet1, feet2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenDifferentTypeObject_WhenComparing_ShouldReturnFalse()
        {
            // Arrange
            Feet feet1 = new Feet(5.0);
            object notAFeet = new object();

            // Act
            bool result = feet1.Equals(notAFeet);

            // Assert
            Assert.IsFalse(result);
        }
    }
}