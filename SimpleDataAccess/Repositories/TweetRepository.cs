using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleDataAccess.Mappers;
using SimpleDataAccess.SchemaModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDataAccess.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly IConfiguration _configuration;

        public TweetRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<TweetDto>> FetchTweets()
        {
            using (var context = new SimpleDataContext(_configuration))
            {
                var tweets = context.Tweets
                    .AsQueryable()
                    .Include(x => x.Hashtags)
                    .Select(x => x.ToDto());

                return await tweets.ToListAsync();
            }
        }

        public async Task<TweetDto> CreateTweet(TweetDto tweet)
        {
            using (var context = new SimpleDataContext(_configuration))
            {
                var newTweet = new Tweet
                {
                    TwitterId = tweet.TwitterId,
                    AuthorId = tweet.AuthorId,
                    Text = tweet.Text,
                    CreatedAt = tweet.CreatedAt,
                    Hashtags = tweet.Hashtags.Select(x => new Hashtag()
                    {
                        Id = x.Id,
                        Text = x.Text
                    }).ToList()
                };

                context.Tweets.Add(newTweet);
                await context.SaveChangesAsync();

                return newTweet.ToDto();
            }
        }
    }
}