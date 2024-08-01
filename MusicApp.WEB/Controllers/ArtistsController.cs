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
    public class ArtistsController : Controller
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public IActionResult Index()
        {
            return View(_artistService.GetAllArtists());
        }

        // GET: Artist/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = _artistService.GetDetailsForArtist(id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Artist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                artist.Id = Guid.NewGuid();
                _artistService.CreateNewArtist(artist);
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }


        // GET: Artist/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = _artistService.GetDetailsForArtist(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Artist artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _artistService.UpdateExistingArtist(artist);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artist/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tracks = _artistService.GetDetailsForArtist(id);
            if (tracks == null)
            {
                return NotFound();
            }

            return View(tracks);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _artistService.DeleteArtist(id);
            return RedirectToAction(nameof(Index));
        }

    }
}