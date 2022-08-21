using BackgroundTaskRunner.Interfaces;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTaskRunner
{
    public class TweetIngestionWorker : BackgroundService
    {
        private readonly IMessageWriter _messageWriter;
        private readonly ITweetIngestionService _ingestionService;
        private readonly IConfiguration _configuration;

        public TweetIngestionWorker(IMessageWriter messageWriter, ITweetIngestionService ingestionService, IConfiguration configuration)
        {
            _messageWriter = messageWriter;
            _ingestionService = ingestionService;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var apiKey = _configuration["TwitterApiKey"];

            try
            {
                _messageWriter.Write("Press Ctrl + C to stop polling the Twitter API for tweets.");

                await _ingestionService.FetchTweetsFeed(apiKey, stoppingToken);
            }
            catch (TaskCanceledException ex)
            {
                _messageWriter.Write($"Worker stopped at {DateTimeOffset.Now}: {ex.Message}");
            }
        }
    }
}