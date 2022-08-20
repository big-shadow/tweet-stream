using Domain.Models;
using TwitterFeed.Contracts;

namespace TwitterFeed.Mappers
{
    public static class HashtagMapper
    {
        public static HashtagVm ToVm(this HashtagDto hashtag)
        {
            return new HashtagVm()
            {
                Id = hashtag.Id,
                Text = hashtag.Text
            };
        }
    }
}