using System;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using News;
using NewsParser.Logic;
using NewsServer.Services;

namespace NewsServer.Server
{
    public class Server
    {
        private readonly Parser _parser;
        private readonly NewsService _newsListService;
        
        private Grpc.Core.Server _server;

        public Server(Parser parser)
        {
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddConsole();
                }
            );
            
            _parser = parser;
            _newsListService = new NewsService(loggerFactory.CreateLogger<NewsService>());
            
            StartServer();
        }

        private void StartServer()
        {
            _parser.NewsReceived += GotNews;
            _server = new Grpc.Core.Server
            {
                Services = { NewsList.BindService(_newsListService) },
                Ports = { new ServerPort("localhost", 5001, ServerCredentials.Insecure) }
            };

            try
            {
                _server.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Console.WriteLine("gRPC Server running");
            }
        }
        
        private void GotNews(object sender, NewsReceivedEventArgs e)
        {
            _newsListService.AvailableNews = e.News;
        }
    }
}