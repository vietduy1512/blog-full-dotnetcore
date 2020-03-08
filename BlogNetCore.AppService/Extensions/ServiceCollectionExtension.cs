using AutoMapper;
using BlogNetCore.AppService.Context;
using BlogNetCore.AppService.Context.DbInitializer;
using BlogNetCore.AppService.Identity;
using BlogNetCore.AppService.Identity.Manager;
using BlogNetCore.AppService.Identity.UserStore;
using BlogNetCore.AppService.Mapping.Configuration;
using BlogNetCore.AppService.Repository;
using BlogNetCore.AppService.Repository.Core;
using BlogNetCore.AppService.Seedwork.ServiceContracts.Core;
using BlogNetCore.AppService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlogNetCore.AppService.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultDb"))
                    .UseLazyLoadingProxies();
            });

            // Identity configuration
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<BlogDbContext>()
                .AddUserStore<DLUserStore>()
                .AddRoleStore<DLRoleStore>()
                .AddUserManager<DLUserManager>()
                .AddSignInManager<DLSignInManager>()
                .AddRoleManager<DLRoleManager>()
                .AddDefaultTokenProviders();

            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingConfiguration>();
            });
            services.AddAutoMapper();

            return services;
        }

        public static IServiceCollection InjectDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(DbContext), typeof(BlogDbContext));
            services.AddTransient(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));
            services.AddTransient(typeof(IDbInitializer), typeof(DbInitializer));
            services.AddTransient(typeof(IEmailSender), typeof(EmailSender));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,,>));

            services.ConfigureServicesDI();

            return services;
        }

        private static void ConfigureServicesDI(this IServiceCollection services)
        {
            //Configure DI for services
            services.Scan(scan =>
            {
                scan.FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(classes => classes.AssignableTo<IService>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }
    }
}
