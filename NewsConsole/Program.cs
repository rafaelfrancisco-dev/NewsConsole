using NewsConsole.Views.MainView;
using Terminal.Gui;

Application.Init();

var top = Application.Top;
top.Add(new MainView(top));

Application.Run();