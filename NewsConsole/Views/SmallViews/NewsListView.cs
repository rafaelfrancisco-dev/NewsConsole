using System.Linq;
using NewsParser.Models;
using Terminal.Gui;

namespace NewsConsole.Views.SmallViews
{
    public class NewsListView: ListView
    {
        private InternalNews[] _news;

        public NewsListView()
        {
            X = 0;
            Y = 0;

            Height = Dim.Fill();
            Width = Dim.Fill();
            
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