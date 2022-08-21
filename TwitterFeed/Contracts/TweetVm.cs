using System;
using System.Collections.Generic;

namespace TwitterFeed.Contracts
{
    public class TweetVm
    {
        public long TwitterId { get; set; }
        public long AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<HashtagVm> Hashtags { get; set; }
    }
}