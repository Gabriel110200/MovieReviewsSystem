using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieReview.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<MovieGenre> Genres { get; set; }

    }
}
