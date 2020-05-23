using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoughnutFactory.Core;
using DoughnutFactory.Core.Services;
using DoughnutFactory.Data;
using DoughnutFactory.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DoughnutFactory.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void InitializeDataContexts(IServiceScope serviceScope)
        {
            serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().EnsureSeeded();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddTransient<IDoughnutTreeService, DoughnutTreeService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDoughnutTreeManagerService, DoughnutTreeManagerService>();

            services.AddControllers();

            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "Doughnu API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyOrigin());
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Doughnu API"));

            
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
