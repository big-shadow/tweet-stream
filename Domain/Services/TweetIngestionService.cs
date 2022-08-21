using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class TweetIngestionService : ITweetIngestionService
    {
        private readonly ITweetRepository _repo;

        public TweetIngestionService(ITweetRepository repo)
        {
            _repo = repo;
        }

        public class TwitterResponse
        {
            public TwitterTweetResponse data { get; set; }
        }

        public class TwitterTweetResponse
        {
            public string author_id { get; set; }
            public string id { get; set; }
            public string text { get; set; }
            public DateTime created_at { get; set; }
        }

        public async Task FetchTweetsFeed(string apiKey, CancellationToken stoppingToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stream = await client.GetStreamAsync("https://api.twitter.com/2/tweets/sample/stream?tweet.fields=created_at&expansions=author_id");

                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream && !stoppingToken.IsCancellationRequested)
                    {
                        var json = reader.ReadLine();
                        var wrapper = JsonConvert.DeserializeObject<TwitterResponse>(json);

                        if (wrapper == null)
                        {
                            Thread.Sleep(500);
                            continue;
                        }

                        // Service writes to stdout, but with more time I'd inject a logging dependency. obvs.
                        // Pro: This lets you code test reviewers see an ingestion rate
                        Console.WriteLine($"Ingesting Tweet {wrapper.data.id}");

                        var text = wrapper.data.text.Trim();
                        var hashtags = new List<HashtagDto>();

                        foreach (var match in new Regex(@"#\w+").Matches(text).ToList())
                            hashtags.Add(new HashtagDto() { Text = match.Value.ToLowerInvariant() });

                        await _repo.CreateTweet(new TweetDto()
                        {
                            TwitterId = long.Parse(wrapper.data.id),
                            AuthorId = long.Parse(wrapper.data.author_id),
                            Text = text,
                            CreatedAt = wrapper.data.created_at,
                            Hashtags = hashtags
                        });
                    }
                }
            }
        }
    }
}