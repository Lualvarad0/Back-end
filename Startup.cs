using Application1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application1
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
            //conexion a la base de datos

            //services.AddDbContext<AplicationDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            //NO usar este metodo
            //var connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<DbContext>(options => options.UseSqlServer(connection));

            //Tambien puede ser asi la conexion
            services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{ide?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
