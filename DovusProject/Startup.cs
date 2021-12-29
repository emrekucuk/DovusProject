using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using DovusProject.DataAccess.Abstract;
using DovusProject.DataAccess.Concrete.EntityFramework;
using DovusProject.DataAccess.Concrete.EntityFramework.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DovusProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("CStringSql")));
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            var assembly = AppDomain.CurrentDomain.Load("DovusProject");
            services.AddMediatR(assembly);
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

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureServices(services);
            services.AddTransient<IDovuscuOzellikleriRepository, DovuscuOzellikleriRepository>();
            services.AddTransient<IGecmisMaclarRepository, GecmisMaclarRepository>();
            services.AddTransient<ISavasLoglariRepository, SavasLoglariRepository>();
        }
    }
}
