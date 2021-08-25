using System;
using System.IO;
using NewsConsole;
using Spectre.Console;

var path = Utils.CreateTmpFile();
var pathError = Utils.CreateTmpFile();

using var writer = new StreamWriter(path);
using var writerError = new StreamWriter(pathError);

Console.SetOut(writer);
Console.SetError(writerError);

AnsiConsole.Markup("[underline red]Hello[/] World!");

if (!AnsiConsole.Confirm("Run example?"))
{
    return;
}