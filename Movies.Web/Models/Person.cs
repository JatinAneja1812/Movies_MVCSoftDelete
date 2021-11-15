using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movies.Web.Models
{
    public class Person
    {
        public Person()
        {
        }

        public int PersonId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        public int NationalityId { get; set; }

        public Nationality Nationality { get; set; }

    }
}
