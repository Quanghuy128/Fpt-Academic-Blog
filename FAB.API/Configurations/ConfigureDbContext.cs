using Autofac;
using FAB.Domain.Common;
using FAB.Infrastructure.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace FAB.API.Configurations
{
    public static class ConfigureDbContext
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(AppConfig.ConnectionStrings.DefaultConnection).UseSnakeCaseNamingConvention();
            });
            return services;
        }

        public static ContainerBuilder AddDbContext(this ContainerBuilder builder)
        {
            builder.Register(c => new NpgsqlConnection(AppConfig.ConnectionStrings.DefaultConnection))
                    .As<IDbConnection>()
                    .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<DbContext>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
