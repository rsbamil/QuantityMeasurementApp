using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests
{
    // <summary>
    /// Test class for Quantity<VolumeUnit> specific tests
    /// </summary>
    [TestClass]
    public class QuantityVolumeTest
    {
        // <summary>
        /// Tests equality of 1 LITRE and 1000 MILLILITRE
        /// </summary>
        [TestMethod]
        public void testEquality_LitreToMillilitre()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            Assert.IsTrue(v1.Equals(v2));
        }

        // <summary>
        /// Tests conversion of 1 LITRE to MILLILITRE
        /// </summary>
        [TestMethod]
        public void testConversion_LitreToMillilitre()
        {
            var v = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);

            var result = v.ConvertTo(VolumeUnit.MILLILITRE);

            Assert.AreEqual(1000, result.Value, 0.001);
        }

        // <summary>
        /// Tests conversion of 1 GALLON to LITRE
        /// </summary>
        [TestMethod]
        public void testConversion_GallonToLitre()
        {
            var v = new Quantity<VolumeUnit>(1, VolumeUnit.GALLON);

            var result = v.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(3.78541, result.Value, 0.001);
        }

        // <summary>
        /// Tests addition of 1 LITRE and 1000 MILLILITRE (result should be 2 LITRE)
        /// </summary>
        [TestMethod]
        public void testAddition_LitrePlusMillilitre()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            var result = v1.Add(v2);

            Assert.AreEqual(2, result.Value, 0.001);
        }

        // <summary>
        /// Tests addition of 1 LITRE and 1000 MILLILITRE with target unit as MILLILITRE (result should be 2000 MILLILITRE)
        /// </summary>
        [TestMethod]
        public void testAddition_WithTargetUnit()
        {
            var v1 = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000, VolumeUnit.MILLILITRE);

            var result = v1.Add(v2, VolumeUnit.MILLILITRE);

            Assert.AreEqual(2000, result.Value, 0.001);
        }

        // <summary>
        /// Tests that volume and length quantities are not equal
        /// </summary>
        [TestMethod]
        public void testVolumeVsLength()
        {
            var volume = new Quantity<VolumeUnit>(1, VolumeUnit.LITRE);
            var length = new Quantity<LengthUnit>(1, LengthUnit.FEET);

            Assert.IsFalse(volume.Equals(length));
        }
    }
}