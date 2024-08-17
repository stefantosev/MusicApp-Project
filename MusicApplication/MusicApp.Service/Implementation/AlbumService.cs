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
    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> albumRepository;

        public AlbumService(IRepository<Album> albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        public void CreateNewAlbum(Album a)
        {
            albumRepository.Insert(a);
        }

        public void DeleteAlbum(Guid? id)
        {
            var a = albumRepository.Get(id);
            albumRepository.Delete(a);  
        }

        public List<Album> GetAllAlbums()
        {
           return albumRepository.GetAll().ToList();    
        }

        public Album GetDetailsForAlbum(Guid? id)
        {
            return albumRepository.Get(id);
        }

        public void UpdateExistingAlbum(Album a)
        {
            albumRepository.Update(a);
        }
    }
}
