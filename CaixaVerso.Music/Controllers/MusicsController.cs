using CaixaVerso.MusicApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CaixaVerso.MusicApp.Controllers
{
    public class MusicsController : Controller
    {
        private readonly CaixaDbContext dbContext;

        public MusicsController(CaixaDbContext dbContext)
            => this.dbContext = dbContext;

        public IActionResult Index()
        {
            var musics = dbContext.Musics.Include(x => x.Artist);
            return View(musics);
        }

        public IActionResult Create()
        {
            ViewBag.Artists = GetArtists();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Music music)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Artists = GetArtists();
                return View(music);
            }

            dbContext.Musics.Add(music);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var music = dbContext.Musics.Find(id);
            if (music == null)
                return NotFound();

            ViewBag.Artists = GetArtists();
            return View(music);
        }

        [HttpPost]
        public IActionResult Edit(Music music)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Artists = GetArtists();
                return View(music);
            }

            dbContext.Musics.Update(music);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var music = dbContext.Musics.Find(id);
            if (music == null)
                return NotFound();

            return View(music);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            var music = dbContext.Musics.Find(id);
            if (music == null)
                return NotFound();

            dbContext.Musics.Remove(music);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<SelectListItem> GetArtists()
        {
            var artists = dbContext.Artists.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            artists.Insert(0, new SelectListItem { Value = "", Text = "Selecione um Artista" });

            return artists;
        }
    }
}
