namespace BarberShopSoftware.Server.DTO
{
    public class ProductDTO
    {
        public required string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
