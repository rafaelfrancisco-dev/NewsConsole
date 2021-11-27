namespace NewsParser.Models
{
    public struct InternalNews
    {
        public readonly string Publication;
        public readonly string Title;
        public readonly string? Subtitle;
        public readonly string? Description;
        public readonly string Url;

        public InternalNews(string publication, string title, string? subtitle, string? description, string url)
        {
            Publication = publication;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            Url = url;
        }
    }
}