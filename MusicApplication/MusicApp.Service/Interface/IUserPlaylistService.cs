using MusicApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Service.Interface
{
    public interface IUserPlaylistService
    {
        UserPlaylist getUserPlaylistInfo(string userId); // shopping cart ShoppingCartDto
        bool deleteTrackFromPlaylist(string userId, Guid productId);
        bool order(string userId);
        bool AddToUserPlaylistConfirmed(TrackInPlaylist model, string userId);
    }
}
