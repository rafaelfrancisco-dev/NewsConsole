using System;
using System.Diagnostics;
using System.IO;
using NewsConsole;
using NewsConsole.Views.Main;
using Terminal.Gui;

var path = Utils.CreateTmpFile();
var pathError = Utils.CreateTmpFile();

using var writer = new StreamWriter(path);
using var writerError = new StreamWriter(pathError);

Console.SetOut(writer);
Console.SetError(writerError);

Application.Init();

var top = Application.Top;
top.Add(new MainView(top));

Application.Run();

if (Debugger.IsAttached)
{
    Process.Start(path);
    Process.Start(pathError);
}