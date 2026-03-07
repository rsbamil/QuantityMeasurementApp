using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Generic Quantity class that works for all measurement categories
    /// (Length, Weight, etc.)
    /// </summary>
    public sealed class Quantity<U> where U : Enum
    {
        private readonly double _value;
        private readonly U _unit;

        public Quantity(double value, U unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid measurement value");

            _value = value;
            _unit = unit;
        }

        public double Value => _value;

        public U Unit => _unit;

        /// <summary>
        /// Converts current value to base unit
        /// </summary>
        private double ConvertToBase()
        {
            if (_unit is LengthUnit lengthUnit)
                return LengthUnitExtensions.ConvertToBaseUnit(lengthUnit, _value);

            if (_unit is WeightUnit weightUnit)
                return WeightUnitExtensions.ConvertToBaseUnit(weightUnit, _value);

            throw new ArgumentException("Unsupported unit type");
        }

        /// <summary>
        /// Converts quantity to target unit
        /// </summary>
        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ConvertToBase();
            double converted;

            if (targetUnit is LengthUnit lengthUnit)
                converted = LengthUnitExtensions.ConvertFromBaseUnit(lengthUnit, baseValue);

            else if (targetUnit is WeightUnit weightUnit)
                converted = WeightUnitExtensions.ConvertFromBaseUnit(weightUnit, baseValue);

            else
                throw new ArgumentException("Unsupported unit type");

            return new Quantity<U>(converted, targetUnit);
        }

        /// <summary>
        /// Adds two quantities and returns result in first unit
        /// </summary>
        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, this._unit);
        }

        /// <summary>
        /// Adds two quantities and returns result in target unit
        /// </summary>
        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double sumBase = this.ConvertToBase() + other.ConvertToBase();
            double result;

            if (targetUnit is LengthUnit lengthUnit)
                result = LengthUnitExtensions.ConvertFromBaseUnit(lengthUnit, sumBase);

            else if (targetUnit is WeightUnit weightUnit)
                result = WeightUnitExtensions.ConvertFromBaseUnit(weightUnit, sumBase);

            else
                throw new ArgumentException("Unsupported unit type");

            return new Quantity<U>(result, targetUnit);
        }

        /// <summary>
        /// Equality comparison using base unit
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(Quantity<U>))
                return false;

            Quantity<U> other = (Quantity<U>)obj;

            return Math.Abs(this.ConvertToBase() - other.ConvertToBase()) < 0.0001;
        }

        public override int GetHashCode()
        {
            return ConvertToBase().GetHashCode();
        }

        public override string ToString()
        {
            return $"{_value} {_unit}";
        }
    }
}