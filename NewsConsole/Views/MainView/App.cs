using System.Linq;
using NewsConsole.Views.SmallViews;
using NewsParser.Logic;
using Terminal.Gui;

namespace NewsConsole.Views.MainView
{
    public partial class App: Window
    {
        private NewsListView _newsListView;
        private OutletListView _outletListView;

        private readonly Parser _parser;
        
        public App()
        {
            X = 0;
            Y = 1; // Leave one row for the toplevel menu

            Width = Dim.Fill();
            Height = Dim.Fill();
            
            _parser = new Parser();
            
            InitMenus();
            InitStaticViews(_parser);

            _parser.NewsReceived += GotNews;
            _parser.Parse();

            Title = "NewsConsole";
        }

        // Layout methods
        private void InitStaticViews(Parser parser)
        {
            _outletListView = new OutletListView(parser.Outlets.Select(e => e.Name).ToArray());
            var outletWindow = new FrameView("Fontes")
            {
                X = 1,
                Y = 1,
                
                Height = Dim.Fill(),
                Width = Dim.Percent(20)
            };

            _newsListView = new NewsListView();
            var newslistWindow = new FrameView("Notícias")
            {
                X = Pos.Percent(20) + 1,
                Y = 1,
                
                Height = Dim.Fill(),
                Width = Dim.Percent(80)
            };
            
            outletWindow.Add(_outletListView);
            newslistWindow.Add(_newsListView);

            Add(outletWindow, newslistWindow);

            _outletListView.SelectedItemChanged += OutletChanged;
            _newsListView.OpenSelectedItem += NewsItemSelected;
        }
        
        private void InitMenus()
        {
            var menu = new MenuBar(new MenuBarItem[] {
                new("_Ficheiro", new MenuItem [] {
                    new("_Quit", "", () => { if (Quit ()) this.Running = false; })
                }),
                new("_Editar", new MenuItem [] {
                    new("_Copy", "", null),
                    new("C_ut", "", null),
                    new("_Paste", "", null)
                }),
                new("_Ajuda", new MenuItem []
                {
                    new("A_cerca", "", null)
                })
            });

            var statusBar = new StatusBar()
            {
                Items = new [] { new StatusItem(Key.F5, "Actualizar", _parser.RefreshNews) }
            };
            
            Add(menu, statusBar);
        }
        
        private static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
            return n == 0;
        }
    }
}