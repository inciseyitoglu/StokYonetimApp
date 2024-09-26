namespace StokYonetimApp.Models
{
    public class StockMovements
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public string MovementType { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }

        public Products Products { get; set; } 
    }
}
