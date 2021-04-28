using System;
using System.Threading.Tasks;

namespace NewsParser.Models
{
    public interface INewsOutlet
    {
        public Uri Endpoint { get; }
        
        public Task<InternalNews[]> GetNews();
    }
}