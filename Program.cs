using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ADOStuff.DataAccess;
using ADOStuff.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ADOStuff
{
    class Program
    {
        static void Main()
        {
            var connectionStringKey = "Demo";

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string,string>
                    {
                        [$"ConnectionStrings:{connectionStringKey}"] = "[your connection string]"
                    })
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<ISqlDbConnectionManager>(sp => new SqlDbConnectionManager(config.GetConnectionString(connectionStringKey)));
            services.ConfigureDataServices();

            var diContainer = services.BuildServiceProvider();
            var rowCounter = diContainer.GetRequiredService<IRowCounter>();
            var count = rowCounter.CountRows("[Application].[Countries]");

            Console.WriteLine(count);

            Console.WriteLine("{0}Operation complete!{0}", Environment.NewLine);
        }
    }
}
