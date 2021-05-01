using System.Linq;
using NewsParser.Logic;
using Terminal.Gui;

namespace NewsConsole.Views.MainView
{
    public partial class MainView
    {
        private void GotNews(object sender, NewsReceivedEventArgs e)
        {
            _newsListView.News = e.News;
        }

        private void OutletChanged(ListViewItemEventArgs e)
        {
            _parser
                .SetOutlets(_parser.Outlets
                .Where(element => _outletListView.GetMarkedElements().Contains(element.Name)).ToArray());
        }

        private void NewsItemSelected(ListViewItemEventArgs e)
        {
            var newsItem = _parser.News.First(element => element.title == e.Value.ToString());
            
            var newsDetailWindow = new Window(newsItem.title);
            newsDetailWindow.Add(new NewsDetailView(newsItem));
            
            RemoveAll();
            Add(newsDetailWindow);
        }
    }
}