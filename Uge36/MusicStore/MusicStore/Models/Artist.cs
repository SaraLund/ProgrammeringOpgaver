namespace MusicStore.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        //Navigation properties
        public List<Album> ArtistAlbums { get; set; }
        public List<Song> Songs { get; set; }
    }
}
