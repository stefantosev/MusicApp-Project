using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain.DTO
{
    public class AddToCart
    {
        public Guid SelectedTrackId { get; set; }
        public string? SelectedTrackName { get; set; }
        public int Quantity { get; set; }
    }
}
