using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Models
{
    /// <summary>
    /// Generic Quantity class supporting Length, Weight and Volume
    /// Implements UC13 DRY arithmetic refactoring
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

        // ========================================
        // UC13 ENUM FOR ARITHMETIC OPERATIONS
        // ========================================

        private enum ArithmeticOperation
        {
            ADD,
            SUBTRACT,
            DIVIDE
        }

        // ========================================
        // CENTRAL VALIDATION METHOD
        // ========================================

        private void ValidateArithmeticOperands(Quantity<U> other, U targetUnit, bool targetRequired)
        {
            if (other == null)
                throw new ArgumentException("Operand cannot be null");

            if (targetRequired && targetUnit == null)
                throw new ArgumentException("Target unit cannot be null");

            if (double.IsNaN(_value) || double.IsInfinity(_value))
                throw new ArgumentException("Invalid value");

            if (double.IsNaN(other._value) || double.IsInfinity(other._value))
                throw new ArgumentException("Invalid value");
        }

        // ========================================
        // BASE UNIT CONVERSION
        // ========================================

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
            if (_unit is TemperatureUnit t)
            {
                return TemperatureUnitConverter.ConvertToBase(_value, t);
            }

            throw new ArgumentException("Unsupported unit type");
        }

        private Quantity<U> ConvertFromBase(double baseValue, U targetUnit)
        {
            double result;

            if (targetUnit is LengthUnit lengthUnit)
            {
                result = LengthUnitExtensions.ConvertToBaseUnit(lengthUnit, baseValue);
            }

            else if (targetUnit is WeightUnit weightUnit)
            {
                result = WeightUnitExtensions.ConvertToBaseUnit(weightUnit, baseValue);
            }

            else if (targetUnit is VolumeUnit volumeUnit)
            {
                result = VolumeUnitConverter.ConvertToBaseUnit(volumeUnit, baseValue);
            }
            else if (targetUnit is TemperatureUnit t)
            {
                result = TemperatureUnitConverter.ConvertFromBase(baseValue, t);
            }

            else
            {
                throw new ArgumentException("Unsupported unit");
            }

            return new Quantity<U>(Math.Round(result, 2), targetUnit);
        }

        /// <summary>
        /// Converts the current quantity to the specified target unit
        /// </summary>
        public Quantity<U> ConvertTo(U targetUnit)
        {
            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null");

            double baseValue = ConvertToBase();

            return ConvertFromBase(baseValue, targetUnit);
        }

        // ========================================
        // UC13 CENTRAL ARITHMETIC METHOD
        // ========================================

        private double PerformBaseArithmetic(Quantity<U> other, ArithmeticOperation operation)
        {
            double base1 = ConvertToBase();
            double base2 = other.ConvertToBase();
            if (_unit is TemperatureUnit)
            {
                TemperatureValidation.ValidateOperation(operation.ToString());
            }
            switch (operation)
            {
                case ArithmeticOperation.ADD:
                    return base1 + base2;

                case ArithmeticOperation.SUBTRACT:
                    return base1 - base2;

                case ArithmeticOperation.DIVIDE:
                    if (base2 == 0)
                        throw new ArithmeticException("Division by zero");
                    return base1 / base2;

                default:
                    throw new ArgumentException("Invalid operation");
            }
        }

        // ========================================
        // ADD
        // ========================================

        public Quantity<U> Add(Quantity<U> other)
        {
            ValidateArithmeticOperands(other, _unit, false);

            double result = PerformBaseArithmetic(other, ArithmeticOperation.ADD);

            return ConvertFromBase(result, _unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            ValidateArithmeticOperands(other, targetUnit, true);

            double result = PerformBaseArithmetic(other, ArithmeticOperation.ADD);

            return ConvertFromBase(result, targetUnit);
        }

        // ========================================
        // SUBTRACT
        // ========================================

        public Quantity<U> Subtract(Quantity<U> other)
        {
            ValidateArithmeticOperands(other, _unit, false);

            double result = PerformBaseArithmetic(other, ArithmeticOperation.SUBTRACT);

            return ConvertFromBase(result, _unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            ValidateArithmeticOperands(other, targetUnit, true);

            double result = PerformBaseArithmetic(other, ArithmeticOperation.SUBTRACT);

            return ConvertFromBase(result, targetUnit);
        }

        // ========================================
        // DIVIDE
        // ========================================

        public double Divide(Quantity<U> other)
        {
            ValidateArithmeticOperands(other, default, false);

            return PerformBaseArithmetic(other, ArithmeticOperation.DIVIDE);
        }

        // ========================================
        // EQUALITY
        // ========================================

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Quantity<U>))
                return false;

            Quantity<U> other = (Quantity<U>)obj;

            return Math.Abs(ConvertToBase() - other.ConvertToBase()) < 0.0001;
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