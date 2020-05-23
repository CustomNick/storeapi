using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Store.AUTH.Interfaces;
using Store.AUTH.Services;
using Store.CORE.EF;
using Store.CORE.Repositories;
using Store.DATA.Entities;
using Store.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IItemRepository, ItemRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IRoleRepository, RoleRepository>()
                .AddTransient<IJwtGenerator, JwtGenerator>()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IMessageRepository, MessageRepository>();

            return services;
        }

        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(o => {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<StoreContext>();

            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
           services.AddCors(options => {
               options.AddPolicy("AllowAll", builder =>
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
           });

    }
}
