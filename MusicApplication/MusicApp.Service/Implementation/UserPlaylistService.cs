using MusicApp.Domain;
using MusicApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Service.Implementation
{
    public class UserPlaylistService : IUserPlaylistService
    {
        public bool AddToUserPlaylistConfirmed(TrackInPlaylist model, string userId)
        {
            throw new NotImplementedException();
        }

        public bool deleteTrackFromPlaylist(string userId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public UserPlaylist getUserPlaylistInfo(string userId)
        {
            throw new NotImplementedException();
        }

        public bool order(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
