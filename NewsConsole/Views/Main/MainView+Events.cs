using System.Linq;
using NewsParser.Logic;
using Terminal.Gui;

namespace NewsConsole.Views.Main
{
    public partial class MainView
    {
        private void GotNews(object sender, NewsReceivedEventArgs e)
        {
            _newsListView.News = e.News;
            ViewUtils.SetupScrollBar(_newsListView);
        }

        private void OutletChanged(ListViewItemEventArgs e)
        {
            GlobalObjects.Instance.Parser
                .SetOutlets(GlobalObjects.Instance.Parser.Outlets
                .Where(element => _outletListView.GetMarkedElements().Contains(element.Name)).ToArray());
        }

        private void NewsItemSelected(ListViewItemEventArgs e)
        {
            var newsItem = GlobalObjects.Instance.Parser.News.First(element => element.title == e.Value.ToString());
            
            var newsDetailWindow = new Window(newsItem.title)
            {
                Width = Dim.Fill(),
                Height = Dim.Fill() - 1
            };
            newsDetailWindow.Add(new NewsDetailView(newsItem));
            
            RemoveAll();
            Add(newsDetailWindow);
        }
    }
}