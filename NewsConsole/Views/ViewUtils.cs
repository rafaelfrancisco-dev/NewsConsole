using Terminal.Gui;

namespace NewsConsole.Views
{
    public static class ViewUtils
    {
        public static void SetupScrollBar(ListView listview)
        {
            var scrollBar = new ScrollBarView (listview, true);

            scrollBar.ChangedPosition += () => {
                listview.TopItem = scrollBar.Position;
                if (listview.TopItem != scrollBar.Position) {
                    scrollBar.Position = listview.TopItem;
                }
                listview.SetNeedsDisplay ();
            };

            scrollBar.OtherScrollBarView.ChangedPosition += () => {
                listview.LeftItem = scrollBar.OtherScrollBarView.Position;
                if (listview.LeftItem != scrollBar.OtherScrollBarView.Position) {
                    scrollBar.OtherScrollBarView.Position = listview.LeftItem;
                }
                listview.SetNeedsDisplay ();
            };

            listview.DrawContent += (e) =>
            {
                scrollBar.Size = listview.Source.Count - 1;
                scrollBar.Position = listview.TopItem;
                scrollBar.OtherScrollBarView.Size = listview.Maxlength - 1;
                scrollBar.OtherScrollBarView.Position = listview.LeftItem;
            };
        }
    }
}