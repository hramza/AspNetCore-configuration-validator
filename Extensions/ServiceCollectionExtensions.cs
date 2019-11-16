using ConfigurationValidation.Settings.Validations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConfigurationValidation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurationValidation(this IServiceCollection services)
        {
            return services.AddTransient<IStartupFilter, GlobalSettingsValidationFilter>();
        }

        public static IServiceCollection ValidateConfiguration<T>(this IServiceCollection services, IConfiguration configuration)
            where T : class, ISettingsValidator, new()
        {
            services.Configure<T>(configuration);
            services.AddSingleton(svc => svc.GetRequiredService<IOptions<T>>().Value);
            services.AddSingleton<ISettingsValidator>(svc => svc.GetRequiredService<IOptions<T>>().Value);

            return services;
        }
    }
}
