using Microsoft.EntityFrameworkCore;

namespace apiRest.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
       
    }

}
