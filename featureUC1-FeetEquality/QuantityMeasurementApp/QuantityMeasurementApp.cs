using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
namespace QuantityMeasurementApp
{
    public class QuantityMeasurementApp
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Quantity Measurement App!");
            Console.WriteLine("\nUC1: Feet Measurement Equality Check\n");

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
    }
}