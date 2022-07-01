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

        public async Task<bool> Create(Genre genre)
        {


            context.genre.Add(genre);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Genre genre)
        {

            this.context.genre.Update(genre);
            await this.context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Delete(Guid id)
        {
            var genre = this.context.genre.FirstAsync(x => x.Id == id);
            this.context.Remove(genre);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
