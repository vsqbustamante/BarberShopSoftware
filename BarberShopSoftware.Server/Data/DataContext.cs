using BarberShopSoftware.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BarberShopSoftware.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Barber> Barbers { get; set; }

        public DbSet<Sales> Sales { get; set; }
    }
}


