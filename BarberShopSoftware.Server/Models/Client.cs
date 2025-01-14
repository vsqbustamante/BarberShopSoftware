using System.ComponentModel.DataAnnotations;

namespace BarberShopSoftware.Server.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public bool IsWaiting { get; set; } = true;
        public int? AssignedBarberId { get; set; }
    }
}
