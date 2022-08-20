using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using SimpleDataAccess.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDataAccess.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        public async Task<List<TweetDto>> FetchTweets()
        {
            using (var context = new SimpleDataContext())
            {
                var tweets = context.Tweets
                    .AsQueryable()
                    .Include(x => x.Hashtags)
                    .Select(x => x.ToDto());

                return await tweets.ToListAsync();
            }
        }

        public TweetDto CreateTweet()
        {
            using (var context = new SimpleDataContext())
            {
                //var customer = new Customer
                //{
                //    CustomerId = 1,
                //    FirstName = "Elizabeth",
                //    LastName = "Lincoln",
                //    Address = "23 Tsawassen Blvd."
                //};

                //context.Customers.Add(customer);
                context.SaveChanges();
            }

            return null;
        }
    }
}