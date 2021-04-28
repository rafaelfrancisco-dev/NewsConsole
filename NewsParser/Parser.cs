using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using NewsParser.Models;
using NewsParser.Models.Outlets;

namespace NewsParser
{
    public class Parser
    {
        private List<InternalNews> _news;
        private INewsOutlet[] _outlets;

        public Parser()
        {
            HttpClient client = new HttpClient();
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddFilter("Microsoft", LogLevel.Warning)
                        .AddFilter("System", LogLevel.Warning)
                        .AddFilter("NewsParser", LogLevel.Debug)
                        .AddConsole();
                }
            );

            _news = new List<InternalNews>();
            _outlets = new INewsOutlet[] {new PublicoOutlet(client, loggerFactory.CreateLogger<PublicoOutlet>())};
        }

        public async void StartParser()
        {
            foreach (var newsOutlet in _outlets)
            {
                _news.AddRange(await newsOutlet.GetNews());
            }
        }

        public void RefreshNews()
        {
            _news.RemoveRange(0, _news.Count);
            StartParser();
        }
    }
}