using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleDataAccess.SchemaModels
{
    public class Tweet
    {
        [Key]
        public long TwitterId { get; set; }

        public long AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Hashtag> Hashtags { get; set; }
    }
}