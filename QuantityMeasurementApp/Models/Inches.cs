namespace QuantityMeasurementApp.Models
{
    public sealed class Inches
    {
        // This class represents a measurement in Inches. It encapsulates a double value that holds the measurement and provides a property to access it.
        private readonly double _value;
        // The constructor initializes the Inches object with a specific value, and the Value property allows external code to retrieve this value while keeping it immutable.
        public Inches(double val)
        {
            _value = val;
        }
        // This is the public Getter for the Inches value
        public double Value
        {
            get { return _value; }
        }
        // The Equals method is overridden to provide a way to compare two Inches objects based on their values. It first checks if the references are the same, then checks for null and type compatibility, and finally compares the values using CompareTo.
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj == null || obj.GetType() != typeof(Inches))
            {
                return false;
            }
            Inches other = (Inches)obj;
            return _value.CompareTo(other.Value) == 0;
        }
        // GetHashCode is overridden to ensure that the hash code is consistent with the Equals method. It returns the hash code of the underlying value, which ensures that two Inches objects with the same value will have the same hash code.
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}