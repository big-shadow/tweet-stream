using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleDataAccess.SchemaModels;
using System;

namespace SimpleDataAccess
{
    public class SimpleDataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }

        public SimpleDataContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_configuration["TweetsSQLiteDBPath"]};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>().ToTable("Tweets");
            modelBuilder.Entity<Tweet>().OwnsMany(x => x.Hashtags);
        }
    }
}