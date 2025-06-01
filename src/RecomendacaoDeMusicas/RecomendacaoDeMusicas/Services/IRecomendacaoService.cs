using RecomendacaoDeMusicas.Models;

namespace RecomendacaoDeMusicas.Services
{
    public interface IRecomendacaoService
    {
        IEnumerable<Musica> GetByGenero(string genero);
        IEnumerable<Musica> GetByAno(int ano);
        IEnumerable<Musica> GetByArtista(string artista);
    }
}
