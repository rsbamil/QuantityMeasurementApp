using Microsoft.Data.SqlClient;
using QuantityMeasurementAppModelLayer.Utils;

namespace QuantityMeasurementAppRepositoryLayer.Utils
{
    public static class DbConnectionFactory
    {
        private static readonly string? connectionString = ConnectionConfig.ConnectionString;

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}