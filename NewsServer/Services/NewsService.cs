using Microsoft.Extensions.Logging;

namespace NewsServer.Services
{
    public class NewsService
    {
        private readonly ILogger _logger;
        
        public NewsService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<NewsService>();
        }
        
        
    }
}