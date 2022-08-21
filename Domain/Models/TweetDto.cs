using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class TweetDto
    {
        public long TwitterId { get; set; }
        public long AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<HashtagDto> Hashtags { get; set; }
    }
}