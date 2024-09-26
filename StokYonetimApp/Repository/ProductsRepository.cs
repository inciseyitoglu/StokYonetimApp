using Dapper;
using StokYonetimApp.Models;
using System.Data.SqlClient;

namespace StokYonetimApp.Repository
{
    public class ProductsRepository
    {

        private readonly string _connectionString;

        public ProductsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Products> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Products>("SELECT * FROM Products");
            }
        }


        public void Add(Products product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO Products (ProductName, ProductPrice, MinimumStockLevel, CategoryId) VALUES (@ProductName, @ProductPrice, @MinimumStockLevel, @CategoryId)";
                connection.Execute(sql, product);
            }
        }


        public IEnumerable<Products> GetAllByCategoryId(int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Products>("SELECT * FROM Products WHERE CategoryId = @CategoryId", new { CategoryId = categoryId });
            }
        }
    }
}