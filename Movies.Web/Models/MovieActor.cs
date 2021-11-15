using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Web.Models
{
    public class MovieActor
    {
        public MovieActor()
        {
        }

        public int PersonId { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public Person Person { get; set; }
    }
}
