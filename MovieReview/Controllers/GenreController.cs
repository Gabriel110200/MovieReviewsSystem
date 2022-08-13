using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.Interfaces;
using MovieReview.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Controllers
{
    public class GenreController : Controller
    {

        private readonly AuthDbContext context;
        private readonly IGenreServices genreServices;

        public GenreController(AuthDbContext context, IGenreServices genreServices)
        {

            this.context = context;
            this.genreServices = genreServices;

        }

      

        // GET: GenreController
        public async Task<ActionResult> List()
        {

            var genreList = await context.genre.ToListAsync();
            if (genreList == null) ViewData["NotEmpty"] = "No genre was registered";

            return View(genreList);
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
                this.genreServices.Create(genre);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        [HttpGet("[Controller]/[Action]/{id}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {

                var genre = await this.genreServices.Get(id);
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
        public async Task<ActionResult> Edit(Genre genre)
        {
            try
            {
                await this.genreServices.Update(genre);
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
