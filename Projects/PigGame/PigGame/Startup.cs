using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PigGame.Models;
using System;

namespace PigGame
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(60 * 5); options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true; });
                services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{controller=Home}/{action=Index}/conf/{activeConf}/div/{activeDiv}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}