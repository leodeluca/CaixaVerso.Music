using CaixaVerso.MusicApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace CaixaVerso.MusicApp.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly CaixaDbContext dbContext;

        public ArtistsController(CaixaDbContext dbContext)
            => this.dbContext = dbContext;

        public IActionResult Index()
            => View(dbContext.Artists);

        public IActionResult Create()
            => View();

        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid)
                return View(artist);

            var isNameDuplicated = dbContext.Artists.Any(t => t.Name == artist.Name);
            if (isNameDuplicated)
            {
                ModelState.AddModelError(nameof(Artist.Name), "O Nome do Artista deve ser único.");
                return View(artist);
            }

            dbContext.Artists.Add(artist);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var artist = dbContext.Artists.Find(id);
            if (artist == null)
                return NotFound();

            return View(artist);
        }

        [HttpPost]
        public IActionResult Edit(Artist artist)
        {
            dbContext.Update(artist);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var artist = dbContext.Artists.Find(id);
            if (artist == null)
                return NotFound();

            return View(artist);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var artist = dbContext.Artists.Find(id);
            if (artist == null)
                return NotFound();

            dbContext.Artists.Remove(artist);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
