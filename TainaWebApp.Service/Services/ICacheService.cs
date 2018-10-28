using System;

namespace TainaWebApp.Service.Services
{
    public interface ICacheService
    {
        TResult GetOrAdd<TResult>(string key, Func<TResult> func, TimeSpan? duration);
        void Reset(string key);
    }
}
