namespace AdminApp.Models
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<Album>? Albums { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }
}
