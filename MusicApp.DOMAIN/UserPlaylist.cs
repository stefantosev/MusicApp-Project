using MusicApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain
{
    public class UserPlaylist : BaseEntity
    {

        //ShoppingCart 

        public string? Name { get; set; }
        public string? OwnerId { get; set; }
        public User? Owner { get; set; }

        //public DateTime CreatedAt { get; set; }
        
        public virtual ICollection<TrackInPlaylist>? TracksInPlaylist { get; set; }
    }
}
