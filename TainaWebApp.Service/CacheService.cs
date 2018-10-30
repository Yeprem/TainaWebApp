using Microsoft.Extensions.Caching.Memory;
using System;
using TainaWebApp.Service.Services;

namespace TainaWebApp.Service
{
    /* 
       Currenlty cache is reset when it expires or when Reset method called.
       If this system is going to be used in distirbuted systems, there must be cache reset listeners.
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
            if (_memoryCache.TryGetValue(key, out TResult item))
            {
                return item;
            }
            else
            {
                var value = result();

                if (value != null)
                {
                    /*
                        One day is used as a default cache duration, to not serve out-dated data to users for a long time.
                     */
                    var cacheDuration = duration ?? TimeSpan.FromDays(1);
                    _memoryCache.Set(key, value, absoluteExpirationRelativeToNow: cacheDuration);
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