﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MusicApp.Domain.Identity
{
    public class User : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public virtual UserPlaylist Playlists { get; set; }
        public virtual ICollection<Order>? Order { get; set;}
    }
}
