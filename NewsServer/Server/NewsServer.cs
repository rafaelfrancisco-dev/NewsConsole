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
            _parser.NewsReceived += GotNews;
            
            _newsListService = new NewsService(loggerFactory.CreateLogger<NewsService>());
            StartServer();
        }

        private void StartServer()
        {
            try
            {
                _server = new Grpc.Core.Server
                {
                    Services = { NewsList.BindService(_newsListService) },
                    Ports = { new ServerPort("localhost", 5001, ServerCredentials.Insecure) }
                };

                _server.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("gRPC Server running");
            }
        }

        public void StopServer()
        {
            _server.ShutdownAsync();
        }
        
        private void GotNews(object sender, NewsReceivedEventArgs e)
        {
            _newsListService.AvailableNews = e.News;
        }
    }
}