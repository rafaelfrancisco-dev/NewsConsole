using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Logging;
using NewsParser.Models;

namespace NewsParser.Logic.Outlets
{
    public class RtpOutlet: INewsOutlet
    {
        public Uri Endpoint => new("https://www.rtp.pt/noticias/rss");
        public string Name => "RTP";
        
        private readonly ILogger<RtpOutlet> _logger;

        public RtpOutlet(ILogger<RtpOutlet> logger)
        {
            _logger = logger;
        }

        public Task<InternalNews[]> GetNews()
        {
            SyndicationFeed feed = null;

            try
            {
                using var reader = XmlReader.Create(Endpoint.OriginalString);
                feed = SyndicationFeed.Load(reader);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong when calling {Endpoint}");
            }

            if (feed != null)
            {
                var list = new List<InternalNews>();
                
                foreach (var element in feed.Items)
                {
                    list.Add(new InternalNews(
                        Name, 
                        element.Title.Text, 
                        element.Categories
                            .Select(e => e.Name)
                            .Aggregate("", (acc, eS) => acc.Concat($" {eS}").ToString()),
                        element.Summary.Text,
                        element.Links.First().Uri.ToString()
                        ));
                }

                return Task.FromResult(list.ToArray());
            }
            
            return null;
        }
    }
}