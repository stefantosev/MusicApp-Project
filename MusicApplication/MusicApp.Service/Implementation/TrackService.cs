using MusicApp.Domain;
using MusicApp.Repository.Interface;
using MusicApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Service.Implementation
{
    public class TrackService : ITrackService
    {
        private readonly IRepository<Track> _trackRepository;
        private readonly IRepository<TrackInPlaylist> _playlistRepository;

        public TrackService(IRepository<Track> trackRepository, IRepository<TrackInPlaylist> playlistRepository)
        {
            _trackRepository = trackRepository;
            _playlistRepository = playlistRepository;
        }

        public List<Track> GetAllTracks()
        {
            return _trackRepository.GetAll().ToList();
        }

        public Track GetDetailsForTrack(Guid? id)
        {
            return _trackRepository.Get(id);
        }

        public void CreateNewTrack(Track t)
        {
            _trackRepository.Insert(t);
        }

        public void UpdateExistingTrack(Track t)
        {
            _trackRepository.Update(t);
        }

        public void DeleteTrack(Guid? id)
        {
            var t = _trackRepository.Get(id);
            _trackRepository.Delete(t);
        }

    }
}
