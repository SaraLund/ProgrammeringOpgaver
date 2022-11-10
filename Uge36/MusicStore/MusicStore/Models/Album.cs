namespace MusicStore.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string AlbumArtUrl { get; set; }
        //Navigation properties
        public List<Song> SongsOnAlbum { get; set; }
        public Artist AlbumArtist { get; set; }
        public Genre AlbumGenre { get; set; }
    }
}
