using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppModelLayer.Models;

namespace QuantityMeasurementApp.Console.Controller
{
    public class QuantityMeasurementController
    {
        private readonly IQuantityMeasurementService _service;

        public QuantityMeasurementController(IQuantityMeasurementService service)
        {
            _service = service;
        }

        public bool CompareQuantities(QuantityDTO first, QuantityDTO second)
        {
            return _service.Compare(first, second);
        }

        public QuantityDTO AddQuantities(QuantityDTO first, QuantityDTO second)
        {
            return _service.Add(first, second);
        }

        public QuantityDTO SubtractQuantities(QuantityDTO first, QuantityDTO second)
        {
            return _service.Subtract(first, second);
        }
        public QuantityDTO DivideQuantities(QuantityDTO first, QuantityDTO second)
        {
            return _service.Division(first, second);
        }

        public List<QuantityMeasurementEntity> GetAllHistory()
        {
            return _service.GetHistory();
        }
    }
}