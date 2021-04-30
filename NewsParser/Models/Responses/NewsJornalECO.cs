using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Links
{
    [JsonPropertyName("shortUrl")] public string ShortUrl { get; set; }

    [JsonPropertyName("webUri")] public string WebUri { get; set; }
}

public class Wide
{
    [JsonPropertyName("urlTemplate")] public string UrlTemplate { get; set; }

    [JsonPropertyName("urlTemplate_small")]
    public string UrlTemplateSmall { get; set; }

    [JsonPropertyName("height")] public int Height { get; set; }

    [JsonPropertyName("width")] public int Width { get; set; }

    [JsonPropertyName("credit")] public string Credit { get; set; }

    [JsonPropertyName("caption")] public string Caption { get; set; }

    [JsonPropertyName("alt")] public string Alt { get; set; }
}

public class Square
{
    [JsonPropertyName("urlTemplate")] public string UrlTemplate { get; set; }

    [JsonPropertyName("urlTemplate_small")]
    public string UrlTemplateSmall { get; set; }

    [JsonPropertyName("height")] public int Height { get; set; }

    [JsonPropertyName("width")] public int Width { get; set; }

    [JsonPropertyName("credit")] public string Credit { get; set; }

    [JsonPropertyName("caption")] public string Caption { get; set; }

    [JsonPropertyName("alt")] public string Alt { get; set; }
}

public class Images
{
    [JsonPropertyName("wide")] public Wide Wide { get; set; }

    [JsonPropertyName("square")] public Square Square { get; set; }
}

public class Image
{
    [JsonPropertyName("urlTemplate")] public string UrlTemplate { get; set; }

    [JsonPropertyName("width")] public int Width { get; set; }

    [JsonPropertyName("height")] public int Height { get; set; }

    [JsonPropertyName("credit")] public string Credit { get; set; }

    [JsonPropertyName("caption")] public string Caption { get; set; }

    [JsonPropertyName("alt")] public string Alt { get; set; }

    [JsonPropertyName("title")] public string Title { get; set; }
}

public class Contributor
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("slug")] public string Slug { get; set; }

    [JsonPropertyName("role")] public string Role { get; set; }

    [JsonPropertyName("image")] public Image Image { get; set; }

    [JsonPropertyName("uri")] public string Uri { get; set; }
}

public class Logo
{
    [JsonPropertyName("urlTemplate")] public string UrlTemplate { get; set; }

    [JsonPropertyName("width")] public int Width { get; set; }

    [JsonPropertyName("height")] public int Height { get; set; }

    [JsonPropertyName("credit")] public string Credit { get; set; }

    [JsonPropertyName("caption")] public string Caption { get; set; }
}

public class Sponsor
{
    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("logo")] public Logo Logo { get; set; }
}

public class Tag
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("slug")] public string Slug { get; set; }

    [JsonPropertyName("webTitle")] public string WebTitle { get; set; }

    [JsonPropertyName("sponsor")] public Sponsor Sponsor { get; set; }

    [JsonPropertyName("isObsession")] public bool IsObsession { get; set; }

    [JsonPropertyName("images")] public Images Images { get; set; }
}

public class Metadata
{
    [JsonPropertyName("commentCount")] public int CommentCount { get; set; }

    [JsonPropertyName("shareCount")] public int ShareCount { get; set; }

    [JsonPropertyName("contributors")] public List<Contributor> Contributors { get; set; }

    [JsonPropertyName("tags")] public List<Tag> Tags { get; set; }
}

public class Title
{
    [JsonPropertyName("short")] public string Short { get; set; }

    [JsonPropertyName("long")] public string Long { get; set; }
}

public class Item
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("slug")] public string Slug { get; set; }

    [JsonPropertyName("pubDate")] public DateTime PubDate { get; set; }

    [JsonPropertyName("lastModified")] public DateTime LastModified { get; set; }

    [JsonPropertyName("links")] public Links Links { get; set; }

    [JsonPropertyName("images")] public Images Images { get; set; }

    [JsonPropertyName("lead")] public string Lead { get; set; }

    [JsonPropertyName("metadata")] public Metadata Metadata { get; set; }

    [JsonPropertyName("title")] public Title Title { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("liveblog")] public object Liveblog { get; set; }

    [JsonPropertyName("premium")] public bool Premium { get; set; }
}

public class FeaturedMedia
{
    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("image")] public Image Image { get; set; }

    [JsonPropertyName("graphic")] public object Graphic { get; set; }
}

public class RelatedArticle
{
    [JsonPropertyName("item")] public Item Item { get; set; }

    [JsonPropertyName("featuredMedia")] public FeaturedMedia FeaturedMedia { get; set; }

    [JsonPropertyName("sponsor")] public object Sponsor { get; set; }

    [JsonPropertyName("text")] public string Text { get; set; }
}

public class Instagram
{
    [JsonPropertyName("url")] public string Url { get; set; }
}

public class Attachment
{
    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("related-article")] public RelatedArticle RelatedArticle { get; set; }

    [JsonPropertyName("image")] public Image Image { get; set; }

    [JsonPropertyName("instagram")] public Instagram Instagram { get; set; }
}

public class NewsJornalEco
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("slug")] public string Slug { get; set; }

    [JsonPropertyName("lead")] public string Lead { get; set; }

    [JsonPropertyName("body")] public string Body { get; set; }

    [JsonPropertyName("attachments")] public List<Attachment> Attachments { get; set; }

    [JsonPropertyName("sponsor")] public object Sponsor { get; set; }

    [JsonPropertyName("pubDate")] public DateTime PubDate { get; set; }

    [JsonPropertyName("lastModified")] public DateTime LastModified { get; set; }

    [JsonPropertyName("links")] public Links Links { get; set; }

    [JsonPropertyName("images")] public Images Images { get; set; }

    [JsonPropertyName("metadata")] public Metadata Metadata { get; set; }

    [JsonPropertyName("title")] public Title Title { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("premium")] public bool Premium { get; set; }
}