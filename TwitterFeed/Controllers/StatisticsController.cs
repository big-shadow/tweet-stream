using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TwitterFeed.Contracts;
using TwitterFeed.Mappers;

namespace TwitterFeed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<TweetController> _logger;
        private readonly ITweetRepository _repo;

        public StatisticsController(ILogger<TweetController> logger, ITweetRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<StatisticsVm> Get()
        {
            return (await _repo.FetchStatistics()).ToVm();
        }
    }
}