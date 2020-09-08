using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FateFakeOrder.Data.Models;
using FateFakeOrder.Service;
using FateFakeOrder.Service.Interfaces;
using FateFakeOrder.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Servants.Interfaces;
using Servants.Services;

namespace ServantsService
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
            services.AddDbContext<FFOContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FFOConnections")));
            var authenticationConfig = new AuthenticationConfig();
            Configuration.GetSection("AuthenticationService").Bind(authenticationConfig);
            services.AddControllers();
            services.AddScoped<IServantService, ServantService>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
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
                endpoints.MapControllers();
            });
        }
    }
}
