using HomeInc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeInc.Infraestructure.DataBase
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }
        
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
