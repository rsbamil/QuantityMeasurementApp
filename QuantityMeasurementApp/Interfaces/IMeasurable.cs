namespace QuantityMeasurementApp.Interfaces
{
    /// <summary>
    /// Interface implemented by all measurable unit enums
    /// Provides optional arithmetic capability
    /// </summary>
    public interface IMeasurable
    {
        /// <summary>
        /// Indicates whether arithmetic operations are supported
        /// </summary>
        bool SupportsArithmetic()
        {
            return true;
        }

        /// <summary>
        /// Validate if the operation is allowed
        /// </summary>
        void ValidateOperationSupport(string operation)
        {
            // Default allows all operations
        }
    }
}