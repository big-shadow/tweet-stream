using System.Collections.Generic;

namespace TwitterFeed.Contracts
{
    public class StatisticsVm
    {
        public long TotalNumberOfTweetsReceived { get; set; }
        public List<TopHashtagVm> TopTenHashtags { get; set; }
    }

    public class TopHashtagVm
    {
        public string Hashtag { get; set; }
        public long Uses { get; set; }
    }
}