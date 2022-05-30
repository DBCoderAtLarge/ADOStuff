using ADOStuff.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace ADOStuff.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDataServices(this ServiceCollection services)
        {
            services.AddScoped<IItemDeleter, ItemDeleter>();
            services.AddScoped<IRowCounter, RowCounter>();
            services.AddScoped<ISimpleListRetriever, SimpleListRetriever>();
            services.AddSingleton<IDbResolver, DbResolver>();
        }
    }
}
