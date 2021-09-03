using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using RestMethods.Model.Context;
using RestMethods.Repository;
using RestMethods.Services;
using RestMethods.Services.Implementations;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using RestMethods.Repository.Generic;
using Microsoft.Net.Http.Headers;
using RestMethods.Hypermedia.Filters;
using RestMethods.Hypermedia.Enricher;
using Microsoft.AspNetCore.Rewrite;

namespace RestMethods
{
    public class Startup
    {
        public IWebHostEnvironment Enviroment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment enviroment)
        {
            Configuration = configuration;
            this.Enviroment = enviroment;
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            string connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(
                options => options.UseMySql(connection
                    , 
                    new MySqlServerVersion(new Version(8, 0, 26)
                    )
                    )
                );
            if (Enviroment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }
            services.AddMvc(options => { options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();
            // Adiciona filtros de hypermidia
            var filterOptions = new HypermediaFilterOptions();
            filterOptions.ContentResponseEnrichers.Add(new PersonEnricher());
            filterOptions.ContentResponseEnrichers.Add(new BookEnricher());
            services.AddSingleton(filterOptions);
            //api versioning
            services.AddApiVersioning();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Treino ASP.NET",
                    Version = "v1",
                    Description = "API desenvolvida como treino de habilidades em ASP.NET",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "WAVES Systems",
                        Url = new Uri("https://www.github.com/KennedyWaves")
                    }
                });
            });
            //Dependency injection
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnecion = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnecion, msg => Log.Information(msg))
                {
                    Locations = new List<String>()
                    {
                        "db/migrations","db/dataset"
                    },
                    IsEraseDisabled = true
                };
                evolve.Migrate();
            }
            catch(SystemException ex)
            {
                Log.Error(ex.Message);
            }
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

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Treino ASP.NET v1"); });

            var option = new RewriteOptions();

            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
