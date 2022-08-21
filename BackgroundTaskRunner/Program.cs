using BackgroundTaskRunner.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleDataAccess.Repositories;
using System.Threading.Tasks;

namespace BackgroundTaskRunner
{
    internal static class Program
    {
        private static Task Main(string[] args)
        {
            var confBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var config = confBuilder.Build();

            var builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureServices(services => services.AddHostedService<TweetIngestionWorker>()
                .AddScoped<IMessageWriter, MessageWriter>()
                .AddScoped<ITweetIngestionService, TweetIngestionService>()
                .AddScoped<ITweetRepository, TweetRepository>());

            var host = builder.Build();
            return host.RunAsync();
        }
    }
}