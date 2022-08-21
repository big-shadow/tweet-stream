using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleDataAccess.SchemaModels
{
    public class Hashtag
    {
        [Key]
        public int Id { get; set; }

        public long TweetId { get; set; }
        public string Text { get; set; }

        [ForeignKey("TweetId")]
        public Tweet Tweet { get; set; }
    }
}