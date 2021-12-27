using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using System.Linq;
using PatientsCA3.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace PatientsCA3.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) // collection of methods, it can be injected later
        {
            services.AddDbContext<PatientContextDB>(options => options.UseInMemoryDatabase("Patients")); //database name

            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddCors(o => o.AddPolicy("MyCORSpolicy", builder => { builder.AllowAnyOrigin();})); // Add CORS, automatically suports core
            services.AddSwaggerGen(soptions => { soptions.SwaggerDoc("v1", new OpenApiInfo { Title = "Patient Information", Version = "v1"}); }); // metadata - open api
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();

                app.UseSwagger(options =>
                {
                    options.SerializeAsV2 = true;
                });

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(soptions =>
                {
                    soptions.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    //soptions.RoutePrefix = string.Empty;
                });

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
