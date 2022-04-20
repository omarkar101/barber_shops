using Microsoft.EntityFrameworkCore;
using barber_shops.Models;

namespace barber_shops.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Barber> Barbers { get; set; } = null!;

}
