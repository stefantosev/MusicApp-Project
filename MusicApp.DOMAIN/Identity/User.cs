using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;


namespace MusicApp.Domain.Identity
{
    public class User : IdentityUser
    {

        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public ICollection<UserPlaylist> Playlists { get; set; }
    }
}
