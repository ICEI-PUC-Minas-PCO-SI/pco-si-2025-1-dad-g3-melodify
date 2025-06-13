namespace GestaoDeMusicas.DTO
{
    public class AddMusicToPlaylistDto
    {
        // Se null, criamos uma playlist nova
        public int? PlaylistId { get; set; }

        // Usuário é opcional aqui, mas você pode incluir se precisar atribuir dono na criação
        public int? UserId { get; set; }

        // Obrigatório
        public int MusicId { get; set; }
    }

}
