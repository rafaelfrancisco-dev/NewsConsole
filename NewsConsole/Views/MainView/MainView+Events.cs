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
            Application.Top.Add(new NewsDetailView());
        }
    }
}