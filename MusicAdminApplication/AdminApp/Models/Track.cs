using System.ComponentModel.DataAnnotations;

namespace AdminApp.Models
{
    public class Track
    {
        public string? Title { get; set; }
        public string? Duration { get; set; }
        public string? Image {  get; set; }
        public Guid AlbumId { get; set; }
        public Guid? ArtistId { get; set; }
        public Album? Album { get; set; }
        public Artist? Artist { get; set; }
        [Required]
        public double Price { get; set; }
        public virtual IEnumerable<TrackInOrder>? TrackInOrders { get; set; }
    }
}
