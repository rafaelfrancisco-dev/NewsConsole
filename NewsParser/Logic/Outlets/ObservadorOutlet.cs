using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NewsParser.Models;
using NewsParser.Models.Responses.Observador;

namespace NewsParser.Logic.Outlets;

public class ObservadorOutlet : INewsOutlet
{
    public Uri Endpoint => new("https://observador.pt/wp-json/obs_api/v4/news/widget");
    public string Name => "Observador";

    private readonly HttpClient _client;
    private readonly ILogger<ObservadorOutlet> _logger;

    public ObservadorOutlet(HttpClient client, ILogger<ObservadorOutlet> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<InternalNews[]> GetNews()
    {
        try
        {
            await using var responseStream = await _client.GetStreamAsync(Endpoint);
            var news = await JsonSerializer.DeserializeAsync<NewsObservador[]>(responseStream);

            _logger.LogDebug($"Got {news?.Length} from {Endpoint}");

            return ConvertToInternalNews(news);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Something went wrong when calling {Endpoint}");

            return Array.Empty<InternalNews>();
        }
    }

    private InternalNews[] ConvertToInternalNews(IEnumerable<NewsObservador> news)
    {
        return news.Select(e => new InternalNews(Name, e.Title, null, null, e.Url.AbsoluteUri)).ToArray();
    }
}