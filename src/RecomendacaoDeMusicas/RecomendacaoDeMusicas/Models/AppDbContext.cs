using Microsoft.EntityFrameworkCore;

namespace RecomendacaoDeMusicas.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Musica> Musicas { get; set; }
    }   
}
