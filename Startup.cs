using ConfigurationValidation.Settings;
using ConfigurationValidation.Settings.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ConfigurationValidation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IStartupFilter, GlobalSettingsValidationFilter>();

            services.Configure<StripeSettings>(Configuration.GetSection("StripeConfig"));
            services.AddSingleton(svc => svc.GetRequiredService<IOptions<StripeSettings>>().Value);
            services.AddSingleton<ISettingsValidator>(svc => svc.GetRequiredService<IOptions<StripeSettings>>().Value);

            services.Configure<SendgridSettings>(Configuration.GetSection("Sendgrid"));
            services.AddSingleton(svc => svc.GetRequiredService<IOptions<SendgridSettings>>().Value);
            services.AddSingleton<ISettingsValidator>(svc => svc.GetRequiredService<IOptions<SendgridSettings>>().Value);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
