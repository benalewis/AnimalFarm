using AnimalFarm.Services.Services;
using AnimalFarm.Services.Services.Interfaces;
using AnimalFarm.Services.UnitOfWork;
using AnimalFarm.Services.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;

namespace AnimalFarm.WebUI
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
            //string dbConnectionString = this.Configuration.GetConnectionString("dbConnection1");

            // Inject IDbConnection, with implementation from SqlConnection class.

            services.AddTransient<IDbConnection>((sp) => new SqlConnection("Server=(LocalDb)\\MSSQLLocalDB;Database=AnimalFarm;User Id=MyLogin;Password=Monkey88;"));

            services.AddTransient<ICatService, CatService>();
            services.AddTransient<IFarmService, FarmService>();

            services.AddTransient<IDapperUnitOfWork, DapperUnitOfWork>();

            services.AddControllers();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
