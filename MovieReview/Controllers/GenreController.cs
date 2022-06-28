using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Controllers
{
    public class GenreController : Controller
    {

        private readonly AuthDbContext context;

        public GenreController(AuthDbContext context)
        {

            this.context = context;

        }

        public GenreController()
        {
        }

        // GET: GenreController
        public async Task<ActionResult> Index()
        {

            var genreList = await context.genre.ToListAsync();

            if (genreList == null) ViewData["NotEmpty"] = "No genre was registered";

            return View(genreList);
        }

        // GET: GenreController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {

            var genre = await context.genre.FindAsync(id);

            if (genre == null) throw new Exception("Genre not found");

            return View(genre);
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            try
            {
                context.genre.Add(genre);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {


                var genre = context.genre.FindAsync(id);

                if (genre == null) throw new Exception("Gênero não encontrado");

                return View(genre);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            try
            {
                context.genre.Update(genre);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
