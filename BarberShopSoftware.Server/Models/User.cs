using System.ComponentModel.DataAnnotations;

namespace BarberShopSoftware.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // Default role
    }
}