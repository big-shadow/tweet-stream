using Microsoft.EntityFrameworkCore;
using SimpleDataAccess.SchemaModels;
using System;

namespace SimpleDataAccess
{
    public class SimpleDataContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Tweets.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Hashtag>().ToTable("Hashtags");

            modelBuilder.Entity<Tweet>().ToTable("Tweets");
            modelBuilder.Entity<Tweet>().OwnsMany(x => x.Hashtags);
            modelBuilder.Entity<Tweet>().HasData(new Tweet
            {
                TwitterId = 1,
                AuthorId = 100,
                Text = "Haha!",
                CreatedAt = DateTime.UtcNow,
            }, new Tweet
            {
                TwitterId = 2,
                AuthorId = 101,
                Text = "Boo!",
                CreatedAt = DateTime.UtcNow,
            });
        }
    }
}