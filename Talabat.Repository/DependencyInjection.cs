using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Repository;


namespace Talabat.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped(typeof(IConnectionMultiplexer), (serviceProvider) =>
            //{
            //    var connectionString = configuration.GetConnectionString("Redis");
            //    var connectionMultiplexerObj = ConnectionMultiplexer.Connect(connectionString!);
            //    return connectionMultiplexerObj;
            //});
            // dont wwrokety addsceopt ebeucase icconemuplesx because take bit time 
            services.AddSingleton(typeof(IConnectionMultiplexer), (serviceProvider) =>
            {
                var connectionString = configuration.GetConnectionString("Redis");
                var connectionMultiplexerObj = ConnectionMultiplexer.Connect(connectionString!);
                return connectionMultiplexerObj;
            });
            return services;
        }

    }


}
