namespace BarberShopSoftware.Server.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
    }
}
