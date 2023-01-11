using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Lab4LukaszBednarek.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Lab4LukaszBednarek
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
            services.AddControllersWithViews(); //Add routing services. Included in pre-generated code.

            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MovieDbContext")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<MovieDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", config =>
            {
                config.Cookie.Name = "Access.Cookie";
                config.LoginPath = "/Home/Authenticate";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //The routing is directed to the Home Controller. Included in pre-generated code.
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //New endpoint for Home Controller. Now has a different name and specifies optional parameter category in the URL pattern.
                /*
                endpoints.MapControllerRoute(
                    name: "list items",
                    pattern: "{controller=Home}/{action=Index}/{category?}/{id?}");*/
            });
        }
    }
}
