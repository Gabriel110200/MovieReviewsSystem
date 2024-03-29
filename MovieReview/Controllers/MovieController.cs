﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.Interfaces;
using MovieReview.IServices;
using MovieReview.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Controllers
{
    public class MovieController : Controller
    {

        private readonly AuthDbContext context;
        private readonly IGenreServices genreServices;
        private readonly IMovieServices movieServices;

        public MovieController(AuthDbContext context, IGenreServices genreServices, IMovieServices movieServices)
        {

            this.context = context;
            this.genreServices = genreServices;
            this.movieServices = movieServices;

        }

        [HttpGet("/[Controller]/[Action]")]
        public async Task<IActionResult> List()
        {
            var movies = await this.movieServices.List();
       
            return View(movies);
        }

        [HttpGet("/[Controller]/[Action]")]
        public async Task<IActionResult> Create()
        {
            var genres = await genreServices.List();

            ViewBag.genres = genres;

            return View();
        }


        [HttpPost("/[Controller]/[Action]")]
        public async Task<IActionResult> Create(Movie movie)
        {

            try
            {

                await this.movieServices.Create(movie);
                return RedirectToAction("List");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("/[Controller]/[Action]/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {

            await this.movieServices.Get(id);
            var movie = this.context.movies.FirstOrDefaultAsync(x => x.Id == id);

            return View(movie);
        }


        [HttpPut("[Controller]/[Action]")]
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

        [HttpPost("[Controller]/[Action]/{id}")]
        public IActionResult Delete(Guid id)
        {

            try
            {

                //this.context.movies.Remove(id);

                return View();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
