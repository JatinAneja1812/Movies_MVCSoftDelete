using Microsoft.EntityFrameworkCore;


namespace Movies.Reviews.Models
{
    public class ReviewsContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }

        public ReviewsContext(DbContextOptions<ReviewsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed data
            builder.Entity<Review>().HasData(
                new Review { ReviewId = 1, MovieId = 1, Rating = 5, Description = "Amazing, must see!", Author = "James Fairbairn"},
                new Review { ReviewId = 2, MovieId = 1, Rating = 4, Description = "Quality film!", Author = "Zafar Khan"}
            );
        }
    }
}
