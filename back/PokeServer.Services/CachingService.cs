using Microsoft.Extensions.Caching.Distributed;
using PokeServer.Models.Database;
using PokeServer.Models.Pokemon;
using PokeServer.Services.Interfaces;
using PokeServer.Utils;
using System;
using System.Text;
using System.Threading.Tasks;

namespace PokeServer.Services
{
    public class CachingService<T> : ICachingService<T> where T : class, IEntities
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;
        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = new TimeSpan(0, 5, 0)
            };
        }

        public async Task Save(T obj)
        {
           await _cache.SetAsync(obj.Name, obj.Serialize(), _options);
        }

        public async Task<T> Load(string name)
        {
            var bytesObj = await _cache.GetAsync(name);

            if (bytesObj != null)
            {
                return (T)bytesObj.DeSerialize();
            }
            else
            {
                return null;
            }
        }
    }
}
