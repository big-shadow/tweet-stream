using Domain.Models;
using SimpleDataAccess.SchemaModels;
using System.Linq;

namespace SimpleDataAccess.Mappers
{
    public static class TweetMapper
    {
        public static TweetDto ToDto(this Tweet tweet)
        {
            return new TweetDto()
            {
                TwitterId = tweet.TwitterId,
                AuthorId = tweet.AuthorId,
                Text = tweet.Text,
                CreatedAt = tweet.CreatedAt,
                Hashtags = tweet.Hashtags.Select(x => x.ToDto()).ToList()
            };
        }
    }
}