using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
namespace QuantityMeasurementApp.Menu
{
    public class Menu
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("===== Quantity Measurement Application =====");
                Console.WriteLine("\n1. Check Length Equality (Generic)");
                Console.WriteLine("\n2. Exit");
                Console.WriteLine("\nEnter your choice:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckGenericLengthEquality();
                        break;
                    case 2:
                        Console.WriteLine("Exiting the application....");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void CheckGenericLengthEquality()
        {
            Console.WriteLine("Enter first value:");
            double value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter first unit (FEET/INCH):");
            LengthUnit unit1 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.WriteLine("Enter second value:");
            double value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second unit (FEET/INCH):");
            LengthUnit unit2 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            QuantityLength l1 = new QuantityLength(value1, unit1);
            QuantityLength l2 = new QuantityLength(value2, unit2);

            QuantityLengthUtility lengthUitlity = new QuantityLengthUtility();

            bool result = lengthUitlity.AreEqual(l1, l2);

            Console.WriteLine(result ? "The measurements are equal." : "The measurements are not equal.");
        }
    }
}