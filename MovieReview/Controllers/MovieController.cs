using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.Interfaces;
using MovieReview.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Controllers
{
    public class CompanyController : Controller
    {

        private readonly AuthDbContext context;
        private readonly IGenreServices genreServices;

        public CompanyController(AuthDbContext context, IGenreServices genreServices)
        {

            this.context = context;
            this.genreServices = genreServices;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var genres = await genreServices.List();

            return View(genres);
        }

        public IActionResult Edit(Guid id)
        {
            var movie = this.context.movies.FirstOrDefaultAsync(x => x.Id == id);

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {



            try
            {


                if (ModelState.IsValid)
                {

                    context.movies.Add(movie);
                    await context.SaveChangesAsync();

                }

                return View();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(Movie movie)
        {

            try
            {


                var newMovie = this.context.movies.FirstOrDefaultAsync(x => x.Id == movie.Id);

                if (newMovie == null) throw new Exception("Filme não existe");

                this.context.Update(movie);

                await context.SaveChangesAsync();

                return View();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IActionResult Delete(Movie movie)
        {

            try
            {

                this.context.movies.Remove(movie);

                return View();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
