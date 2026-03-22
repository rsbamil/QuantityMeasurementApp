using QuantityMeasurementAppModelLayer.Models;

namespace QuantityMeasurementAppRepositoryLayer.Interface
{
    public interface IQuantityMeasurementRepository
    {
        void Save(QuantityMeasurementEntity entity);
        void SaveUser(UserEntity user);
        // void Login(UserEntity user);
        UserEntity GetUserByUsername(string username);
        List<QuantityMeasurementEntity> GetAll();
    }
}