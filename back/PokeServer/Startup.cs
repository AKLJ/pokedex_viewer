using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PokeServer.Models.Configuration;

using Serilog.Core;
using Serilog.Events;
using Serilog;

namespace PokeServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true);

            var config = configBuilder.Build();

            services.Configure<EnvConfig>(config);

            var configurationDone = services.BuildServiceProvider().GetRequiredService<IOptions<EnvConfig>>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
            {
                Title = "PokeServer",
                Version = "v1",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Email = "axel.kalonji@free.fr", Name = "Axel KALONJI", Url = new Uri("https://github.com/AKLJ/") },
                Description = "Server requesting pokemon informations",
                License = new Microsoft.OpenApi.Models.OpenApiLicense() { Name = "GNU GPL", Url = new Uri("https://www.gnu.org/licenses/licenses.en.html") }
            }));

            services.AddSingleton<IPokeServerDatabase>(configurationDone.Value.PokeServerDatabase);
            services.AddSingleton(typeof(ILogger), new LoggerConfiguration().ReadFrom.Configuration(config)
                .CreateLogger());

            Services.RegisterServices.Register(services);
            Context.RegisterContext.Register(services);
            PokeApi.RegisterServices.Register(services);
            Events.RegisterServices.Register(services);
            App.RegisterServices.Register(services);
            Business.RegisterServices.Register(services);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configurationDone.Value.PokeServerCache.Url;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PokeServer v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
