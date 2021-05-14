using NewsParser.Logic;

namespace NewsServer
{
    public class NewsServer
    {
        private readonly Parser _parser;
        
        public NewsServer(Parser parser)
        {
            _parser = parser;
            StartServer();
        }

        private void StartServer()
        {
            if (_parser.News.Count == 0)
            {
                _parser.Parse();
            }
            
            
        }
    }
}