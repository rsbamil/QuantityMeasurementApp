using QuantityMeasurementApp.Console.Controller;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTOs;

namespace QuantityMeasurementApp.Console.Menu
{
    public class Menu
    {
        public IQuantityMeasurementService _controller;

        public Menu(IQuantityMeasurementService controller)
        {
            _controller = controller;
        }

        public void Show()
        {
            while (true)
            {
                System.Console.WriteLine("\n===== Quantity Measurement Menu =====");
                System.Console.WriteLine("1. Compare Quantities");
                System.Console.WriteLine("2. Add Quantities");
                System.Console.WriteLine("3. Show History");
                System.Console.WriteLine("4. Exit");
                System.Console.Write("Enter your choice: ");

                string? choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CompareFlow();
                        break;
                    case "2":
                        AddFlow();
                        break;
                    case "3":
                        ShowHistory();
                        break;
                    case "4":
                        System.Console.WriteLine("Exiting application...");
                        return;
                    default:
                        System.Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void CompareFlow()
        {
            var first = ReadQuantity("First");
            var second = ReadQuantity("Second");

            bool result = _controller.Compare(first, second);
            System.Console.WriteLine($"Comparison Result: {result}");
        }

        private void AddFlow()
        {
            var first = ReadQuantity("First");
            var second = ReadQuantity("Second");

            var result = _controller.Add(first, second);
            System.Console.WriteLine($"Addition Result: {result.BaseValue} {result.Unit}");
        }

        private void ShowHistory()
        {
            var history = _controller.GetHistory();

            if (history.Count == 0)
            {
                System.Console.WriteLine("No history found.");
                return;
            }

            foreach (var item in history)
            {
                System.Console.WriteLine($"Id: {item.Id}, Value: {item.Value}, Unit: {item.Unit}, Category: {item.Category}");
            }
        }

        private QuantityDTO ReadQuantity(string label)
        {
            System.Console.WriteLine($"\nEnter {label} Quantity Details");

            System.Console.WriteLine("Select Category:");
            System.Console.WriteLine("1. Length");
            System.Console.WriteLine("2. Weight");
            System.Console.WriteLine("3. Volume");
            System.Console.WriteLine("4. Temperature");

            System.Console.Write("Choice: ");
            int categoryChoice = Convert.ToInt32(System.Console.ReadLine());

            string category = "";
            List<string> units = new List<string>();

            switch (categoryChoice)
            {
                case 1:
                    category = "Length";
                    units = new List<string> { "Feet", "Inch", "Meter", "Centimeter" };
                    break;

                case 2:
                    category = "Weight";
                    units = new List<string> { "Kilogram", "Gram", "Tonne" };
                    break;

                case 3:
                    category = "Volume";
                    units = new List<string> { "Litre", "Millilitre", "Gallon" };
                    break;

                case 4:
                    category = "Temperature";
                    units = new List<string> { "Celsius", "Fahrenheit", "Kelvin" };
                    break;

                default:
                    System.Console.WriteLine("Invalid Category");
                    return ReadQuantity(label);
            }

            System.Console.WriteLine("Select Unit:");
            for (int i = 0; i < units.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {units[i]}");
            }

            System.Console.Write("Choice: ");
            int unitChoice = Convert.ToInt32(System.Console.ReadLine());

            string unit = units[unitChoice - 1];

            System.Console.Write("Enter Value: ");
            double value = Convert.ToDouble(System.Console.ReadLine());

            return new QuantityDTO
            {
                Category = category,
                Unit = unit,
                Value = value
            };
        }
    }
}