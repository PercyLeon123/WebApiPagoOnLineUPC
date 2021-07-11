using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PagoOnLineBusisness.DBContext.Interface;
using PagoOnLineBusisness.DBContext.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using PagoOnLineBusiness.API.Config;

namespace PagoOnLineBusiness.API
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
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PagoOnLineBusiness.API", Version = "v1" });
            //});

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IContribuyenteRepository, ContribuyenteRepository>();
            services.AddTransient<IContribuyenteloginRepository, ContribuyenteloginRepository>();
            services.AddTransient<IEstadoCuentaHistoricoRepository, EstadoCuentaHistoricoRepository>();
            services.AddTransient<IEstadoCuentaPendienteRepository, EstadoCuentaPendienteRepository>();

            // ----------------------------------------------------------------
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            // TODO: Configuration Section
            services.Configure<PagoOnLineBusisness.DBEntity.Base.ConfigSettings>(Configuration.GetSection("ConfigSettings"));
            PagoOnLineBusisness.DBEntity.Base.ConfigSettings config = Configuration.GetSection("ConfigSettings").Get<PagoOnLineBusisness.DBEntity.Base.ConfigSettings>();
            AppSettingsProvider.config = config;

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                      ;
            }));


            services.AddAuthentication("Bearer")
              .AddJwtBearer("Bearer", options =>
              {
                  options.Authority = AppSettingsProvider.config.UrlBaseIdentityServer;
                  options.RequireHttpsMetadata = false;
                  options.RefreshOnIssuerKeyNotFound = true;
                  options.Audience = "API-APP-UPC";
              });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    name: AppSettingsProvider.config.Version,
                    new OpenApiInfo
                    {
                        Title = AppSettingsProvider.config.ApplicationName,
                        Version = AppSettingsProvider.config.Version,
                        Contact = new OpenApiContact()
                        {
                            Name = AppSettingsProvider.config.OrganizationName,
                            Url = new System.Uri("https://www.upc.edu.pe/"),
                            Email = "upc@upc.edu.pe",
                        },
                        Description = AppSettingsProvider.config.ApplicationDescription,

                        License = new OpenApiLicense() { Name = AppSettingsProvider.config.OrganizationName, Url = new System.Uri("https://www.upc.edu.pe/") },
                        TermsOfService = new System.Uri("https://www.upc.edu.pe/")
                    });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Esta api usa Authorization  basada en JWT.-  
                      Ingrese 'Bearer' [space] y luego el token de autenticación.
                      Ejemplo: 'Bearer HJNX4354X...'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });
            });


        }
                    
            

            

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PagoOnLineBusiness.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
