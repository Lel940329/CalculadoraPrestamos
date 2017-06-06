using System.Data.Entity;

namespace CalcularPrestamos.Models
{
    public class CX : DbContext
    {
        public DbSet<CI> CI { get; set; }
        public DbSet<PT> PT { get; set; }
    }

}
