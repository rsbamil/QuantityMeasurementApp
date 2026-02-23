using QuantityMeasurementApp.Enums;
namespace QuantityMeasurementApp.Models
{
    // <summary>
    // The QuantityLength class represents a measurement of length in various units (feet, inches, yards, centimeters). It encapsulates a double value for the measurement and an enum for the unit. The class provides methods to convert measurements to a common base unit (feet) for comparison and overrides the Equals and GetHashCode methods to allow for equality checks between different length measurements.
    // </summary>
    public sealed class QuantityLength
    {
        private readonly double _value;
        private readonly LengthUnit _unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            if (value < 0)
            {
                throw new ArgumentException("Length value cannot be negative");
            }
            if (!Enum.IsDefined(typeof(LengthUnit), unit))
            {
                throw new ArgumentException("Invalid length unit");
            }

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

        // Base unit for length is feet, so we convert all measurements to feet for comparison
        public double ConvertToFeet()
        {
            switch (_unit)
            {
                case LengthUnit.FEET:
                    return _value;
                case LengthUnit.INCH:
                    return _value / 12.0;
                case LengthUnit.YARDS:
                    return _value * 3.0;
                case LengthUnit.CENTIMETERS:
                    return _value * 0.393701 / 12.0;
                default:
                    throw new InvalidOperationException("Unsupported length unit");
            }
        }

        // <summary>
        // The ConvertTo method converts the current QuantityLength object to a specified target unit. It first converts the current measurement to feet using the ConvertToFeet method, and then converts that value to the target unit based on the conversion factors for each unit. This allows for flexible comparisons and conversions between different length units.
        // </summary>
        public QuantityLength ConvertTo(LengthUnit targetUnit)
        {
            double valueInFeet = ConvertToFeet();
            double convertedValue;
            switch (targetUnit)
            {
                case LengthUnit.FEET:
                    convertedValue = valueInFeet;
                    break;
                case LengthUnit.INCH:
                    convertedValue = valueInFeet * 12.0;
                    break;
                case LengthUnit.YARDS:
                    convertedValue = valueInFeet / 3.0;
                    break;
                case LengthUnit.CENTIMETERS:
                    convertedValue = (valueInFeet * 12) / 0.393701;
                    break;
                default:
                    throw new InvalidOperationException("Unsupported length unit");
            }
            return new QuantityLength(convertedValue, targetUnit);
        }

        public static double Convert(double value, LengthUnit source, LengthUnit target)
        {
            QuantityLength length = new QuantityLength(value, source);
            return length.ConvertTo(target).Value;
        }

        // <summary>
        // The Add method takes another QuantityLength object as a parameter, checks for null, and then adds the two measurements together by first converting both to feet. The sum is then converted back to the unit of the current object before being returned as a new QuantityLength object. This allows for adding lengths in different units seamlessly.
        // </summary>
        public QuantityLength Add(QuantityLength other)
        {
            if (other == null)
            {
                throw new ArgumentException("Second Operand cannot be null");
            }

            double sumInFeet = this.ConvertToFeet() + other.ConvertToFeet();
            return new QuantityLength(sumInFeet, LengthUnit.FEET).ConvertTo(this._unit);
        }

        // <summary>
        // The static Add method allows for adding two QuantityLength objects without needing to call the instance method on one of them. It checks for null operands and then calls the instance Add method on the first operand, passing the second operand as a parameter. This provides a convenient way to add two lengths together in a single line of code.
        // </summary>
        public static QuantityLength Add(QuantityLength first, QuantityLength second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentException("Operands cannot be null");
            }
            return first.Add(second);
        }

        // <summary>
        // The Add method with a target unit allows for adding two QuantityLength objects and specifying the unit for the result. It checks for null operands, adds the two lengths together in feet, and then converts the result to the specified target unit before returning it as a new QuantityLength object. This provides flexibility in how the results of addition are represented.
        // </summary>
        public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
        {
            if (other == null)
            {
                throw new ArgumentException("Second Operand cannot be null");
            }
            double sumInFeet = this.ConvertToFeet() + other.ConvertToFeet();
            double resultValue = Convert(sumInFeet, LengthUnit.FEET, targetUnit);
            return new QuantityLength(resultValue, targetUnit);
        }

        // <summary>
        // The Equals method is overridden to provide a way to compare two QuantityLength objects based on their values and units. It first checks if the references are the same, then checks for null and type compatibility, and finally compares the converted values in feet using CompareTo.
        // </summary>
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

        // <summary>
        // GetHashCode is overridden to ensure that the hash code is consistent with the Equals method. It returns the hash code of the converted value in feet, which ensures that two QuantityLength objects that are considered equal will have the same hash code.
        // </summary>
        public override int GetHashCode()
        {
            return ConvertToFeet().GetHashCode();
        }
    }
}