using System.Collections.Generic;

namespace Domain.Models
{
    public class StatisticsDto
    {
        public long TotalNumberOfTweetsReceived { get; set; }
        public List<TopHashtagDto> TopTenHashtags { get; set; }
    }

    public class TopHashtagDto
    {
        public string Hashtag { get; set; }
        public long Uses { get; set; }
    }
}