using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    public sealed class QuantityWeight
    {
        public readonly double _value;
        public readonly WeightUnit _unit;

        public QuantityWeight(double value, WeightUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Invalid weight value");
            }
            _value = value;
            _unit = unit;
        }

        public double Value
        {
            get
            {
                return _value;
            }
        }
        public WeightUnit Unit
        {
            get
            {
                return _unit;
            }
        }

        public QuantityWeight ConvertTo(WeightUnit targetUnit)
        {
            double kg = WeightUnitConverter.ConvertToBase(_value, _unit);
            double convertedValue = WeightUnitConverter.ConvertFromBase(kg, targetUnit);
            return new QuantityWeight(convertedValue, targetUnit);
        }

        public QuantityWeight Add(QuantityWeight other)
        {
            return Add(other, this._unit);
        }

        public QuantityWeight Add(QuantityWeight other, WeightUnit targetUnit)
        {
            if (other == null)
            {
                throw new ArgumentException("Other weight cannot be null");
            }
            double kg1 = WeightUnitConverter.ConvertToBase(this._value, this._unit);
            double kg2 = WeightUnitConverter.ConvertToBase(other._value, other._unit);
            double sumKg = kg1 + kg2;
            double convertedValue = WeightUnitConverter.ConvertFromBase(sumKg, targetUnit);
            return new QuantityWeight(convertedValue, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj == null || GetType() != typeof(QuantityWeight))
            {
                return false;
            }

            QuantityWeight other = (QuantityWeight)obj;
            double thisKg = WeightUnitConverter.ConvertToBase(this._value, this._unit);
            double otherKg = WeightUnitConverter.ConvertToBase(other._value, other._unit);
            return thisKg.CompareTo(otherKg) == 0;
        }

        public override int GetHashCode()
        {
            double kg = WeightUnitConverter.ConvertToBase(this._value, this._unit);
            return kg.GetHashCode();
        }
    }
}