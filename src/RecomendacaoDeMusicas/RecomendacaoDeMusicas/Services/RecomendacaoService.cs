using RecomendacaoDeMusicas.Data;
using RecomendacaoDeMusicas.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecomendacaoDeMusicas.Services
{
    public class RecomendacaoService : IRecomendacaoService
    {
        private readonly AppDbContext _context;

        public RecomendacaoService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Musica> GetByGenero(string genero)
        {
            return _context.Musicas
                .Where(musica => musica.Genre != null && musica.Genre.ToLower().Contains(genero.ToLower()))
                .Take(10)
                .ToList();
        }

        public IEnumerable<Musica> GetByAno(int ano)
        {
            return _context.Musicas
                .Where(musica => musica.ReleaseDate.HasValue && musica.ReleaseDate.Value.Year == ano)
                .Take(10)
                .ToList();
        }

        public IEnumerable<Musica> GetByArtista(string artista)
        {
            return _context.Musicas
                .Where(musica => musica.Artist != null && musica.Artist.ToLower().Contains(artista.ToLower()))
                .Take(10)
                .ToList();
        }
    }
}
