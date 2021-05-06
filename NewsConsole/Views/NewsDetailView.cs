using System.Diagnostics;
using System.Runtime.InteropServices;
using NewsConsole.Views.Main;
using NewsConsole.Views.SmallViews;
using NewsParser.Models;
using Terminal.Gui;

namespace NewsConsole.Views
{
    public class NewsDetailView: View
    {
        private readonly InternalNews _newsElement;
        
        public NewsDetailView(InternalNews newsElement)
        {
            X = 0;
            Y = 0;
            
            Height = Dim.Fill();
            Width = Dim.Fill();

            _newsElement = newsElement;
            
            ConfigureStatusBar();
            InitLayout();
        }

        private void InitLayout()
        {
            var textView = new TextView
            {
                X = 0,
                Y = 0,
                
                Height = Dim.Fill(),
                Width = Dim.Fill(),
                
                Text = _newsElement.description,
                WordWrap = true
            };

            var progressBar = new LoadProgressView
            {
                X = Pos.Center(),
                Y = Pos.Bottom(textView) - 10,
                
                Height = 10,
                Width = Dim.Percent(25)
            };

            Add(textView, progressBar);
        }

        private void ConfigureStatusBar()
        {
            Application.Top.StatusBar.Items = new[]
            {
                new StatusItem(Key.Esc, "Esc - Voltar", GoBack),
                new StatusItem(Key.F2, "F2 - Abrir link", OpenBrowser)
            };
        }

        private void GoBack()
        {
            Application.Top.RemoveAll();
            Application.Top.Add(new MainView(Application.Top));
        }

        private void OpenBrowser()
        {
            var url = _newsElement.url;
            
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}