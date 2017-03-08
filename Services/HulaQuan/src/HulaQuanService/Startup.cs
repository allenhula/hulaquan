using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HulaQuanService.Models;
using HulaQuanService.Data;
using Microsoft.EntityFrameworkCore;
using HulaQuanService.Helpers;

namespace HulaQuanService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            var config = builder.Build();

            builder.AddAzureKeyVault(
                config["KeyVault:NameUri"],
                config["KeyVault:ClientId"],
                config["KeyVault:ClientSecret"]
                );

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HulaStatusContext>(options => 
                options.UseSqlServer(Configuration[Consts.DbConnStrSecureNameInKv]));

            // Add framework services.
            services.AddMvc();

            // Fake one
            //services.AddSingleton<IHulaStatusRepository, FakeHulaStatusRepository>();

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IHulaStatusRepository, HulaStatusRepository>();
            services.AddSingleton<IStorageOperations, StorageOperations>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, HulaStatusContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            DbInitializer.Initialize(context);
        }
    }
}
