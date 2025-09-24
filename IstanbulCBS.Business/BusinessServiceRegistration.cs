using IstanbulCBS.Business.Implementation;
using IstanbulCBS.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IGenelBusiness, GenelBusiness>();
            return services;
        }
    }
}
