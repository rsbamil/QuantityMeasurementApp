using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Menu
{
    /// <summary>
    /// Console menu for Quantity Measurement Application.
    /// Supports Length and Weight operations using generic Quantity<U>.
    /// </summary>
    public class Menu
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Quantity Measurement Application =====");
                Console.WriteLine("1. Check Feet Equality");
                Console.WriteLine("2. Check Inch Equality");
                Console.WriteLine("3. Check Length Equality (Generic)");
                Console.WriteLine("4. Convert Length Units");
                Console.WriteLine("5. Add Two Lengths");
                Console.WriteLine("6. Add Two Lengths (Choose Target Unit)");
                Console.WriteLine("7. Subtract Two Lengths");
                Console.WriteLine("8. Divide Two Lengths");
                Console.WriteLine("9.. Compare Weights");
                Console.WriteLine("10. Convert Weight");
                Console.WriteLine("11. Add Weights");
                Console.WriteLine("12. Subtract Two Weights");
                Console.WriteLine("13. Divide Two Weights");
                Console.WriteLine("14. Compare Volume");
                Console.WriteLine("15. Convert Volume");
                Console.WriteLine("16. Add Volume");
                Console.WriteLine("17. Subtract Two Volumes");
                Console.WriteLine("18. Divide Two Volumes");
                Console.WriteLine("19. Exit");

                Console.Write("\nEnter your choice: ");
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
                        SubtractTwoLengths();
                        break;
                    case 8:
                        DivideTwoLengths();
                        break;

                    case 9:
                        CompareWeights();
                        break;

                    case 10:
                        ConvertWeight();
                        break;

                    case 11:
                        AddWeights();
                        break;
                    case 12:
                        SubtractTwoWeights();
                        break;
                    case 13:
                        DivideTwoWeights();
                        break;
                    case 14:
                        CompareVolume();
                        break;
                    case 15:
                        ConvertVolume();
                        break;
                    case 16:
                        AddVolume();
                        break;
                    case 17:
                        SubtractTwoVolumes();
                        break;
                    case 18:
                        DivideTwoVolumes();
                        break;
                    case 19:
                        Console.WriteLine("Exiting Application...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        private void CheckFeetEquality()
        {
            Console.Write("Enter first value in feet: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second value in feet: ");
            double v2 = double.Parse(Console.ReadLine());

            var q1 = new Quantity<LengthUnit>(v1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(v2, LengthUnit.FEET);

            Console.WriteLine(q1.Equals(q2) ? "Equal" : "Not Equal");
        }

        private void CheckInchEquality()
        {
            Console.Write("Enter first value in inches: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second value in inches: ");
            double v2 = double.Parse(Console.ReadLine());

            var q1 = new Quantity<LengthUnit>(v1, LengthUnit.INCH);
            var q2 = new Quantity<LengthUnit>(v2, LengthUnit.INCH);

            Console.WriteLine(q1.Equals(q2) ? "Equal" : "Not Equal");
        }

        private void CheckGenericLengthEquality()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit (FEET/INCH/YARDS/CENTIMETERS): ");
            LengthUnit u1 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit (FEET/INCH/YARDS/CENTIMETERS): ");
            LengthUnit u2 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            var q1 = new Quantity<LengthUnit>(v1, u1);
            var q2 = new Quantity<LengthUnit>(v2, u2);

            Console.WriteLine(q1.Equals(q2) ? "Equal" : "Not Equal");
        }

        private void ConvertLength()
        {
            Console.Write("Enter value: ");
            double value = double.Parse(Console.ReadLine());

            Console.Write("Enter source unit: ");
            LengthUnit source = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter target unit: ");
            LengthUnit target = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            var q = new Quantity<LengthUnit>(value, source);

            var result = q.ConvertTo(target);

            Console.WriteLine($"Converted Value: {result.Value} {result.Unit}");
        }

        private void AddTwoLengths()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit: ");
            LengthUnit u1 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit: ");
            LengthUnit u2 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            var q1 = new Quantity<LengthUnit>(v1, u1);
            var q2 = new Quantity<LengthUnit>(v2, u2);

            var result = q1.Add(q2);

            Console.WriteLine($"Sum: {result.Value} {result.Unit}");
        }

        private void AddLengthsWithTarget()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit: ");
            LengthUnit u1 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit: ");
            LengthUnit u2 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter target unit: ");
            LengthUnit target = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            var q1 = new Quantity<LengthUnit>(v1, u1);
            var q2 = new Quantity<LengthUnit>(v2, u2);

            var result = q1.Add(q2, target);

            Console.WriteLine($"Sum: {result.Value} {result.Unit}");
        }

        private void SubtractTwoLengths()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit(FEET/INCH/YARDS/CENTIMETERS): ");
            LengthUnit u1 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit(FEET/INCH/YARDS/CENTIMETERS): ");
            LengthUnit u2 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            var q1 = new Quantity<LengthUnit>(v1, u1);
            var q2 = new Quantity<LengthUnit>(v2, u2);

            var result = q1.Subtract(q2);

            Console.WriteLine($"Difference: {result.Value} {result.Unit}");
        }

        private void DivideTwoLengths()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit(FEET/INCH/YARDS/CENTIMETERS): ");
            LengthUnit u1 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit(FEET/INCH/YARDS/CENTIMETERS): ");
            LengthUnit u2 = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            var q1 = new Quantity<LengthUnit>(v1, u1);
            var q2 = new Quantity<LengthUnit>(v2, u2);

            var result = q1.Divide(q2);

            Console.WriteLine($"Quotient: {result}");
        }

        private void CompareWeights()
        {
            Console.Write("Enter first weight value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit (KILOGRAM/GRAM/POUND): ");
            WeightUnit u1 = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter second weight value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit (KILOGRAM/GRAM/POUND): ");
            WeightUnit u2 = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            var w1 = new Quantity<WeightUnit>(v1, u1);
            var w2 = new Quantity<WeightUnit>(v2, u2);

            Console.WriteLine(w1.Equals(w2) ? "Equal" : "Not Equal");
        }

        private void ConvertWeight()
        {
            Console.Write("Enter weight value: ");
            double value = double.Parse(Console.ReadLine());

            Console.Write("Enter source unit(KILOGRAM/GRAM/POUND): ");
            WeightUnit source = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter target unit(KILOGRAM/GRAM/POUND): ");
            WeightUnit target = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            var q = new Quantity<WeightUnit>(value, source);

            var result = q.ConvertTo(target);

            Console.WriteLine($"Converted Weight: {result.Value} {result.Unit}");
        }

        private void AddWeights()
        {
            Console.Write("Enter first weight value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit(KILOGRAM/GRAM/POUND): ");
            WeightUnit u1 = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter second weight value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit(KILOGRAM/GRAM/POUND): ");
            WeightUnit u2 = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            var w1 = new Quantity<WeightUnit>(v1, u1);
            var w2 = new Quantity<WeightUnit>(v2, u2);

            var result = w1.Add(w2);

            Console.WriteLine($"Sum: {result.Value} {result.Unit}");
        }

        private void SubtractTwoWeights()
        {
            Console.Write("Enter first weight value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit(KILOGRAM/GRAM/POUND): ");
            WeightUnit u1 = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter second weight value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit(KILOGRAM/GRAM/POUND): ");
            WeightUnit u2 = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            var w1 = new Quantity<WeightUnit>(v1, u1);
            var w2 = new Quantity<WeightUnit>(v2, u2);

            var result = w1.Subtract(w2);

            Console.WriteLine($"Difference: {result.Value} {result.Unit}");
        }

        private void DivideTwoWeights()
        {
            Console.Write("Enter first weight value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit(KILOGRAM/GRAM/POUND): ");
            WeightUnit u1 = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            Console.Write("Enter second weight value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter unit(KILOGRAM/GRAM/POUND): ");
            WeightUnit u2 = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            var w1 = new Quantity<WeightUnit>(v1, u1);
            var w2 = new Quantity<WeightUnit>(v2, u2);

            var result = w1.Divide(w2);

            Console.WriteLine($"Quotient: {result}");
        }
        private void CompareVolume()
        {
            Console.WriteLine("Enter first value: ");
            double value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter first unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit unit1 = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            Console.WriteLine("Enter second value: ");
            double value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter first unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit unit2 = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            var v1 = new Quantity<VolumeUnit>(value1, unit1);
            var v2 = new Quantity<VolumeUnit>(value2, unit2);

            Console.WriteLine(v1.Equals(v2) ? "Equal" : "not Equal");
        }

        private void ConvertVolume()
        {
            Console.WriteLine("Enter first value: ");
            double value = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter source unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit source = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            System.Console.WriteLine("Enter target unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit target = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            var volume = new Quantity<VolumeUnit>(value, source);
            var converted = volume.ConvertTo(target);
            System.Console.WriteLine($"Converted Value: {converted.Value} {converted.Unit}");
        }

        private void AddVolume()
        {
            System.Console.WriteLine("Enter first value: ");
            double value1 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter first unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit unit1 = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            System.Console.WriteLine("Enter second value: ");
            double value2 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter second unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit unit2 = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            var volume1 = new Quantity<VolumeUnit>(value1, unit1);
            var volume2 = new Quantity<VolumeUnit>(value2, unit2);

            var sum = volume1.Add(volume2);

            System.Console.WriteLine($"Sum: {sum.Value} {sum.Unit}");
        }

        private void SubtractTwoVolumes()
        {
            System.Console.WriteLine("Enter first value: ");
            double value1 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter first unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit unit1 = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            System.Console.WriteLine("Enter second value: ");
            double value2 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter second unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit unit2 = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            var volume1 = new Quantity<VolumeUnit>(value1, unit1);
            var volume2 = new Quantity<VolumeUnit>(value2, unit2);

            var difference = volume1.Subtract(volume2);

            System.Console.WriteLine($"Difference: {difference.Value} {difference.Unit}");
        }

        private void DivideTwoVolumes()
        {
            System.Console.WriteLine("Enter first value: ");
            double value1 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter first unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit unit1 = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            System.Console.WriteLine("Enter second value: ");
            double value2 = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter second unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit unit2 = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            var volume1 = new Quantity<VolumeUnit>(value1, unit1);
            var volume2 = new Quantity<VolumeUnit>(value2, unit2);

            var quotient = volume1.Divide(volume2);

            System.Console.WriteLine($"Quotient: {quotient}");
        }
    }
}