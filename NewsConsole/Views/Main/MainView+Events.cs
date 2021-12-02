using System.Linq;
using NewsParser.Logic;
using Terminal.Gui;

namespace NewsConsole.Views.Main;

public partial class MainView
{
    private void GotNews(object? sender, NewsReceivedEventArgs e)
    {
        if (_newsListView == null) return;

        _newsListView.News = e.News;
        ViewUtils.SetupScrollBar(_newsListView);
    }

    private void GotProgress(object? sender, NewsProgressEventArgs e)
    {
        _progress = e.Progress;
    }

    private void OutletChanged(ListViewItemEventArgs e)
    {
        GlobalObjects.Instance.Parser
            .SetOutlets(
                GlobalObjects.Instance.Parser.Outlets
                    .Where(element =>
                        _outletListView != null && _outletListView.GetMarkedElements().Contains(element.Name)).ToArray()
            );
    }

    private void NewsItemSelected(ListViewItemEventArgs e)
    {
        var newsItem = GlobalObjects.Instance.Parser.News
            .First(element => element.Title == e.Value.ToString());

        var newsDetailWindow = new Window(newsItem.Title)
        {
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };

        newsDetailWindow.Add(new NewsDetailView(newsItem));

        RemoveAll();
        Add(newsDetailWindow);
    }
}