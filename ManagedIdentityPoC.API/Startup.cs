using Azure.Data.Tables;
using Azure.Identity;
using ManagedIdentityPoC.API.Configurations;
using ManagedIdentityPoC.Application.Services;
using ManagedIdentityPoC.Integration.TableStorage.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.OpenApi.Models;
using System;

namespace ManagedIdentityPoC.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            if (Env.IsDevelopment())
            {
                services.AddScoped(c => new TableServiceClient(Configuration.GetConnectionString("StorageConnectionString")));
            }
            else
            {
                // App Registry example
                // var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

                // Managed Identity - System assigned
                var credential = new DefaultAzureCredential();
                var storageUri = Configuration.GetValue<string>("StorageUri");
                services.AddScoped(c => new TableServiceClient(new Uri(storageUri), credential));

                /*
                // Managed Identity - User Assigned
                string userAssignedClientId = ""; //Give Client ID of User Managed Identity
                var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions { ManagedIdentityClientId = userAssignedClientId });
                var storageUri = Configuration.GetValue<string>("StorageUri");
                services.AddScoped(c => new TableServiceClient(new Uri(storageUri), credential));
                */
            }
            services.AddScoped<IAppService, AppService>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddAutoMapperSetup();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManagedIdentityPoC.API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllRequests", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => origin == "http://localhost:3000")
                    .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManagedIdentityPoC.API v1"));
            }

            app.UseCors("AllRequests");

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