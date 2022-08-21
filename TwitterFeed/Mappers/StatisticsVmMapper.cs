using Domain.Models;
using System.Linq;
using TwitterFeed.Contracts;

namespace TwitterFeed.Mappers
{
    public static class StatisticsVmMapper
    {
        public static StatisticsVm ToVm(this StatisticsDto stats)
        {
            return new StatisticsVm()
            {
                TotalNumberOfTweetsReceived = stats.TotalNumberOfTweetsReceived,
                TopTenHashtags = stats.TopTenHashtags.Select(x => x.ToVm()).ToList()
            };
        }

        public static TopHashtagVm ToVm(this TopHashtagDto topHashtag)
        {
            return new TopHashtagVm()
            {
                Hashtag = topHashtag.Hashtag,
                Uses = topHashtag.Uses
            };
        }
    }
}