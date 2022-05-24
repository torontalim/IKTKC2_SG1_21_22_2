using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IKTKC2_SG1_21_22_2.Data;
using IKTKC2_SG1_21_22_2.Logic;
using IKTKC2_SG1_21_22_2.Repository;
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

namespace IKTKC2_SG1_21_22_2.Endpoint
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
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "IKTKC2_SG1_21_22_2.Endpoint", Version = "v1"});
            });

            services.AddDbContext<PlayerContext>(options => options.UseSqlServer(connString));
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerService, PlayerService>();
            
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IKTKC2_SG1_21_22_2.Endpoint v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public static string MDF_Directory
        {
            get
            {
                var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
                return Path.GetFullPath(Path.Combine(directoryPath, "..//..//..//..//IKTKC2_SG1_21_22_2.Data"));
            }
        }

        public string connString = "Data Source=(LocalDB)\\MSSQLLocalDB; " +
                "AttachDbFilename=" + MDF_Directory + "\\Database.mdf;" +
                " Integrated Security=True; Connect Timeout=300;";
    }
}