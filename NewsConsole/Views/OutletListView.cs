using Terminal.Gui;

namespace NewsConsole.Views
{
    public class OutletListView : ListView
    {
        public OutletListView(string[] outlets)
        {
            SetSource(outlets);

            AllowsMarking = true;
            AllowsMultipleSelection = true;
        }
    }
}