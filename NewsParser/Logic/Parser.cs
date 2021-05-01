using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NewsParser.Models;
using NewsParser.Logic.Outlets;

namespace NewsParser.Logic
{
    public partial class Parser
    {
        private readonly List<InternalNews> _news;
        
        private readonly INewsOutlet[] _outlets;
        private HashSet<INewsOutlet> _activeOutlets;

        private List<Task> _tasks;

        public Parser()
        {
            HttpClient client = new HttpClient();
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddConsole();
                }
            );

            _news = new List<InternalNews>();
            
            _outlets = new INewsOutlet[] { new PublicoOutlet(client, loggerFactory.CreateLogger<PublicoOutlet>()), new JornalEcoOutlet(client, loggerFactory.CreateLogger<JornalEcoOutlet>()) };
            _activeOutlets = new HashSet<INewsOutlet>(_outlets);
        }

        public async void Parse()
        {
            _tasks = new List<Task>(_activeOutlets.Select(element => element.GetNews()));
            await Task.WhenAll(_tasks);

            foreach (var task1 in _tasks)
            {
                var task = (Task<InternalNews[]>) task1;
                
                _news.AddRange(task.Result);
                OnNewsReceived(new NewsReceivedEventArgs(_news.ToArray()));
            }
        }

        public void RefreshNews()
        {
            _news.RemoveRange(0, _news.Count);
            Parse();
        }

        public void SetOutlets(INewsOutlet[] outlets)
        {
            if (outlets == null || _activeOutlets.SequenceEqual(outlets))
            {
                return;
            }

            _activeOutlets = new HashSet<INewsOutlet>(outlets);
            OnNewsReceived(new NewsReceivedEventArgs(_news.ToArray()));
            
            RefreshNews();
        }

        private void CancelAllTasks()
        {
            foreach (var task in _tasks)
            {
                
            }
        }
        
        // Properties
        public INewsOutlet[] Outlets => _outlets;

        public List<InternalNews> News => _news;
    }
}