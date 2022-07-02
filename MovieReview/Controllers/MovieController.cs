using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.Interfaces;
using MovieReview.IServices;
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
        private readonly IMovieServices movieServices;

        public CompanyController(AuthDbContext context, IGenreServices genreServices, IMovieServices movieServices)
        {

            this.context = context;
            this.genreServices = genreServices;
            this.movieServices = movieServices;

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

        public async Task<IActionResult> Edit(Guid id)
        {

            await this.movieServices.Get(id);
            var movie = this.context.movies.FirstOrDefaultAsync(x => x.Id == id);

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {

            try
            {

                await this.movieServices.Create(movie);
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

                await this.movieServices.Update(movie);
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
