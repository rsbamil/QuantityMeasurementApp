using Microsoft.Data.SqlClient;
using QuantityMeasurementAppModelLayer.Models;
using QuantityMeasurementAppRepositoryLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Utils;

namespace QuantityMeasurementAppRepositoryLayer.Database
{
    public class QuantityMeasurementDatabaseRepository
        : IQuantityMeasurementRepository
    {
        public void Save(QuantityMeasurementEntity entity)
        {
            using SqlConnection connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            string query = @"INSERT INTO QuantityMeasurements(Value1,Value2, Unit1,Unit2, Category,Operation,Result)
                             VALUES (@value1,@value2, @unit1,@unit2, @category,@operation,@result)";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@value1", entity.Value1);
            command.Parameters.AddWithValue("@value2", entity.Value2);
            command.Parameters.AddWithValue("@unit1", entity.Unit1);
            command.Parameters.AddWithValue("@unit2", entity.Unit2);
            command.Parameters.AddWithValue("@category", entity.Category);
            command.Parameters.AddWithValue("@operation", entity.Operation);
            command.Parameters.AddWithValue("@result", entity.Result);

            command.ExecuteNonQuery();
        }

        public List<QuantityMeasurementEntity> GetAll()
        {
            List<QuantityMeasurementEntity> list = new();

            using SqlConnection connection = DbConnectionFactory.CreateConnection();
            connection.Open();

            string query = "SELECT Id, Value1,Value2, Unit1,Unit2, Category , Operation , Result FROM QuantityMeasurements";

            using SqlCommand command = new SqlCommand(query, connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new QuantityMeasurementEntity
                {
                    Id = reader.GetInt32(0),
                    Value1 = reader.GetDouble(1),
                    Value2 = reader.GetDouble(2),
                    Unit1 = reader.GetString(3),
                    Unit2 = reader.GetString(4),
                    Category = reader.GetString(5),
                    Operation = reader.GetString(6),
                    Result = reader.GetDouble(7)
                });
            }
            return list;
        }
    }
}