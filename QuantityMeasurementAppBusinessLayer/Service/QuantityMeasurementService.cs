using QuantityMeasurementAppBusinessLayer.Exception;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppModelLayer.Models;
using QuantityMeasurementAppRepositoryLayer.Interface;
using QuantityMeasurementAppModelLayer.Enums;

namespace QuantityMeasurementAppBusinessLayer.Service
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository _repository;

        public QuantityMeasurementService(IQuantityMeasurementRepository repository)
        {
            _repository = repository;
        }

        public bool Compare(QuantityDTO first, QuantityDTO second)
        {
            Validate(first);
            Validate(second);

            if (!first.Category.Equals(second.Category, StringComparison.OrdinalIgnoreCase))
                throw new QuantityMeasurementException("Cannot compare different categories.");

            double firstBase = ConvertToBase(first);
            double secondBase = ConvertToBase(second);
            double result = firstBase.CompareTo(secondBase);
            SaveHistory(first, second, "compare", result);

            return firstBase.CompareTo(secondBase) == 0;
        }

        public QuantityDTO Add(QuantityDTO first, QuantityDTO second)
        {
            Validate(first);
            Validate(second);

            if (!first.Category.Equals(second.Category, StringComparison.OrdinalIgnoreCase))
                throw new QuantityMeasurementException("Cannot add different categories.");

            if (first.Category.Equals("Temperature", StringComparison.OrdinalIgnoreCase))
                throw new QuantityMeasurementException("Addition of temperature is not supported.");

            double firstBase = ConvertToBase(first);
            double secondBase = ConvertToBase(second);
            double result = firstBase + secondBase;

            SaveHistory(first, second, "addition", result);

            return new QuantityDTO
            {
                Value = firstBase + secondBase,
                Unit = GetBaseUnit(first.Category),
                Category = first.Category
            };
        }

        public QuantityDTO Subtract(QuantityDTO first, QuantityDTO second)
        {
            Validate(first);
            Validate(second);

            if (!first.Category.Equals(second.Category, StringComparison.OrdinalIgnoreCase))
                throw new QuantityMeasurementException("Cannot subtract different categories.");

            if (first.Category.Equals("Temperature", StringComparison.OrdinalIgnoreCase))
                throw new QuantityMeasurementException("Subtraction of temperature is not supported.");

            double firstBase = ConvertToBase(first);
            double secondBase = ConvertToBase(second);
            double result = firstBase - secondBase;

            SaveHistory(first, second, "subtract", result);

            return new QuantityDTO
            {
                Value = firstBase - secondBase,
                Unit = GetBaseUnit(first.Category),
                Category = first.Category
            };
        }

        public QuantityDTO Division(QuantityDTO first, QuantityDTO second)
        {
            Validate(first);
            Validate(second);
            if (!first.Category.Equals(second.Category, StringComparison.OrdinalIgnoreCase))
            {
                throw new QuantityMeasurementException("Cannot divide different categories.");
            }
            if (first.Category.Equals("Temperature", StringComparison.OrdinalIgnoreCase) || second.Category.Equals("Temperature", StringComparison.OrdinalIgnoreCase))
            {
                throw new QuantityMeasurementException("Division of temperature is not supported.");
            }

            double firstBase = ConvertToBase(first);
            double secondBase = ConvertToBase(second);
            double result = firstBase / secondBase;

            SaveHistory(first, second, "division", result);

            return new QuantityDTO
            {
                Value = firstBase / secondBase,
                Unit = GetBaseUnit(first.Category),
                Category = first.Category
            };
        }
        public List<QuantityMeasurementEntity> GetHistory()
        {
            return _repository.GetAll();
        }

        private void SaveHistory(QuantityDTO dto1, QuantityDTO dto2, string Operation, double result)
        {
            _repository.Save(new QuantityMeasurementEntity
            {
                Value1 = dto1.Value,
                Value2 = dto2.Value,
                Unit1 = dto1.Unit,
                Unit2 = dto2.Unit,
                Category = dto1.Category,
                Operation = Operation,
                Result = result
            });
        }

        private void Validate(QuantityDTO dto)
        {
            if (dto == null)
            {
                throw new QuantityMeasurementException("Quantity cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(dto.Category))
            {
                throw new QuantityMeasurementException("Category is required.");
            }

            if (string.IsNullOrWhiteSpace(dto.Unit))
            {
                throw new QuantityMeasurementException("Unit is required.");
            }
        }

        private double ConvertToBase(QuantityDTO dto)
        {
            string category = dto.Category.ToLower();

            switch (category)
            {
                case "length":
                    var lengthUnit = Enum.Parse<LengthUnit>(dto.Unit, true);

                    return lengthUnit switch
                    {
                        LengthUnit.Inch => dto.Value,
                        LengthUnit.Feet => dto.Value * 12,
                        LengthUnit.Yard => dto.Value * 36,
                        LengthUnit.Centimeter => dto.Value * 0.393701,
                        _ => throw new QuantityMeasurementException("Invalid Length Unit")
                    };

                case "weight":
                    var weightUnit = Enum.Parse<WeightUnit>(dto.Unit, true);

                    return weightUnit switch
                    {
                        WeightUnit.Gram => dto.Value,
                        WeightUnit.Kilogram => dto.Value * 1000,
                        WeightUnit.Pound => dto.Value * 453.592,
                        _ => throw new QuantityMeasurementException("Invalid Weight Unit")
                    };

                case "volume":
                    var volumeUnit = Enum.Parse<VolumeUnit>(dto.Unit, true);

                    return volumeUnit switch
                    {
                        VolumeUnit.Millilitre => dto.Value,
                        VolumeUnit.Litre => dto.Value * 1000,
                        VolumeUnit.Gallon => dto.Value * 3785.41,
                        _ => throw new QuantityMeasurementException("Invalid Volume Unit")
                    };

                case "temperature":
                    var tempUnit = Enum.Parse<TemperatureUnit>(dto.Unit, true);

                    return tempUnit switch
                    {
                        TemperatureUnit.Celsius => dto.Value,
                        TemperatureUnit.Fahrenheit => (dto.Value - 32) * 5 / 9,
                        TemperatureUnit.Kelvin => dto.Value - 273.15,
                        _ => throw new QuantityMeasurementException("Invalid Temperature Unit")
                    };

                default:
                    throw new QuantityMeasurementException("Invalid Category");
            }
        }

        private string GetBaseUnit(string category)
        {
            string result;

            switch (category.Trim().ToLower())
            {
                case "length":
                    result = "Inch";
                    break;

                case "weight":
                    result = "Gram";
                    break;

                case "volume":
                    result = "Millilitre";
                    break;

                case "temperature":
                    result = "Celsius";
                    break;

                default:
                    result = "Unknown";
                    break;
            }

            return result;
        }
    }
}