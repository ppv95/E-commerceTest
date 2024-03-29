using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Coretest
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

        services.AddDbContext<EcommerceDBContext>(options => 
        options.UseInMemoryDatabase(databaseName: "CommerceTestDataBase"));

        // services.AddHangfire(configuration =>
        // {
        //     configuration
        //             .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        //             .UseSimpleAssemblyNameTypeSerializer()
        //             .UseRecommendedSerializerSettings()
        //             .UseSqlServerStorage(Configuration.GetConnectionString("CommerceTestDataBase"), new SqlServerStorageOptions
        //             {
        //                 CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        //                 SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        //                 QueuePollInterval = TimeSpan.Zero,
        //                 UseRecommendedIsolationLevel = true,
        //                 UsePageLocksOnDequeue = true,
        //                 DisableGlobalLocks = true
        //             });
        // });

        //     services.AddHangfireServer();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // app.UseHangfireDashboard();
            // backgroundJobs.Enqueue(() => Console.WriteLine("Hello from HangFire"));

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
