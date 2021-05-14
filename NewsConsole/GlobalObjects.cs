using System;
using NewsParser.Logic;
using NewsServer.Server;

namespace NewsConsole
{
    public class GlobalObjects
    {
        private readonly Parser _parser;
        private readonly Server _server;
        
        private static readonly Lazy<GlobalObjects> Lazy = new(() => new GlobalObjects());
        public static GlobalObjects Instance => Lazy.Value;

        public GlobalObjects()
        {
            _parser = new Parser();
            _server = new Server(_parser);
        }

        public Parser Parser => _parser;

        public Server Server => _server;
    }
}