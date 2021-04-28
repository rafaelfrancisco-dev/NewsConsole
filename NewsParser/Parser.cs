using System;
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
        private readonly INewsOutlet[] _outlets;

        public Parser()
        {
            HttpClient client = new HttpClient();
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddConsole();
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
                OnNewsReceived(new NewsReceivedEventArgs(_news.ToArray()));
            }
        }

        public void RefreshNews()
        {
            _news.RemoveRange(0, _news.Count);
            StartParser();
        }

        public INewsOutlet[] Outlets => _outlets;

        protected virtual void OnNewsReceived(NewsReceivedEventArgs e)
        {
            EventHandler<NewsReceivedEventArgs> handler = NewsReceived;
            handler?.Invoke(this, e);
        }
        
        public event EventHandler<NewsReceivedEventArgs> NewsReceived;
    }
    
    public class NewsReceivedEventArgs : EventArgs
    {
        public NewsReceivedEventArgs(InternalNews[] news)
        {
            this.news = news;
        }

        public InternalNews[] news { get; }
    }
}