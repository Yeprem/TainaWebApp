using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TainaWebApp.ControllerService;
using TainaWebApp.Service;
using TainaWebApp.Service.Services;

namespace TainaWebApp.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void InjectDependencies(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddSingleton<ICacheService, CacheService>()
                .AddSingleton<IDataRepository, DataRepository>(x => new DataRepository(configuration.GetConnectionString("DefaultConnection"), new Logger<DataService>(new LoggerFactory())))
                .AddSingleton<IDataService, DataService>()
                .AddSingleton<IHomeControllerService, HomeControllerService>()
                .AddSingleton<IMapperService, MapperService>();
        }
    }
}
