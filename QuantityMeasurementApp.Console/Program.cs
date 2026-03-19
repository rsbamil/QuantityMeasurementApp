using QuantityMeasurementApp.Console.Menu;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppRepositoryLayer.Interface;
using QuantityMeasurementApp.Console.Controller;


IQuantityMeasurementRepository repository = new QuantityMeasurementDatabaseRepository();
IQuantityMeasurementService service = new QuantityMeasurementService(repository);
QuantityMeasurementController controller = new QuantityMeasurementController(service);
Menu menu = new Menu(controller);

menu.Show();