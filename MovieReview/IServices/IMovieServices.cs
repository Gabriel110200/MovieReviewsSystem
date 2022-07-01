using MovieReview.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReview.IServices
{
    public interface IMovieServices
    {

        public Task<List<Movie>> List();

        public Task<bool> Create(Movie movie);

        public Task<Movie> Get(Guid id);

        public Task<bool> Update(Movie movie);

        public Task<bool> Delete(Guid id);




    }
}
