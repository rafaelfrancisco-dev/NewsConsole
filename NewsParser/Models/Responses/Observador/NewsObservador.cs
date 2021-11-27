using System;
using System.Text.Json.Serialization;

namespace NewsParser.Models.Responses.Observador;

public class NewsObservador
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("publish_date")] public DateTimeOffset PublishDate { get; set; }

    [JsonPropertyName("tag")] public Tag Tag { get; set; }

    [JsonPropertyName("lead")] public string Lead { get; set; }

    [JsonPropertyName("image")] public string Image { get; set; }

    [JsonPropertyName("image_16x9")] public string Image16X9 { get; set; }

    [JsonPropertyName("url")] public Uri Url { get; set; }

    [JsonPropertyName("authors")] public Author[] Authors { get; set; }
}

public class Author
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("image")] public Uri Image { get; set; }
}

public enum Tag
{
    Poltica,
    Sade,
    Sociedade
}