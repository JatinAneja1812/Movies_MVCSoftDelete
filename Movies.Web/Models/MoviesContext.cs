using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Movies.Web.DTOs;

namespace Movies.Web.Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Person> People { get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Prevent cascade delete
            builder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany()
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Composite key
            builder.Entity<MovieActor>()
                .HasKey(a => new { a.PersonId, a.MovieId });

            // Handle the many to many
            builder.Entity<MovieActor>()
                .HasOne(a => a.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(a => a.MovieId);

            builder.Entity<MovieActor>()
                .HasOne(a => a.Person)
                .WithMany()
                .HasForeignKey(a => a.PersonId);

            // Seed data
            builder.Entity<Nationality>().HasData(
                    new Nationality { NationalityId = 1, Title = "British" },
                    new Nationality { NationalityId = 2, Title = "French" },
                    new Nationality { NationalityId = 3, Title = "American" }
                );

            builder.Entity<Person>().HasData(
                new Person { PersonId = 1, NationalityId = 1, Birthday = DateTime.Now, FirstName = "Larry", LastName = "Losser" },
                new Person { PersonId = 2, NationalityId = 1, Birthday = new DateTime(1970, 2, 14), FirstName = "Simon", LastName = "Pegg" },
                new Person { PersonId = 3, NationalityId = 1, Birthday = new DateTime(1976, 7, 19), FirstName = "Benedict", LastName = "Cumberbatch" },
                new Person { PersonId = 4, NationalityId = 2, Birthday = new DateTime(1948, 7, 30), FirstName = "Jean", LastName = "Reno" },
                new Person { PersonId = 5, NationalityId = 3, Birthday = new DateTime(1980, 8, 26), FirstName = "Chris", LastName = "Pine" },
                new Person { PersonId = 6, NationalityId = 3, Birthday = new DateTime(1966, 6, 27), FirstName = "JJ", LastName = "Abrams" }
            );

            builder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "Star Wars: The Force Awakens", ReleaseDate = new DateTime(2015, 12, 18), DirectorId = 6 },
                new Movie { MovieId = 2, Title = "Star Trek", ReleaseDate = new DateTime(2009, 5, 8), DirectorId = null }
            );

            builder.Entity<MovieActor>().HasData(
                new MovieActor { MovieId = 1, PersonId = 2},
                new MovieActor { MovieId = 2, PersonId = 2},
                new MovieActor { MovieId = 2, PersonId = 3}
            ) ;
        }

        public DbSet<Movies.Web.DTOs.ReviewDto> ReviewDto { get; set; }
    }
}
