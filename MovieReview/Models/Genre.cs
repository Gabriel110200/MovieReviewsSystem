using System;
using System.Collections.Generic;

namespace MovieReview.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public IEnumerable<MovieGenre> Movies { get; set; }


    }
}
