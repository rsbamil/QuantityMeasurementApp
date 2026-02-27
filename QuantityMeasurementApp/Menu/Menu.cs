using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
namespace QuantityMeasurementApp.Menu
{
    public class Menu
    {
        // <summary>
        // This class provides a console-based menu for the Quantity Measurement Application. It allows users to check the equality of measurements in different units (feet, inches, yards, centimeters) and provides an option to exit the application. The menu continuously prompts the user until they choose to exit.
        // </summary>
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("===== Quantity Measurement Application =====");
                Console.WriteLine("\n1. Check Feet Equality");
                Console.WriteLine("\n2. Check Inch Equality");
                Console.WriteLine("\n3. Check Length Equality (Generic)");
                Console.WriteLine("\n4. Convert Length Units");
                Console.WriteLine("\n5. Add Two Lengths");
                Console.WriteLine("\n6. Add Two Lengths (Choose Target Unit)");
                Console.WriteLine("\n7. Exit");
                Console.WriteLine("\nEnter your choice:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckFeetEquality();
                        break;
                    case 2:
                        CheckInchEquality();
                        break;
                    case 3:
                        CheckGenericLengthEquality();
                        break;
                    case 4:
                        ConvertLength();
                        break;
                    case 5:
                        AddTwoLengths();
                        break;
                    case 6:
                        AddLengthsWithTarget();
                        break;
                    case 7:
                        Console.WriteLine("Exiting the application....");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // <summary>
        // The CheckFeetEquality method prompts the user to enter two values in feet, creates QuantityLength objects for each value, and uses the QuantityLengthUtility to check if they are equal. It then displays the result to the user.
        // </summary>
        private void CheckFeetEquality()
        {
            Console.WriteLine("Enter first value in feet:");
            double value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second value in feet:");
            double value2 = double.Parse(Console.ReadLine());

            QuantityLength l1 = new QuantityLength(value1, LengthUnit.FEET);
            QuantityLength l2 = new QuantityLength(value2, LengthUnit.FEET);

            QuantityLengthUtility lengthUitlity = new QuantityLengthUtility();

            bool result = lengthUitlity.AreEqual(l1, l2);

            Console.WriteLine(result ? "The measurements are equal." : "The measurements are not equal.");
        }

        // <summary>
        // The CheckInchEquality method prompts the user to enter two values in inches, creates QuantityLength objects for each value, and uses the QuantityLengthUtility to check if they are equal. It then displays the result to the user.
        // </summary>
        private void CheckInchEquality()
        {
            Console.WriteLine("Enter first value in inches:");
            double value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second value in inches:");
            double value2 = double.Parse(Console.ReadLine());

            QuantityLength l1 = new QuantityLength(value1, LengthUnit.INCH);
            QuantityLength l2 = new QuantityLength(value2, LengthUnit.INCH);

            QuantityLengthUtility lengthUitlity = new QuantityLengthUtility();

            bool result = lengthUitlity.AreEqual(l1, l2);

            Console.WriteLine(result ? "The measurements are equal." : "The measurements are not equal.");
        }

        // <summary>
        // The CheckGenericLengthEquality method prompts the user to enter two values and their corresponding units (feet, inches, yards, centimeters), creates QuantityLength objects for each value, and uses the QuantityLengthUtility to check if they are equal. It then displays the result to the user.
        // </summary>

        private void CheckGenericLengthEquality()
        {
            Console.WriteLine("Enter first value:");
            double value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter first unit (FEET/INCH/YARDS/CENTIMETERS):");
            LengthUnit unit1 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.WriteLine("Enter second value:");
            double value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second unit (FEET/INCH/YARDS/CENTIMETERS):");
            LengthUnit unit2 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            QuantityLength l1 = new QuantityLength(value1, unit1);
            QuantityLength l2 = new QuantityLength(value2, unit2);

            QuantityLengthUtility lengthUtility = new QuantityLengthUtility();

            bool result = lengthUtility.AreEqual(l1, l2);

            Console.WriteLine(result ? "The measurements are equal." : "The measurements are not equal.");
        }

        // <summary>
        // The ConvertLength method prompts the user to enter a value, its source unit, and a target unit. It then uses the QuantityLength class's Convert method to convert the value from the source unit to the target unit and displays the converted value to the user.
        // </summary>
        private void ConvertLength()
        {
            Console.WriteLine("Enter value to convert:");
            double value = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter source unit (FEET/INCH/YARDS/CENTIMETERS):");
            LengthUnit sourceUnit = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.WriteLine("Enter target unit (FEET/INCH/YARDS/CENTIMETERS):");
            LengthUnit targetUnit = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            double convertedValue = QuantityLength.Convert(value, sourceUnit, targetUnit);

            Console.WriteLine("Converted value: " + convertedValue + " " + targetUnit);
        }

        // <summary>
        // The AddTwoLengths method prompts the user to enter two values and their corresponding units, creates QuantityLength objects for each value, and uses the Add method of the QuantityLength class to calculate the sum of the two lengths. It then displays the result to the user.
        // </summary>
        private void AddTwoLengths()
        {
            Console.WriteLine("Enter first value:");
            double value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter first unit (FEET/INCH/YARDS/CENTIMETERS):");
            LengthUnit unit1 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.WriteLine("Enter first value:");
            double value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter first unit (FEET/INCH/YARDS/CENTIMETERS):");
            LengthUnit unit2 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            QuantityLength length1 = new QuantityLength(value1, unit1);
            QuantityLength length2 = new QuantityLength(value2, unit2);

            QuantityLength sum = length1.Add(length2);
            Console.WriteLine("Sum of the two lengths: " + sum.Value + " " + sum.Unit);
        }

        // <summary>
        // This method adds two lengths and displays the result. It prompts the user to enter two values and their corresponding units, as well as a target unit for the sum. It then creates QuantityLength objects for each value, uses the Add method of the QuantityLength class to calculate the sum in the target unit, and displays the result to the user.
        // </summary>
        private void AddLengthsWithTarget()
        {
            Console.WriteLine("Enter first value:");
            double value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter first unit (FEET/INCH/YARDS/CENTIMETERS):");
            LengthUnit unit1 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.WriteLine("Enter second value:");
            double value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second unit (FEET/INCH/YARDS/CENTIMETERS):");
            LengthUnit unit2 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.WriteLine("Enter target unit for the sum (FEET/INCH/YARDS/CENTIMETERS):");
            LengthUnit targetUnit = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            QuantityLength length1 = new QuantityLength(value1, unit1);
            QuantityLength length2 = new QuantityLength(value2, unit2);

            QuantityLength sum = length1.Add(length2, targetUnit);
            Console.WriteLine("Sum of the two lengths: " + sum.Value + " " + sum.Unit);
        }
    }
}