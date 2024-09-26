namespace StokYonetimApp.Models
{
    public class ProductStockViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal CurrentPrice { get; set; }
        public int TotalStock { get; set; }
        public int MinimumStockLevel { get; set; } 
    }
}
