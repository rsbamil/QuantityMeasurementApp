using Microsoft.AspNetCore.Identity;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Exception;
using QuantityMeasurementAppRepositoryLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppModelLayer.Models;
namespace QuantityMeasurementAppBusinessLayer.Service
{
    public class QuantityMeasurementAuthService : IAuthService
    {
        private readonly IQuantityMeasurementRepository _repository = new QuantityMeasurementDatabaseRepository();
        private readonly PasswordHasher<UserEntity> _passwordHasher = new();
        public void SaveUsers(RegisterDTO user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Phone))
            {
                throw new QuantityMeasurementException("Username,Email,password and Phone Number cannot be empty.");
            }

            var userEntity = new UserEntity
            {
                Username = user.Email,
                Email = user.Email,
                Phone = user.Phone,

            };
            userEntity.Password = _passwordHasher.HashPassword(userEntity, user.Password);
            _repository.SaveUser(userEntity);
        }
    }
}