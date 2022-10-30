using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Radio_Free_Europe.Attributes;
using Radio_Free_Europe.DataAccess.Repositories;
using Radio_Free_Europe.DataAccess.UnitOfWorks;
using Radio_Free_Europe.Extensions.DependencyInjection;
using Radio_Free_Europe.Services.MainServices;
using Radio_Free_Europe.Services.MainServices.Models;

namespace Radio_Free_Europe.Extensions
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.RegisterAssemblyPublicNonGenericClasses<TransientInjectableAttribute>(Assembly.GetExecutingAssembly())
            .AsPublicImplementedInterfaces(ServiceLifetime.Transient);

            services.RegisterAssemblyPublicNonGenericClasses<ScopedInjectableAttribute>(Assembly.GetExecutingAssembly())
            .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.RegisterAssemblyPublicNonGenericClasses<SingeltonInjectableAttribute>(Assembly.GetExecutingAssembly())
            .AsPublicImplementedInterfaces(ServiceLifetime.Singleton);

            services.AddSingleton<IDiffFinder, DiffFinder>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IMainService, MainService>();
            services.AddSingleton<IDiffStorage, LocalDiffStorage>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}