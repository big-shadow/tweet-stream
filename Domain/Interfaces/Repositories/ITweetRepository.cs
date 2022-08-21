using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ITweetRepository
    {
        public Task<List<TweetDto>> FetchTweets();
        public Task<TweetDto> CreateTweet(TweetDto tweet);
    }
}