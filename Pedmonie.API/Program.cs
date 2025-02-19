
using System;
using Microsoft.EntityFrameworkCore;
using Pedmonie.Migrationn;
using Pedmonie.Service.Interfaces;
using Pedmonie.Service.Services;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Pedmonie.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // configure MYSQL database
        //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        // builder.Services.AddOptions<Logging>().BindConfiguration(nameof(Logging));
        Console.WriteLine("welcome");
        var connectionString = builder.Configuration["DefaultConnections"];
        Console.WriteLine(connectionString);
        // Register ApplicationDbContext with DI
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySQL(connectionString)
        );
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddScoped<IWalletService, WalletService>();
        builder.Services.AddScoped<ITransactionService, TransactionService>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
