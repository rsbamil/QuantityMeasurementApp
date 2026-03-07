using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Menu
{
    public class Menu
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Quantity Measurement App =====");

                Console.WriteLine("\n1. Length Equality");
                Console.WriteLine("2. Convert Length");
                Console.WriteLine("3. Add Length");
                Console.WriteLine("4. Subtract Length");
                Console.WriteLine("5. Divide Length");

                Console.WriteLine("\n6. Weight Equality");
                Console.WriteLine("7. Convert Weight");
                Console.WriteLine("8. Add Weight");
                Console.WriteLine("9. Subtract Weight");
                Console.WriteLine("10. Divide Weight");

                Console.WriteLine("\n11. Volume Equality");
                Console.WriteLine("12. Convert Volume");
                Console.WriteLine("13. Add Volume");
                Console.WriteLine("14. Subtract Volume");
                Console.WriteLine("15. Divide Volume");

                Console.WriteLine("\n16. Exit");

                Console.Write("\nEnter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: LengthEquality(); break;
                    case 2: ConvertLength(); break;
                    case 3: AddLength(); break;
                    case 4: SubtractLength(); break;
                    case 5: DivideLength(); break;

                    case 6: WeightEquality(); break;
                    case 7: ConvertWeight(); break;
                    case 8: AddWeight(); break;
                    case 9: SubtractWeight(); break;
                    case 10: DivideWeight(); break;

                    case 11: VolumeEquality(); break;
                    case 12: ConvertVolume(); break;
                    case 13: AddVolume(); break;
                    case 14: SubtractVolume(); break;
                    case 15: DivideVolume(); break;

                    case 16: return;
                }
            }
        }

        // LENGTH
        private Quantity<LengthUnit> GetLength()
        {
            Console.Write("Enter value: ");
            double v = double.Parse(Console.ReadLine());

            Console.Write("Unit (FEET/INCH/YARDS/CENTIMETERS): ");
            LengthUnit u = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());

            return new Quantity<LengthUnit>(v, u);
        }

        private void LengthEquality()
        {
            var q1 = GetLength();
            var q2 = GetLength();
            Console.WriteLine(q1.Equals(q2));
        }

        private void ConvertLength()
        {
            var q = GetLength();
            Console.Write("Target unit: ");
            LengthUnit t = Enum.Parse<LengthUnit>(Console.ReadLine().ToUpper());
            Console.WriteLine(q.ConvertTo(t));
        }

        private void AddLength()
        {
            Console.WriteLine(GetLength().Add(GetLength()));
        }

        private void SubtractLength()
        {
            Console.WriteLine(GetLength().Subtract(GetLength()));
        }

        private void DivideLength()
        {
            Console.WriteLine(GetLength().Divide(GetLength()));
        }

        // WEIGHT
        private Quantity<WeightUnit> GetWeight()
        {
            Console.Write("Enter value: ");
            double v = double.Parse(Console.ReadLine());

            Console.Write("Unit (KILOGRAM/GRAM/POUND): ");
            WeightUnit u = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());

            return new Quantity<WeightUnit>(v, u);
        }

        private void WeightEquality()
        {
            Console.WriteLine(GetWeight().Equals(GetWeight()));
        }

        private void ConvertWeight()
        {
            var q = GetWeight();
            Console.Write("Target unit: ");
            WeightUnit t = Enum.Parse<WeightUnit>(Console.ReadLine().ToUpper());
            Console.WriteLine(q.ConvertTo(t));
        }

        private void AddWeight()
        {
            Console.WriteLine(GetWeight().Add(GetWeight()));
        }

        private void SubtractWeight()
        {
            Console.WriteLine(GetWeight().Subtract(GetWeight()));
        }

        private void DivideWeight()
        {
            Console.WriteLine(GetWeight().Divide(GetWeight()));
        }

        // VOLUME
        private Quantity<VolumeUnit> GetVolume()
        {
            Console.Write("Enter value: ");
            double v = double.Parse(Console.ReadLine());

            Console.Write("Unit (LITRE/MILLILITRE/GALLON): ");
            VolumeUnit u = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());

            return new Quantity<VolumeUnit>(v, u);
        }

        private void VolumeEquality()
        {
            Console.WriteLine(GetVolume().Equals(GetVolume()));
        }

        private void ConvertVolume()
        {
            var q = GetVolume();
            Console.Write("Target unit: ");
            VolumeUnit t = Enum.Parse<VolumeUnit>(Console.ReadLine().ToUpper());
            Console.WriteLine(q.ConvertTo(t));
        }

        private void AddVolume()
        {
            Console.WriteLine(GetVolume().Add(GetVolume()));
        }

        private void SubtractVolume()
        {
            Console.WriteLine(GetVolume().Subtract(GetVolume()));
        }

        private void DivideVolume()
        {
            Console.WriteLine(GetVolume().Divide(GetVolume()));
        }
    }
}