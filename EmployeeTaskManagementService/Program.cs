
using EmployeeTaskManagementService.DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeTaskManagementService
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

            var configuration = builder.Configuration;
            builder.Services.AddDbContext<EmployeeTaskDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DbConnectionStringPg")));

            builder.ResolveDependencies();
            var app = builder.Build();

            //Run migration on app start
            using var scope = app.Services.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeTaskDbContext>();
            await dbContext.Database.MigrateAsync();

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