using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain
{
    public class Track : BaseEntity
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid AlbumId { get; set; }
        public Guid ArtistId { get; set; }
        public Album Album { get; set; }
        public Artist Artist { get; set; }
        public ICollection<TrackInPlaylist> TracksInPlaylist { get; set; }
        public virtual IEnumerable<TrackInOrder>? TrackInOrders { get; set; }
    }
}
