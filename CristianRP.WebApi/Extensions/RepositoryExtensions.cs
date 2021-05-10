using CristianRP.Repository;
using CristianRP.Repository.Repositories;
using CristianRP.Repository.Repositories.Implementations;
using CristianRP.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CristianRP.WebApi.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddDbContext<DataContext>(cfg =>
            {
               
                cfg.UseSqlite("FileName=CristianRPDb", option =>
               {
                   option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
               });

            });
            service.AddTransient<Seed>();
            service.AddScoped<IPropertyRepository, PropertyRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            return service;
        }
    }
}
