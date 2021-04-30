using System;
using NewsParser;

namespace NewsServer
{
    public class NewsServer
    {
        private Parser _parser;
        
        public NewsServer()
        {
            _parser = new Parser();
            StartServer();
        }

        public void StartServer()
        {
            _parser.Parse();
        }
    }
}