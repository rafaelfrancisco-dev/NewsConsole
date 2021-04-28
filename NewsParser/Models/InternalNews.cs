namespace NewsParser.Models
{
    public struct InternalNews
    {
        public string title;
        public string subtitle;
        public string description;
        public string url;

        public InternalNews(string title, string subtitle, string description, string url)
        {
            this.title = title;
            this.subtitle = subtitle;
            this.description = description;
            this.url = url;
        }
    }
}