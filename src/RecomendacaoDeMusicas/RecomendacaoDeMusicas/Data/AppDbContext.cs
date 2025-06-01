using Microsoft.EntityFrameworkCore;
using RecomendacaoDeMusicas.Models;

namespace RecomendacaoDeMusicas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Musica> Musicas { get; set; }
    }
}
