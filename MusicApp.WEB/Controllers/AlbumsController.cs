using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using MusicApp.Repository;
using MusicApp.Service.Implementation;
using MusicApp.Service.Interface;

namespace MusicApp.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumService albumService;
        private readonly IArtistService artistService;
        
        public AlbumsController(IAlbumService albumService, IArtistService artistService)
        {
            this.albumService = albumService;
            this.artistService = artistService;
        }



        // GET: Albums
        public async Task<IActionResult> Index()
        {
            ViewBag.ArtistId = new SelectList(artistService.GetAllArtists(), "Id", "Name");
            return View(albumService.GetAllAlbums());
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = albumService.GetDetailsForAlbum(id);
            ViewBag.ArtistId = new SelectList(artistService.GetAllArtists(), "Id", "Name");
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
           
            ViewBag.ArtistId = new SelectList(artistService.GetAllArtists(), "Id", "Name"); 


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                album.Id = Guid.NewGuid();
                albumService.CreateNewAlbum(album);
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

            var album = albumService.GetDetailsForAlbum(id);
            
            ViewBag.ArtistId = new SelectList(artistService.GetAllArtists(), "Id", "Name");

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
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,ReleaseDate,ArtistId,Id")] Album album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    albumService.UpdateExistingAlbum(album);
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

            var album = albumService.GetDetailsForAlbum(id);
            ViewBag.ArtistId = new SelectList(artistService.GetAllArtists(), "Id", "Name");
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
            albumService.DeleteAlbum(id);   
            return RedirectToAction(nameof(Index));
        }

    }
}
