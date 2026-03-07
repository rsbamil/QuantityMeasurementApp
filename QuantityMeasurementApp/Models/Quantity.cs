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
        /// SUBTRACTION (UC12)
        /// </summary>
        public Quantity<U> Subtract(Quantity<U> other, U targetUnit = default)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double resultBase = ConvertToBase() - other.ConvertToBase();

            if (targetUnit == null)
                targetUnit = this._unit;

            return ConvertFromBase(resultBase, targetUnit);
        }

        /// <summary>
        /// DIVISION (UC12)
        /// Returns scalar ratio
        /// </summary>
        public double Divide(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Operand cannot be null");

            double divisor = other.ConvertToBase();

            if (divisor == 0)
                throw new ArithmeticException("Division by zero");

            return ConvertToBase() / divisor;
        }
        /// <summary>
        /// Converts current value to base unit
        /// </summary>
        private double ConvertToBase()
        {
            if (_unit is LengthUnit lengthUnit)
            {
                return LengthUnitExtensions.ConvertToBaseUnit(lengthUnit, _value);
            }

            if (_unit is WeightUnit weightUnit)
            {
                return WeightUnitExtensions.ConvertToBaseUnit(weightUnit, _value);
            }
            if (_unit is VolumeUnit volumeUnit)
            {
                return VolumeUnitConverter.ConvertToBaseUnit(volumeUnit, _value);
            }
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
            {
                converted = LengthUnitExtensions.ConvertFromBaseUnit(lengthUnit, baseValue);
            }

            else if (targetUnit is WeightUnit weightUnit)
            {
                converted = WeightUnitExtensions.ConvertFromBaseUnit(weightUnit, baseValue);
            }
            else if (targetUnit is VolumeUnit volumeUnit)
            {
                converted = VolumeUnitConverter.ConvertFromBase(baseValue, volumeUnit);
            }
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
            {
                result = LengthUnitExtensions.ConvertFromBaseUnit(lengthUnit, sumBase);
            }

            else if (targetUnit is WeightUnit weightUnit)
            {
                result = WeightUnitExtensions.ConvertFromBaseUnit(weightUnit, sumBase);
            }
            else if (targetUnit is VolumeUnit volumeUnit)
            {
                result = VolumeUnitConverter.ConvertFromBase(sumBase, volumeUnit);
            }
            else
                throw new ArgumentException("Unsupported unit type");

            return new Quantity<U>(result, targetUnit);
        }

        private Quantity<U> ConvertFromBase(double baseValue, U unit)
        {
            double converted;

            if (unit is LengthUnit lengthUnit)
                converted = LengthUnitExtensions.ConvertFromBaseUnit(lengthUnit, baseValue);

            else if (unit is WeightUnit weightUnit)
                converted = WeightUnitExtensions.ConvertFromBaseUnit(weightUnit, baseValue);

            else if (unit is VolumeUnit volumeUnit)
                converted = VolumeUnitConverter.ConvertFromBase(baseValue, volumeUnit);

            else
                throw new ArgumentException("Unsupported unit");

            return new Quantity<U>(converted, unit);
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