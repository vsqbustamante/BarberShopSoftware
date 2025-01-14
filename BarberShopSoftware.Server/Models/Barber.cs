namespace BarberShopSoftware.Server.Models
{
    public class Barber
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsAvailable { get; set; }
        public List<Client> CurrentClients { get; set; } = new List<Client>();
    }
}
