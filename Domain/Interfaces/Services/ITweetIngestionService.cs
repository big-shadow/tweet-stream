using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ITweetIngestionService
    {
        public Task FetchTweetsFeed(string apiKey, CancellationToken stoppingToken);
    }
}