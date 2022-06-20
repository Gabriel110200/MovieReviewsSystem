using System;
using System.ComponentModel.DataAnnotations;

namespace MovieReview.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }



    }
}
