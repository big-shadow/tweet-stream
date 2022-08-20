using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterFeed.Contracts;
using TwitterFeed.Mappers;

namespace TwitterFeed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TweetController : ControllerBase
    {
        private readonly ILogger<TweetController> _logger;
        private readonly ITweetRepository _repo;

        public TweetController(ILogger<TweetController> logger, ITweetRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<TweetVm>> Get()
        {
            return (await _repo.FetchTweets()).Select(x => x.ToVm());
        }
    }
}