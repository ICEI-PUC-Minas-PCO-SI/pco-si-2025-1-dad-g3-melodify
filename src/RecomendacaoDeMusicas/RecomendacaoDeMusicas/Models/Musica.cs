namespace RecomendacaoDeMusicas.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Genero { get; set; }
        public int AnoLancamento { get; set; }
    }
}
