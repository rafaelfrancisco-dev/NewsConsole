using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NewsParser.Models.Responses;

namespace NewsParser.Models.Outlets
{
    public class PublicoOutlet: INewsOutlet
    {
        public Uri Endpoint => new Uri("https://www.publico.pt/api/list/ultimas");
        public string Name => "Público";

        private HttpClient _client;
        private readonly ILogger<PublicoOutlet> _logger;

        public PublicoOutlet(HttpClient client, ILogger<PublicoOutlet> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<InternalNews[]> GetNews()
        {
            try
            {
                await using var responseStream = await _client.GetStreamAsync(Endpoint);
                var news = await JsonSerializer.DeserializeAsync<NewsPublico[]>(responseStream);
                
                _logger.LogDebug($"Got {news?.Length} from {Endpoint}");
            
                return ConvertToInternalNews(news);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong when calling {Endpoint}");

                return null;
            }
        }

        private InternalNews[] ConvertToInternalNews(NewsPublico[] news)
        {
            return news.Select(e => new InternalNews(e.Titulo, e.Subtitulo, e.Descricao, e.Url)).ToArray();
        }
    }
}