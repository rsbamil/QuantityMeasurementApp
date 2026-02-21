using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
namespace QuantityMeasurementApp.Tests.Unit
{
    [TestClass]
    public class InchesEqualityTests
    {
        private InchesUtility _inchesUtility;
        [TestInitialize]
        public void Setup()
        {
            _inchesUtility = new InchesUtility();
        }

        [TestMethod]
        public void GivenTwoFeetMeasurements_WhenEqual_ShouldReturnTrue()
        {
            // Arrange
            Inches inch1 = new Inches(5.0);
            Inches inch2 = new Inches(5.0);

            // Act
            bool result = _inchesUtility.AreEqual(inch1, inch2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoFeetMeasurements_WhenNotEqual_ShouldReturnFalse()
        {
            // Arrange
            Inches inch1 = new Inches(5.0);
            Inches inch2 = new Inches(4.0);

            // Act
            bool result = _inchesUtility.AreEqual(inch1, inch2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenOneFeetMeasurementIsNull_WhenComparing_ShouldReturnFalse()
        {
            // Arrange
            Inches inch1 = new Inches(5.0);
            Inches inch2 = null;

            // Act
            bool result = _inchesUtility.AreEqual(inch1, inch2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenSameReferenceFeetMeasurements_WhenComparing_ShouldReturnTrue()
        {
            // Arrange
            Inches inch1 = new Inches(5.0);
            Inches inch2 = inch1;

            // Act
            bool result = _inchesUtility.AreEqual(inch1, inch2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenDifferentTypeObject_WhenComparing_ShouldReturnFalse()
        {
            // Arrange
            Inches inch1 = new Inches(5.0);
            Object notInch = new Object();

            // Act
            bool result = inch1.Equals(notInch);

            // Assert
            Assert.IsFalse(result);
        }
    }
}