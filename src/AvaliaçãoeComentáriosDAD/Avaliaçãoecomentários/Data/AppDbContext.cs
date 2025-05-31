using Microsoft.EntityFrameworkCore;
using Avaliaçãoecomentários.Models;

namespace Avaliaçãoecomentários.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Avaliação> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Avaliacao)
                .WithMany(a => a.Comentarios)  // Se Avaliação tiver essa coleção
                .HasForeignKey(c => c.AvaliacaoId);
        }
    }
}
