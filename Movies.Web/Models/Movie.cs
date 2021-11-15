using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Web.Models
{
    public class Movie
    {
        public Movie()
        {
        }

        public Movie(string title, DateTime releaseDate, int directorId) : this()
        {
            Title = title;
            ReleaseDate = releaseDate;
            DirectorId = directorId;
        }

        [Required]
        public int MovieId { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int? DirectorId { get; set; }

        public Person Director { get; set; }

        public ICollection<MovieActor> Actors { get; set; }
    }
}
