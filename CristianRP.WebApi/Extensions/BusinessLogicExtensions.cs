using CristianRP.BL.Implementations;
using CristianRP.BL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CristianRP.WebApi.Extensions
{
    public static class BusinessLogicExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services
                .AddScoped<IUserBL, UserBL>()
                .AddScoped<ISecurityBL, SecurityBL>();
            return services;
        }
    }
}
