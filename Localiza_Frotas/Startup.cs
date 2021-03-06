using Localiza_Frotas_Domain;
using Localiza_Frotas_Infra.Facade;
using Localiza_Frotas_Infra.Repository;
using Localiza_Frotas_Infra.Repository.EF;
using Localiza_Frotas_Infra.Singleton;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Localiza_Frotas
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Localiza_Frotas", Description = "API - Frotas", Version = "v1" });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "Localiza_Frotas.xml");
                c.IncludeXmlComments(apiPath);
            });
            services.AddSingleton<SingletonContainer>();

            services.AddTransient<IVeiculoRepository, FrotaRepository>();

            services.AddDbContext<FrotaContext>(opt => opt.UseInMemoryDatabase("Frota"));

            services.Configure<DetranOptions>(Configuration.GetSection("DetranOptions"));

            services.AddHttpClient();

            services.AddTransient<IVeiculoDetran, VeiculoDetranFacade>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Localiza_Frotas v1"));
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Localiza.Frotas");
            });

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
