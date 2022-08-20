using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleDataAccess.SchemaModels
{
    public class Tweet
    {
        [Key]
        public int TwitterId { get; set; }

        public int AuthorId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual List<Hashtag> Hashtags { get; set; }
    }
}