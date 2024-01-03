
using CategoryAndItemAPI.BLL.Interfaces;
using CategoryAndItemAPI.BLL.Repository;
using CategoryAndItemAPI.DAL.Context;
using CategoryAndItemAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CategoryAndItemAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CategoryItemApiContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
            //builder.Services.AddAutoMapper(typeof(MappingProfiles));
            var app = builder.Build();
            //create object from StoreContext
            #region Create object from StoreContext
            var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();
            try
            {
                //object by Clr
                var context = service.GetRequiredService<CategoryItemApiContext>();
                //update-database
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, ex.Message);
            }
            #endregion
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
        }
    }
}