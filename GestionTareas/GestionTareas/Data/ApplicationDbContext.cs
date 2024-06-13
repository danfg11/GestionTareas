using GestionTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTareas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TareaItem> TareasItems { get; set; }
    }
}
