using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleDataAccess.SchemaModels;

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
            modelBuilder.Entity<Tweet>().OwnsMany(p => p.Hashtags, a =>
            {
                a.WithOwner(d => d.Tweet).HasForeignKey("TweetId");
            });
        }
    }
}