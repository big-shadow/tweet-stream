using Domain.Models;
using System.Linq;
using TwitterFeed.Contracts;

namespace TwitterFeed.Mappers
{
    public static class TweetVmMapper
    {
        public static TweetVm ToVm(this TweetDto tweet)
        {
            return new TweetVm()
            {
                TwitterId = tweet.TwitterId,
                AuthorId = tweet.AuthorId,
                Text = tweet.Text,
                CreatedAt = tweet.CreatedAt,
                Hashtags = tweet.Hashtags.Select(x => x.ToVm()).ToList()
            };
        }
    }
}