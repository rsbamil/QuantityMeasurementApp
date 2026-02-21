using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
namespace QuantityMeasurementApp.Menu
{
    public class Menu
    {
        private readonly FeetUtility _feetUtility;

        private readonly InchesUtility _inchesUtility;

        public Menu()
        {
            _feetUtility = new FeetUtility();
            _inchesUtility = new InchesUtility();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("===== Quantity Measurement Application =====");
                Console.WriteLine("\n1. Check Feet Equality");
                Console.WriteLine("\n2. Check Inches Equality");
                Console.WriteLine("\n3. Exit");
                Console.WriteLine("\nEnter your choice:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckFeetEquality();
                        break;
                    case 2:
                        CheckInchesEquality();
                        break;
                    case 3:
                        Console.WriteLine("Exiting the application....");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        private void CheckFeetEquality()
        {
            // Read First Input
            Console.WriteLine("Enter the first measurement in feet:");
            double feet1 = double.Parse(Console.ReadLine());

            // Read Second Input
            Console.WriteLine("Enter the second measurement in feet:");
            double feet2 = double.Parse(Console.ReadLine());

            // Create Feet objects and compare them using FeetUtility
            Feet f1 = new Feet(feet1);
            Feet f2 = new Feet(feet2);

            // Invoking the FeetUtility to compare the two Feet objects
            FeetUtility feetUtility = new FeetUtility();
            bool areEqual = feetUtility.AreEqual(f1, f2);

            // Displaying the result
            Console.WriteLine(areEqual ? "The measurements are equal." : "The measurements are not equal.");
        }
        private void CheckInchesEquality()
        {
            // Read First Input
            Console.WriteLine("Enter the first measurement in inches:");
            double inch1 = double.Parse(Console.ReadLine());

            // Read Second Input
            Console.WriteLine("Enter the second measurement in inches:");
            double inch2 = double.Parse(Console.ReadLine());

            // Create Feet objects and compare them using FeetUtility
            Inches f1 = new Inches(inch1);
            Inches f2 = new Inches(inch2);

            // Invoking the FeetUtility to compare the two Feet objects
            InchesUtility inchesUtility = new InchesUtility();
            bool areEqual = inchesUtility.AreEqual(f1, f2);

            // Displaying the result
            Console.WriteLine(areEqual ? "The measurements are equal." : "The measurements are not equal.");
        }
    }
}