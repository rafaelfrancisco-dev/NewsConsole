using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using NewsParser.Models;
using NewsParser.Models.Outlets;

namespace NewsParser
{
    public class Parser
    {
        private readonly List<InternalNews> _news;
        
        private readonly INewsOutlet[] _outlets;
        private HashSet<INewsOutlet> _activeOutlets;

        public Parser()
        {
            HttpClient client = new HttpClient();
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddConsole();
                }
            );

            _news = new List<InternalNews>();
            
            _outlets = new INewsOutlet[] { new PublicoOutlet(client, loggerFactory.CreateLogger<PublicoOutlet>()), new JornalEcoOutlet(client, loggerFactory.CreateLogger<JornalEcoOutlet>()) };
            _activeOutlets = new HashSet<INewsOutlet>(_outlets);
        }

        public async void Parse()
        {
            foreach (var newsOutlet in _activeOutlets)
            {
                _news.AddRange(await newsOutlet.GetNews());
                OnNewsReceived(new NewsReceivedEventArgs(_news.ToArray()));
            }
        }

        public void RefreshNews()
        {
            _news.RemoveRange(0, _news.Count);
            Parse();
        }

        public void SetOutlets(INewsOutlet[] outlets)
        {
            if (outlets == null || _activeOutlets.SequenceEqual(outlets))
            {
                return;
            }
            
            foreach (var newsOutlet in _activeOutlets.Except(outlets))
            {
                RemoveNewsFromOutlet(newsOutlet);
            }

            _activeOutlets = new HashSet<INewsOutlet>(outlets);
            OnNewsReceived(new NewsReceivedEventArgs(_news.ToArray()));
            
            RefreshNews();
        }

        private void RemoveNewsFromOutlet(INewsOutlet outlet)
        {
            _news.RemoveAll(element => element.publication == outlet.Name);
        }
        
        // Properties
        public INewsOutlet[] Outlets => _outlets;

        // Events
        private void OnNewsReceived(NewsReceivedEventArgs e)
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
            this.News = news;
        }

        public InternalNews[] News { get; }
    }
}