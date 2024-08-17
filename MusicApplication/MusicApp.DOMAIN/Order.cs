using MusicApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Domain
{
    public class Order : BaseEntity
    {
        public Guid userId { get; set; }
        public User Owner { get; set; }
        public IEnumerable<TrackInOrder> TracksInOrders { get; set; }
    }
}
