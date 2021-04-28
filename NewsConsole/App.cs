using System.Linq;
using NewsConsole.Views;
using Terminal.Gui;
using NewsParser;

namespace NewsConsole
{
    public class App: Window
    {
        private NewsListView _newsListView;
        private OutletListView _outletListView;
        
        public App()
        {
            X = 0;
            Y = 1; // Leave one row for the toplevel menu

            // By using Dim.Fill(), it will automatically resize without manual intervention
            Width = Dim.Fill();
            Height = Dim.Fill();
            
            var parser = new Parser();
            
            InitStaticViews(parser);
            InitialSetup();

            parser.NewsReceived += GotNews;
            parser.StartParser();
        }

        private void InitStaticViews(Parser parser)
        {
            _outletListView = new OutletListView(parser.Outlets.Select(e => e.Name).ToArray())
            {
                X = 1,
                Y = 2,
                
                Height = Dim.Fill(),
                Width = Dim.Percent(20)
            };
            
            _newsListView = new NewsListView()
            {
                X = Pos.Percent(20) + 1,
                Y = 2,
                
                Height = Dim.Fill(),
                Width = Dim.Percent(75)
            };
        }

        private void GotNews(object sender, NewsReceivedEventArgs e)
        {
            _newsListView.News = e.news;
        }

        private void InitialSetup()
        {
            var menu = new MenuBar(new MenuBarItem[] {
                new("_File", new MenuItem [] {
                    new("_Quit", "", () => { if (Quit ()) this.Running = false; })
                }),
                new("_Edit", new MenuItem [] {
                    new("_Copy", "", null),
                    new("C_ut", "", null),
                    new("_Paste", "", null)
                })
            });
            
            Add(menu);
            Add(_newsListView);
            Add(_outletListView);
        }
        
        private static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
            return n == 0;
        }
    }
}