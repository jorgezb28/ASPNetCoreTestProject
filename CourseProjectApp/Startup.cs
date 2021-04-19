using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CourseProjectApp
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appseting.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appseting.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            /*if (environment.IsDevelopment())
            {
                builder.AddApplicationInsightSettings
            }*/
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory )
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink                 
            }
            else {
                app.UseExceptionHandler("/Main/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"default",
                    template: "{controller=Main}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
