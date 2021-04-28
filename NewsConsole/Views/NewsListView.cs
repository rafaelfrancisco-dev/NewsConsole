using System.Linq;
using NewsParser.Models;
using Terminal.Gui;

namespace NewsConsole.Views
{
    public class NewsListView: ListView
    {
        private InternalNews[] _news;

        public NewsListView()
        {
            AllowsMarking = false;
            AllowsMultipleSelection = false;
        }

        public InternalNews[] News
        {
            set
            {
                _news = value;
                
                SetSource(_news.Select(e => e.title).ToArray());
                SetNeedsDisplay();
            }
        }
    }
}