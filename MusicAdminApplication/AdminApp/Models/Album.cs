﻿namespace AdminApp.Models
{
    public class Album
    {
        public Guid Id { get; set; }    
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid ArtistId { get; set; }

        public Artist? Artist { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }
}
