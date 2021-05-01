using System;
using NewsParser.Models;

namespace NewsParser.Logic
{
    public partial class Parser
    {
        private void OnNewsReceived(NewsReceivedEventArgs e)
        {
            EventHandler<NewsReceivedEventArgs> handler = NewsReceived;
            handler?.Invoke(this, e);
        }
        
        public event EventHandler<NewsReceivedEventArgs> NewsReceived;
    }
    
    public class NewsReceivedEventArgs : EventArgs
    {
        public NewsReceivedEventArgs(InternalNews[] news)
        {
            News = news;
        }

        public InternalNews[] News { get; }
    }
}