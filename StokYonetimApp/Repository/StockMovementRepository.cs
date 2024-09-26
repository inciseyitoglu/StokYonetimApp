using Dapper;
using StokYonetimApp.Models;
using System.Data.SqlClient;

namespace StokYonetimApp.Repository
{
    public class StockMovementsRepository
    {
        private readonly string _connectionString;

        public StockMovementsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<StockMovements> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<StockMovements>("SELECT * FROM StockMovements");
            }
        }

        public void Add(StockMovements StockMovements)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sql = "INSERT INTO StockMovements (ProductId, MovementType, Quantity, MovementDate) VALUES (@ProductId, @MovementType, @Quantity, @MovementDate)";
                connection.Execute(sql, StockMovements);
            }
        }

     

        public int GetTotalStockByProductId(int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var totalStock = connection.Query<int>(
                    "SELECT COALESCE(SUM(Quantity), 0) FROM StockMovements WHERE ProductId = @ProductId",
                    new { ProductId = productId }).FirstOrDefault();

                return totalStock;
            }
        }

        public IEnumerable<StockMovements> GetAllByDateRange(DateTime startDate, DateTime endDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<StockMovements>(
                    "SELECT * FROM StockMovements WHERE MovementDate BETWEEN @StartDate AND @EndDate",
                    new { StartDate = startDate, EndDate = endDate });
            }
        }
    }
}