using System.Linq;
using NewsConsole.Views.SmallViews;
using NewsParser.Logic;
using Terminal.Gui;

namespace NewsConsole.Views.Main
{
    public partial class MainView: View
    {
        private readonly Toplevel _toplevel;
        
        private NewsListView _newsListView;
        private OutletListView _outletListView;

        public MainView(Toplevel toplevel)
        {
            X = 0;
            Y = 1; // Leave one row for the toplevel menu

            Width = Dim.Fill();
            Height = Dim.Fill();

            _toplevel = toplevel;

            InitMenus();
            InitStaticViews(GlobalObjects.Instance.Parser);

            if (GlobalObjects.Instance.Parser.News.Count > 0)
            {
                _newsListView.News = GlobalObjects.Instance.Parser.News.ToArray();
                ViewUtils.SetupScrollBar(_newsListView);
            }
            
            GlobalObjects.Instance.Parser.NewsReceived += GotNews;
            GlobalObjects.Instance.Parser.ProgressReceived += GotProgress;
            
            GlobalObjects.Instance.Parser.Parse();
        }

        // Layout methods
        private void InitStaticViews(Parser parser)
        {
            _outletListView = new OutletListView(parser.Outlets.Select(e => e.Name).ToArray());
            var outletWindow = new FrameView("Fontes")
            {
                X = 0,
                Y = 0,
                
                Height = Dim.Fill() - 1,
                Width = Dim.Percent(20)
            };

            _newsListView = new NewsListView();
            var newslistWindow = new FrameView("Notícias")
            {
                X = Pos.Percent(20),
                Y = 0,
                
                Height = Dim.Fill() - 1,
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
                    new("_Quit", "", () => { if (Quit ()) Application.Top.Running = false; })
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
                Items = new []
                {
                    new StatusItem(Key.F3, "F3 - Ligar Servidor", null),
                    new StatusItem(Key.F5, "F5 - Actualizar", GlobalObjects.Instance.Parser.RefreshNews),
                    new StatusItem(Key.F12, "F12 - Sair", () => Quit())
                }
            };
            
            _toplevel.Add(menu, statusBar);
        }
        
        private static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
            return n == 0;
        }
    }
}