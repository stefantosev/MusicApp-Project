using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using MusicApp.Repository;
using MusicApp.Service.Interface;

namespace MusicApp.Web.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackService _trackService;
        private readonly IAlbumService _albumService;
        private readonly IArtistService _artistService;

        public TracksController(ITrackService trackService, IAlbumService albumService, IArtistService artistService)
        {
            this._trackService = trackService;
            _albumService = albumService;
            _artistService = artistService;
        }



        // GET: Albums
        public async Task<IActionResult> Index()
        {
           
            ViewBag.AlbumId = new SelectList(_albumService.GetAllAlbums(), "Id", "Title"); 

           
            ViewBag.ArtistId = new SelectList(_artistService.GetAllArtists(), "Id", "Name"); 

            return View(_trackService.GetAllTracks());
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _trackService.GetDetailsForTrack(id);

           
            ViewBag.AlbumId = new SelectList(_albumService.GetAllAlbums(), "Id", "Title"); 

     
            ViewBag.ArtistId = new SelectList(_artistService.GetAllArtists(), "Id", "Name");

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            
            ViewBag.AlbumId = new SelectList(_albumService.GetAllAlbums(), "Id", "Title");

           
            ViewBag.ArtistId = new SelectList(_artistService.GetAllArtists(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Track album)
        {
            if (ModelState.IsValid)
            {
                album.Id = Guid.NewGuid();
                _trackService.CreateNewTrack(album);
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }




        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _trackService.GetDetailsForTrack(id);
           
            ViewBag.AlbumId = new SelectList(_albumService.GetAllAlbums(), "Id", "Title");

            
            ViewBag.ArtistId = new SelectList(_artistService.GetAllArtists(), "Id", "Name");

            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Track album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _trackService.UpdateExistingTrack(album);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = _trackService.GetDetailsForTrack(id);
            
            ViewBag.AlbumId = new SelectList(_albumService.GetAllAlbums(), "Id", "Title"); 

            
            ViewBag.ArtistId = new SelectList(_artistService.GetAllArtists(), "Id", "Name"); 

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _trackService.DeleteTrack(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
