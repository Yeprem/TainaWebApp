using Microsoft.Extensions.Caching.Memory;
using System;
using TainaWebApp.Service.Services;

namespace TainaWebApp.Service
{
    class CacheEntry<TResult>
    {
        public string Key { get; set; }
        public TResult Value { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }

    /* Currenlty cache is reset when we call the method with the same key
       It checks if it is expired and renews the value in the cache
       If there is no call to the method with an already existing key for a long time, cache object will stay in memory
       We can implement a cahce reset feature which checks the expiration dates and clears them when the cache is expired
    */

    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public TResult GetOrAdd<TResult>(string key, Func<TResult> result, TimeSpan? duration)
        {
            if (_memoryCache.TryGetValue(key, out CacheEntry<TResult> item) && (!item.ExpirationDate.HasValue || item.ExpirationDate.Value > DateTime.UtcNow))
            {
                return item.Value;
            }
            else
            {
                var value = result();

                if (value != null)
                {
                    var cacheDuration = duration ?? TimeSpan.MaxValue;

                    var cacheEntity = new CacheEntry<TResult>
                    {
                        Key = key,
                        Value = value,
                        ExpirationDate = duration.HasValue ? DateTime.UtcNow.AddSeconds(duration.Value.TotalSeconds) : default(DateTime?)
                    };
                    _memoryCache.Set(key, cacheEntity);
                }

                return value;
            }
        }

        public void Reset(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}