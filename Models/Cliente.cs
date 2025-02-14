using api_clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace api_clientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
    }
}
public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}