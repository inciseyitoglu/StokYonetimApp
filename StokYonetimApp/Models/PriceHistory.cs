namespace StokYonetimApp.Models
{
    public class PriceHistory
    {
        public int PriceHistoryId { get; set; }
        public int ProductId { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public DateTime ChangeDate { get; set; }

        public Products Products { get; set; } 



    }
}
