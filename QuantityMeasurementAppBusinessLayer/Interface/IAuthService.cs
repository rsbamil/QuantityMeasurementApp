using QuantityMeasurementAppModelLayer.DTOs;

namespace QuantityMeasurementAppBusinessLayer.Interface
{
    public interface IAuthService
    {
        void SaveUsers(RegisterDTO user);
    }
}