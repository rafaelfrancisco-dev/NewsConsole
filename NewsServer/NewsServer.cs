using NewsParser.Logic;

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

        private void StartServer()
        {
            _parser.Parse();
        }
    }
}