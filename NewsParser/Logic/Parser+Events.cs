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

        private void OnProgressReceived(NewsProgressEventArgs e)
        {
            EventHandler<NewsProgressEventArgs> handler = ProgressReceived;
            handler?.Invoke(this, e);
        }
        
        public event EventHandler<NewsReceivedEventArgs> NewsReceived;
        public event EventHandler<NewsProgressEventArgs> ProgressReceived;
    }
    
    public class NewsReceivedEventArgs : EventArgs
    {
        public NewsReceivedEventArgs(InternalNews[] news)
        {
            News = news;
        }

        public InternalNews[] News { get; }
    }

    public class NewsProgressEventArgs : EventArgs
    {
        public NewsProgressEventArgs(float progress)
        {
            Progress = progress;
        }
        
        public float Progress { get; }
    }
}