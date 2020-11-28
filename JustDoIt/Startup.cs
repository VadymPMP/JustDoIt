using System;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JustDoIt.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using React.AspNet;

using AutoMapper;

using System.Threading.Tasks;

using System.Text;
using Microsoft.AspNetCore.Identity;

namespace JustDoIt
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _env;

        public void ConfigureServices(IServiceCollection services)
        {
            //string con = "Server=(localdb)\\mssqllocaldb;Database=NotesDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            
           
            services.AddCors();
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();
            services.AddDbContext<AplicationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<Users, IdentityRole>()
                        .AddEntityFrameworkStores<AplicationContext>();
            //string con = "Server=(localdb)\\mssqllocaldb;Database=AutoDB;Trusted_Connection=True;MultipleActiveResultSets=true";

            //services.AddDbContext<AplicationContext>(options => options.UseSqlServer(con));

            //services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddNewtonsoftJson(options =>
            //                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore) ;
           
        }
           

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseRouting();
          
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
           
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();    // подключение аутентификации
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
