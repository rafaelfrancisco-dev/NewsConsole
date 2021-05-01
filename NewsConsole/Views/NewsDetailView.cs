using NewsParser.Models;
using Terminal.Gui;

namespace NewsConsole.Views
{
    public class NewsDetailView: View
    {
        private InternalNews _newsElement;
        
        public NewsDetailView(InternalNews newsElement)
        {
            X = 0;
            Y = 0;
            
            Height = Dim.Fill();
            Width = Dim.Fill();

            _newsElement = newsElement;
            InitLayout();
        }

        private void InitLayout()
        {
            var scrollView = new ScrollView()
            {
                X = 0,
                Y = 1,
                
                Height = Dim.Fill(),
                Width = Dim.Fill()
            };
            
            var textView = new TextView()
            {
                X = 0,
                Y = 0,
                
                Height = Dim.Fill(),
                Width = Dim.Fill(),
                
                Text = _newsElement.description
            };
            
            scrollView.Add(textView);
            Add(scrollView);
        }
    }
}