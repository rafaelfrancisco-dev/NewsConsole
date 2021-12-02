using NewsConsole.Views.SmallViews;
using Terminal.Gui;

namespace NewsConsole.Views.Main;

public partial class MainView
{
    private float _progress;

    private void LogicInit()
    {
        GlobalObjects.Instance.Parser.NewsReceived += GotNews;
        GlobalObjects.Instance.Parser.ProgressReceived += GotProgress;
    }

    private void GetNews()
    {
        GlobalObjects.Instance.Parser.Parse();

        var progress = new LoadProgressView();
        var window = new FrameView
        {
            X = Pos.Percent(40),
            Y = Pos.Percent(40),

            Height = Dim.Fill() - 1,
            Width = Dim.Percent(80)
        };

        window.Add(progress);
        _toplevel.Add(window);
    }
}