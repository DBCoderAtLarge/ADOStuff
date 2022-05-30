using System;
using Microsoft.Extensions.DependencyInjection;

namespace ADOStuff.DataAccess
{
    public class DbResolver : IDbResolver
    {
        private readonly IServiceProvider _services;

        public DbResolver(IServiceProvider services)
        {
            _services = services;
        }

        public ISqlDbConnectionManager GetDbConnectionManager()
        {
            return _services.GetRequiredService<ISqlDbConnectionManager>();
        }
    }
}