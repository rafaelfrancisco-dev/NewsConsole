using Terminal.Gui;

namespace NewsConsole.Views
{
    public class OutletListView : ListView
    {
        public OutletListView(string[] outlets)
        {
            SetSource(outlets);
            
            X = 0;
            Y = 0;

            Height = Dim.Fill();
            Width = Dim.Fill();

            AllowsMarking = true;
            AllowsMultipleSelection = true;
        }
    }
}