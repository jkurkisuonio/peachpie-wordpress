using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeachPied.Demo.Plugins;
using PeachPied.WordPress.AspNetCore;
using Microsoft.Extensions.Options;

namespace PeachPied.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(typeof(Program).Assembly.Location));

            //
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://wpdotnet.hallinto.local")
                .Build();

            host.Run();
        }
    }

    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddResponseCompression();
            services.AddWordPress(options =>
            {
                 options.SiteUrl =
                 options.HomeUrl = "http://localhost";

                // options.PluginContainer.Add(new DashboardPlugin());
                options.PluginContainer.Add<JaniksShortcodePlugin>();
                options.PluginContainer.Add<JaniKoePlugin>();
            
                //options.PluginContainer.Add({new JaniKoePlugin(), new DashboardPlugin(), new ShortcodePlugin()  });
               options.PluginContainer.Add<DashboardPlugin>();
                options.PluginContainer.Add<ShortcodePlugin>();
               
            });
           
            
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWordPress();            
            app.UseDefaultFiles();
        }
    }
}
