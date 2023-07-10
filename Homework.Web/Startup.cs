using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework.Repository;
using Homework.Domain.Models;
using Homework.Repository.Interfaces;
using Homework.Service.Interfaces;
using Homework.Repository.Implementations;

namespace Homework.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    })
                    );

            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped(typeof(AppUserRepository), typeof(AppUserRepositoryImpl));
            services.AddScoped(typeof(MovieRepository), typeof(MovieRepositoryImpl));
            services.AddScoped(typeof(OrderRepository), typeof(OrderRepositoryImpl));
            services.AddScoped(typeof(ShoppingCartRepository), typeof(ShoppingCartRepositoryImpl));
            services.AddScoped(typeof(TicketInShoppingCartRepository), typeof(TicketInShoppingCartRepositoryImpl));
            services.AddScoped(typeof(TicketRepository), typeof(TicketRepositoryImpl));

            services.AddTransient<AppUserService, Service.Implementations.AppUserServiceImpl>();
            services.AddTransient<MovieService, Service.Implementations.MovieServiceImpl>();
            services.AddTransient<OrderService, Service.Implementations.OrderServiceImpl>();
            services.AddTransient<ShoppingCartService, Service.Implementations.ShoppingCartServiceImpl>();
            services.AddTransient<TicketInShoppingCartService, Service.Implementations.TicketInShoppingCartServiceImpl>();
            services.AddTransient<TicketService, Service.Implementations.TicketServiceImpl>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
