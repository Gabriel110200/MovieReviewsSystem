using Microsoft.AspNetCore.Mvc;
using MovieReview.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieReview.Interfaces
{
    public interface IGenreServices
    {
        public Task<List<Genre>> List();

        public Task<Genre> Get(Guid id);

        public Task<bool> Create(Genre genre);

        public Task<bool> Update(Genre genre);

        public Task<bool> Delete(Guid id);






    }
}
