using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;
using QuantityMeasurementApp.Menu;
namespace QuantityMeasurementApp
{
    public class QuantityMeasurementApp
    {
        static void Main()
        {
            Menu.Menu menu = new Menu.Menu();
            menu.ShowMenu();
        }
    }
}