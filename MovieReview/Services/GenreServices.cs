using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReview.Interfaces;
using MovieReview.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReview.Services
{
    public class GenreServices : IGenreServices
    {

        private readonly AuthDbContext context;

        public GenreServices(AuthDbContext context)
        {
            this.context = context;



        }

        public async Task<List<Genre>> List()
        {

            var genreList = await context.genre.ToListAsync();

            return genreList;
        }

        // GET: GenreController/Details/5
        public async Task<Genre> Get(Guid id)
        {

            var genre = await context.genre.FindAsync(id);
            return genre;

        }


    }
}
