using NewsConsole.Views.Main;
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
            
            InitLayout();
            ConfigureStatusBar();
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

            Add(textView);
        }

        private void ConfigureStatusBar()
        {
            Application.Top.StatusBar.Items = new[]
            {
                new StatusItem(Key.Esc, "Esc - Voltar", GoBack),
                new StatusItem(Key.F1, "F1 - Partilhar", null),
                new StatusItem(Key.F2, "F2 - Abrir link", null)
            };
        }

        private void GoBack()
        {
            Application.Top.RemoveAll();
            Application.Top.Add(new MainView(Application.Top));
        }
    }
}