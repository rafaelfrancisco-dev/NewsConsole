using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using News;
using NewsParser.Models;

namespace NewsServer.Services
{
    public class NewsService : NewsList.NewsListBase
    {
        private readonly ILogger _logger;
        private InternalNews[] _availableNews;

        public NewsService(ILogger<NewsService> logger)
        {
            _logger = logger;
        }

        public InternalNews[] AvailableNews
        {
            set => _availableNews = value;
        }

        public override Task<NewsListReply> News(NewsListRequest request, ServerCallContext context)
        {
            var reply = new NewsListReply();

            foreach (var element in _availableNews)
            {
                var internalCopy = element;

                var newElement = new NewsListElement
                {
                    Title = internalCopy.Title,
                    Subtitle = internalCopy.Subtitle,
                    Description = internalCopy.Description,
                    Publication = internalCopy.Publication,
                    Url = internalCopy.Url
                };

                reply.Elements.Add(newElement);
            }

            _logger.LogInformation($"Sending reply to {request}");
            return Task.FromResult(reply);
        }
    }
}