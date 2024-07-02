using Microsoft.EntityFrameworkCore;

namespace interview_backend;

public class Program
{
    public static void Main(string[] args)
    {
        // Run migratons
        using (var context = new CustomersContext())
        {
            context.Database.Migrate();
        }
        var allowallPolicy = "_allowAllPolicy";
        
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: allowallPolicy,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.UseCors(allowallPolicy);

        app.MapControllers();

        app.Run();
    }
}