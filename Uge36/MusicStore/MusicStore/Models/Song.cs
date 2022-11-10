namespace MusicStore.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        //Navigation properties
        public List<Playlist> Playlists { get; set; }
    }
}
