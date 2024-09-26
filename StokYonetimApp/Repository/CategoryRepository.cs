using Dapper;
using StokYonetimApp.Models;
using System.Data.SqlClient;

namespace StokYonetimApp.Repository
{
    public class CategoryRepository
    {
        private readonly string _connectionString;

        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Categories> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Categories>("SELECT * FROM Categories");
            }
        }

        public void Add(Categories category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                connection.Execute(sql, category);
            }
        }

       
    }
}
