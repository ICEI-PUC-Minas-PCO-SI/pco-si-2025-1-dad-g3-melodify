using Microsoft.EntityFrameworkCore;
using Autenticacao_e_Gestao_do_Usuario.Models;

namespace Autenticacao_e_Gestao_do_Usuario.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Status> Status { get; set; }


    }
}
