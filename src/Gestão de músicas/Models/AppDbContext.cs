using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 

        public DbSet<Music> Musics { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistMusic> PlaylistMusics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlaylistMusic>()
                .HasKey(pm => new { pm.PlaylistId, pm.MusicId });

            modelBuilder.Entity<PlaylistMusic>()
                .HasOne(pm => pm.Playlist)
                .WithMany(p => p.PlaylistMusics)
                .HasForeignKey(pm => pm.PlaylistId);

            modelBuilder.Entity<PlaylistMusic>()
                .HasOne(pm => pm.Music)
                .WithMany()
                .HasForeignKey(pm => pm.MusicId);
        }
    }
}
