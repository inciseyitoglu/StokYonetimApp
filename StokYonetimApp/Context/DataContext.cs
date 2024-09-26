using System.Data.SqlClient;
using System.Data;

namespace StokYonetimApp.Context
{
    public class DataContext
    {

        private readonly string? _connectionString;
        public DataContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
