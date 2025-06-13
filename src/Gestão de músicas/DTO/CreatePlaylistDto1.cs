namespace GestaoDeMusicas.DTO
{
    public class CreatePlaylistDto1
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public List<PlaylistMusicDto> PlaylistMusics { get; set; }
    }
}
