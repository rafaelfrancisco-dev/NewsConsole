using System.Collections.Generic;
using Terminal.Gui;

namespace NewsConsole.Views.SmallViews
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

            MarkAllElements();
        }

        private void MarkAllElements()
        {
            for (int i = 0; i < Source.Count; i++)
            {
                Source.SetMark(i, true);
            }
        }

        public string[] GetMarkedElements()
        {
            var markedArray = new List<string>();

            for (int i = 0; i < Source.Count; i++)
            {
                if (Source.IsMarked(i))
                {
                    markedArray.Add((string)Source.ToList()[i]);
                }
            }

            return markedArray.ToArray();
        }
    }
}