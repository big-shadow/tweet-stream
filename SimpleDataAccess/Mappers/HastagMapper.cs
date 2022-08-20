using Domain.Models;
using SimpleDataAccess.SchemaModels;

namespace SimpleDataAccess.Mappers
{
    public static class HashtagMapper
    {
        public static HashtagDto ToDto(this Hashtag hashtag)
        {
            return new HashtagDto()
            {
                Id = hashtag.Id,
                Text = hashtag.Text
            };
        }
    }
}