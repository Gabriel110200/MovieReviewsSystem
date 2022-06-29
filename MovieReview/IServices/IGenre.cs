using Microsoft.AspNetCore.Mvc;
using MovieReview.Models;
using System;
using System.Threading.Tasks;

namespace MovieReview.Interfaces
{
    public interface IGenre
    {
        public Task<IActionResult> Index();

        public Task<IActionResult> Create(Genre genre);

        public Task<IActionResult> Get(Guid id);

        public Task<IActionResult> Edit(Guid id);

        public Task<IActionResult> Update(Genre genre);

        public Task<IActionResult> Delete(int id);






    }
}
