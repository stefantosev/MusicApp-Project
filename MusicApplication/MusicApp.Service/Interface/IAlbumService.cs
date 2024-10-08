﻿using MusicApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Service.Interface
{
    public interface IAlbumService
    {

        List<Album> GetAllAlbums();
        Album GetDetailsForAlbum(Guid? id);
        void CreateNewAlbum(Album a);
        void UpdateExistingAlbum(Album a);
        void DeleteAlbum(Guid? id);
    }
}
