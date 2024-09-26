namespace StokYonetimApp.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int MinimumStockLevel { get; set; }
        public int CategoryId { get; set; }

        public Categories Categories { get; set; } 

    }
}
