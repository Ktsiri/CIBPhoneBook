using CIBPhonebook.Domain.EF.DomainContexts;
using CIBPhonebook.Domain.EF.Repository;
using CIBPhonebook.Domain.Repositories.Interfaces;
using CIBPhonebook.Domain.Repositories.Retrivers.Implementation;
using CIBPhonebook.Domain.Repositories.Retrivers.Interfaces;
using CIBPhonebook.Domain.Services.Implementation;
using CIBPhonebook.Domain.Services.Interfaces;
using CIBPhonebook.Domain.Validations;
using CIBPhonebook.Domain.Validations.Interfaces;
using CIBPhonebook.Domain.Validations.PhoneBook;
using CIBPhonebook.Dtos;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CIBPhonebook
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
            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CIB Phonebook", Version = "v1" });
            });

            // Database
            services.AddDbContext<DomainContext>(opts =>
                    opts.UseInMemoryDatabase("CIBDatabase"));
            services.AddScoped<DomainContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // fluent validation
            services.AddScoped(typeof(IValidatorObject<>), typeof(ValidationManager<>));
            services.AddTransient<IValidator<PhoneBookDto>, PhoneBookDtoValidator>();

            //services

            services.AddScoped(typeof(IAddPhoneBookRecord), typeof(AddPhoneBookRecord));
            services.AddScoped(typeof(IPhoneBookRetriver), typeof(PhoneBookRetriver));
            services.AddScoped(typeof(IGetPhoneBookRecord), typeof(GetPhoneBookRecord));

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
