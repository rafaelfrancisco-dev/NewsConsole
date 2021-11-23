using System;
using NewsParser.Logic;
using NewsServer.Server;

namespace NewsConsole
{
    public class GlobalObjects
    {
        private static readonly Lazy<GlobalObjects> Lazy = new(() => new GlobalObjects());
        public static GlobalObjects Instance => Lazy.Value;

        public GlobalObjects()
        {
            Parser = new Parser();
            Server = new Server(Parser);
        }

        public Parser Parser { get; }

        public Server Server { get; }
    }
}