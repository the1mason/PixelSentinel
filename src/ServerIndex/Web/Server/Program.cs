using FluentMigrator.Runner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using ServerIndex.Data.Migrations;

namespace ServerIndex.Server;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connection = builder.Configuration["POSTGRES_CONNECTION_STRING"];
        // Add services to the container.

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        builder.Services.AddFluentMigratorCore()
            .ConfigureRunner(rb =>
                rb.AddPostgres()
                .WithGlobalConnectionString(connection)
                .ScanIn(typeof(V202306220000InitialCreate).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole()
        );

        builder.Services.AddDbContextFactory<Data.IndexContext>(options => {
            options.UseNpgsql(connection);
        });

        // Add services to the container.

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();


        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        // Executing FluentMigrator's migrations
        using (var scope = app.Services.CreateScope())
        {
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        app.Run();

        
    }
}
