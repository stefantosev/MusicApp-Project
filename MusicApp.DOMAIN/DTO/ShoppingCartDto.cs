using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<TrackInPlaylist>? Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
