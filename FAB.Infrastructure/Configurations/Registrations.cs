using FAB.Infrastructure.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FAB.Infrastructure.Configurations
{
    public static class Registrations
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}
