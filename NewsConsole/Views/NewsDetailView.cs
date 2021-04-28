using Terminal.Gui;

namespace NewsConsole.Views
{
    public class NewsDetailView: Toplevel
    {
        public NewsDetailView()
        {
            X = 0;
            Y = 0;
            
            Height = Dim.Fill();
            Width = Dim.Fill();
            
            InitLayout();
        }

        private void InitLayout()
        {
            var menu = new MenuBar (new MenuBarItem [] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_Close", "", () => { 
                        Application.RequestStop ();
                    })
                }),
            });
            
            Add(menu);
        }
    }
}