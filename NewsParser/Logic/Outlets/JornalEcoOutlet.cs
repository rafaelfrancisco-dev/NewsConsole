using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NewsParser.Models;

namespace NewsParser.Logic.Outlets
{
    public class JornalEcoOutlet: INewsOutlet
    {
        public Uri Endpoint => new("https://eco.sapo.pt/wp-json/eco/v1/items");
        public string Name => "Jornal ECO";

        private readonly HttpClient _client;
        private readonly ILogger<JornalEcoOutlet> _logger;
        
        public JornalEcoOutlet(HttpClient client, ILogger<JornalEcoOutlet> logger)
        {
            _client = client;
            _logger = logger;
        }
        
        public async Task<InternalNews[]> GetNews()
        {
            try
            {
                await using var responseStream = await _client.GetStreamAsync(Endpoint);
                var news = await JsonSerializer.DeserializeAsync<NewsJornalEco[]>(responseStream);
                
                _logger.LogDebug($"Got {news?.Length} from {Endpoint}");
            
                return ConvertToInternalNews(news);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong when calling {Endpoint}");

                return null;
            }
        }
        
        private InternalNews[] ConvertToInternalNews(NewsJornalEco[] news)
        {
            return news.Select(e => new InternalNews(Name, e.Title.Long, e.Title.Short, e.Body, e.Links.WebUri)).ToArray();
        }
    }
}