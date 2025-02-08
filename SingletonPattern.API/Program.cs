
using Microsoft.AspNetCore.Builder;
using SingletonPattern.API.Extensions;
using SingletonPattern.Domain.Interfaces;
using SingletonPattern.Infrastructure.Implementations;

namespace SingletonPattern.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Register Singleton for Database Connection
            builder.Services.AddSingleton<IDatabaseConnection>(provider =>
            DatabaseConnection.GetInstance(connectionString));

            builder.Services.AddApplicationServices();
           
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
           
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "MyAPI");
                });

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();           

            app.MapControllers();

            app.Run();
        }
    }
}
