using api_clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace api_clientes.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
