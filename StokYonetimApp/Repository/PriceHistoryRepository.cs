using Dapper;
using StokYonetimApp.Models;
using System.Data.SqlClient;

namespace StokYonetimApp.Repository
{
    public class PriceHistoryRepository
    {
        private readonly string _connectionString;

        public PriceHistoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<PriceHistory> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();



                return connection.Query<PriceHistory>("SELECT * FROM PriceHistory");
            }
        }




        public void Add(PriceHistory priceHistory)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO PriceHistory (ProductId, OldPrice, NewPrice, ChangeDate) VALUES (@ProductId, @OldPrice, @NewPrice, @ChangeDate)";
                connection.Execute(sql, priceHistory);
            }
        }

      
        public PriceHistory? GetLatestPriceByProductId(int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<PriceHistory>(
                    "SELECT TOP 1 * FROM PriceHistory WHERE ProductId = @ProductId ORDER BY ChangeDate DESC",
                    new { ProductId = productId }).FirstOrDefault();
            }
        }

    }
}