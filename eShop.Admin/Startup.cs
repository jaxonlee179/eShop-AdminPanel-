using eShop.DatabaseRepository;
using eShop.DatabaseRepository.DbRepos;
using eShop.DatabaseRepository.DbModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.ApplicationService.Services;
using eShop.DatabaseRepository.RepositoryInterface;
using eShop.DomainService.ServiceInterfaces;
using eShop.DomainService.Services;

namespace eShop.Admin
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
            services.AddMvc();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //Categories
            services.AddScoped<ICaterogyRepository, CategoryRepository>();
            services.AddScoped<ICategoriesServiceDomain, CategoriesServiceDomain>();
            services.AddScoped<ICategoriesApplicationService, CategoriesApplicationService>();

            //Products
            services.AddScoped<IProductsRepository, ProductRepository>();
            services.AddScoped<IProductsServiceDomain, ProductsServiceDomain>();
            services.AddScoped<IProductsApplicationService, ProductsApplicationService>();

            //Orders
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrdersServiceDomain, OrdersServiceDomain>();
            services.AddScoped<IOrdersApplicationService, OrdersApplicationService>();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
