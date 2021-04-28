using System;
using System.Linq;
using System.Threading;
using NStack;
using Terminal.Gui;
using NewsParser;

namespace NewsConsole
{
    public class App: Window
    {
        private Parser _parser;
        
        public App()
        {
            X = 0;
            Y = 1; // Leave one row for the toplevel menu

            // By using Dim.Fill(), it will automatically resize without manual intervention
            Width = Dim.Fill();
            Height = Dim.Fill();
            
            InitialSetup();
            
            // Parser logic
            _parser = new Parser();
            _parser.NewsReceived += GotNews;
            
            _parser.StartParser();
        }

        private void GotNews(object sender, NewsReceivedEventArgs e)
        {
            var list = new ListView(e.news.Select(e => e.title).ToArray())
            {
                X = 1,
                Y = 2,
                Height = Dim.Fill(),
                Width = Dim.Fill(1),
                AllowsMarking = false,
                AllowsMultipleSelection = false
            };
            
            Add(list);
        }

        private void InitialSetup()
        {
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_New", "Creates new file", null),
                    new MenuItem ("_Close", "",null),
                    new MenuItem ("_Quit", "", () => { if (Quit ()) this.Running = false; })
                }),
                new MenuBarItem ("_Edit", new MenuItem [] {
                    new MenuItem ("_Copy", "", null),
                    new MenuItem ("C_ut", "", null),
                    new MenuItem ("_Paste", "", null)
                })
            });
            
            Add(menu);
        }
        
        private static bool Quit()
        {
            var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
            return n == 0;
        }
    }
}