using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.CORE.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Configuration
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider
            (this IServiceCollection services, IConfiguration configuration)
        {
            var conStr = configuration.GetConnectionString("DefaultConnection");
            services
                .AddDbContext<StoreContext>(opt => opt.UseSqlServer(conStr,
                b => b.MigrationsAssembly("Store.API")));
            return services;
        }
    }
}
