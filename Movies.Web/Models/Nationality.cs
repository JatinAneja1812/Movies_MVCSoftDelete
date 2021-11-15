using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Web.Models
{
    public class Nationality
    {
        public Nationality()
        {
        }

        public Nationality(string title) : this()
        {
            Title = title;
        }

        public int NationalityId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
