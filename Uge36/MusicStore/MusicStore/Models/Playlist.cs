namespace MusicStore.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public int PlaylistCount { get; set; }
        public DateTime PlaylistLastUpdated { get; set; }
        //Navigation properties
        public List<Song> SongsOnList { get; set; }
    }
}
