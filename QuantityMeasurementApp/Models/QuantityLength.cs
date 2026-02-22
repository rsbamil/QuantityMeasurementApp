using QuantityMeasurementApp.Enums;
namespace QuantityMeasurementApp.Models
{
    public sealed class QuantityLength
    {
        private readonly double _value;
        private readonly LengthUnit _unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        public double Value
        {
            get { return _value; }
        }
        public LengthUnit Unit
        {
            get { return _unit; }
        }

        private double ConvertToFeet()
        {
            switch (_unit)
            {
                case LengthUnit.FEET:
                    return _value;
                case LengthUnit.INCH:
                    return _value / 12.0;
                default:
                    throw new InvalidOperationException("Unsupported length unit");
            }
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj == null || obj.GetType() != typeof(QuantityLength))
            {
                return false;
            }
            QuantityLength other = (QuantityLength)obj;
            return this.ConvertToFeet().CompareTo(other.ConvertToFeet()) == 0;
        }
        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }
    }
}