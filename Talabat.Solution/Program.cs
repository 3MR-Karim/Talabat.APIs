
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contracts;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat.Solution
{
    public class Program
    {
        public static async  Task Main(string[] args)
        {
            #region Configure Services
            var webApplicationBuilder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            webApplicationBuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();


            webApplicationBuilder.Services.AddDbContext<StoreContext>(options =>
            {

                options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection"));


            });
            #region Use overload Two
            //webApplicationBuilder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            //webApplicationBuilder.Services.AddScoped<IGenericRepository<ProductBrand>, GenericRepository<ProductBrand>>();
            //webApplicationBuilder.Services.AddScoped<IGenericRepository<ProductCategory>, GenericRepository<ProductCategory>>(); 
            #endregion

            webApplicationBuilder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            webApplicationBuilder.Services.AddInfrastructureServices(webApplicationBuilder.Configuration);
            #endregion
            #region Ask CLR for createing object from dbcontent explcitre
            var app = webApplicationBuilder.Build();
      using var scope = app.Services.CreateScope();/*range time for zamanz */
            var services = scope.ServiceProvider;// ask object contiaenr asck object form scopeservice
            var _dbContext = services.GetRequiredService<StoreContext>(); // get object order from crate from stoerecotne t

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await _dbContext.Database.MigrateAsync();
                // after bro when do migraion need seeding OK 
                await StoredContextSeed.SeedAsync(_dbContext); // seconed for create update DB with this method bro 
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            
            var logger = loggerFactory.CreateLogger<Program>();
             logger.LogError(ex, "an error has been occured during apply the migration");
            }
            

            #endregion
            #region Configure Kestrel Middlewares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}
