using Microsoft.EntityFrameworkCore;
using MovieReview.IServices;
using MovieReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.Services
{
    public class MovieServices : IMovieServices
    {

        private readonly AuthDbContext context;


        public MovieServices(AuthDbContext context)
        {

            this.context = context;


        }

        public async Task<bool> Create(Movie movie)
        {

            if (this.context.movies.Any(x => x.Title == movie.Title))
                throw new Exception("Movie's already registered inside the database");


            this.context.Add(movie);
            await this.context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Movie>> movies()
        {
            return await this.context.movies.ToListAsync();
        }


        public async Task<bool> Update(Movie movie)
        {
            var newMovie = this.context.movies.Where(x => x.Id == movie.Id).First();

            if (newMovie == null) throw new Exception("Movie not found!!");

            this.context.Update(movie);
            await this.context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {


            var movie = this.context.movies.First(x => x.Id == id);
            this.context.Remove(movie);
            await this.context.SaveChangesAsync();
            return true;




        }

        public async Task<List<Movie>> List()
        {
            return await this.context.movies.ToListAsync();
        }


    }
}
