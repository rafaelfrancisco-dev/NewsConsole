using System;
using NewsParser.Logic;

namespace NewsConsole
{
    public class GlobalObjects
    {
        private readonly Parser _parser;

        private static readonly Lazy<GlobalObjects> Lazy = new(() => new GlobalObjects());
        public static GlobalObjects Instance => Lazy.Value;

        public GlobalObjects()
        {
            _parser = new Parser();
        }

        public Parser Parser => _parser;
    }
}