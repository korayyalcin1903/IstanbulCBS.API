using IstanbulCBS.Data.Repositories.Context;
using IstanbulCBS.Data.Repositories.Implementation;
using IstanbulCBS.Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Data
{
    public static class DataServiceRegistration
    {
        public static IServiceCollection AddDataService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();

            services.AddScoped<IDbConnection>(sp =>
            {
                var ctx = sp.GetRequiredService<DapperContext>();
                return ctx.CreateConnection();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenelRepository, GenelRepository>();
            services.AddScoped<ICevreRepository, CevreRepository>();

            return services;
        }
    }
}
