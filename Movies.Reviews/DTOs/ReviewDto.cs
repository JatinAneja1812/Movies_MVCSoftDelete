using Movies.Reviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Reviews.DTOs
{
    public class ReviewDto
    {
        public ReviewDto()
        {
        }

        // Dependency on Review in ReviewDto.
        // Tell me why?
        public ReviewDto(Review r)
        {
            ReviewId = r.ReviewId;
            Author = r.Author;
            Description = r.Description;
            MovieId = r.MovieId;
            Rating = r.Rating;
        }

        public int ReviewId { get; set; }

        public int MovieId { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }
    }
}
