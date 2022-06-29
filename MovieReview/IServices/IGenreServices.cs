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

        /*
        public Task<IActionResult> Create(Genre genre);

        public Task<IActionResult> Edit(Guid id);

        public Task<IActionResult> Update(Genre genre);

        public Task<IActionResult> Delete(int id); */






    }
}
