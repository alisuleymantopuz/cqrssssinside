using cqrssssinside.domain.appServices;
using cqrssssinside.domain.appServices.Utils;
using cqrssssinside.domain.infrastructure.Data;
using cqrssssinside.web.common.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace cqrssssinside.employees
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var config = new Config(Configuration.GetValue<int>("NumberOfDatabaseRetries"));
            services.AddSingleton(config);

            var commandsConnectionString = new CommandsConnectionString(Configuration["ConnectionString"]);
            var queriesConnectionString = new QueriesConnectionString(Configuration["QueriesConnectionString"]);
            services.AddSingleton(commandsConnectionString);
            services.AddSingleton(queriesConnectionString);

            services.AddDbContext<StoreDBContext>(opt => opt.UseInMemoryDatabase(commandsConnectionString.Value), ServiceLifetime.Singleton);

            services.AddSingleton<Messages>();

            services.AddDepartmentHandlers();

            services.AddEmployeeHandlers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "StoreM - Employees API", Version = "v1" });
            });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<StoreDBContext>();

                context.Database.EnsureCreated();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreM - Employees API V1");
            });

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandler>();
            app.UseMvc();

            app.UseHealthChecks("/healthz");
        }
    }
}
