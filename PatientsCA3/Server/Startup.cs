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
using Blazor.Extensions.Logging;
using System;
using PatientsCA3.Shared;
using System.Collections.Generic;
using PatientsCA3.Server.Repository;

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
            //register db context for the inmemory database
            services.AddDbContext<PatientContextDB>(options => options.UseInMemoryDatabase("Patients")); //database name
            services.AddScoped<IPatientDBRepository, PatientDBRepository>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddLogging(builder => builder.AddBrowserConsole());
            

            // Add CORS, automatically suports core, external host can interact with my backend, anywhere on public internet
            services.AddCors(o => o.AddPolicy("MyCORSpolicy", builder => { builder.AllowAnyOrigin();})); 
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

            //populate test data to the inmemory database
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PatientContextDB>();
                AddTestData(context);
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

        private void AddTestData(PatientContextDB context)
        {

            List<Patient> lst = new List<Patient>
            {
                new Patient {ID = 1, FirstName = "Dara", LastName ="Smith", Gender = Gender.Male, Age = 55, Height = 180, Weight = 88},
                new Patient {ID = 2, FirstName = "Peter", LastName ="Carr", Gender = Gender.Male, Age = 46, Height = 170, Weight = 95},
                new Patient {ID = 3, FirstName = "Maria", LastName ="White", Gender = Gender.Female, Age = 57, Height = 171, Weight = 82},
                new Patient {ID = 4, FirstName = "Erick", LastName ="Galang", Gender = Gender.Male, Age = 49, Height = 162, Weight = 70},
                new Patient {ID = 5, FirstName = "Barbara", LastName ="Rodak", Gender = Gender.Female, Age = 75, Height = 155, Weight = 67},
                new Patient {ID = 6, FirstName = "Magda", LastName ="MacDonnel", Gender = Gender.Female, Age = 35, Height = 160, Weight = 65}
            };
            lst.ForEach(p => context.Add<Patient>(p));
            
            context.SaveChanges();
        }
    }
}
