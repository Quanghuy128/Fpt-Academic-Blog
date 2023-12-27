using Autofac;
using FAB.Domain.Common;

namespace FAB.API.Configurations
{
    public static class ConfigureAppSettings
    {
        public static void SettingsBinding(this IConfiguration configuration)
        {
            
            AppConfig.ConnectionStrings = new ConnectionStrings();

            configuration.Bind("ConnectionStrings", AppConfig.ConnectionStrings);

        }
    }
}
