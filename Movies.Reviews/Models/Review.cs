using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Reviews.Models
{
    public class Review
    {
        public Review()
        {
            IsDeleted = false;
        }

        public int ReviewId { get; set; }

        public int MovieId { get; set; }

        public int Rating { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        public bool IsDeleted { get; set; }
    }
}
