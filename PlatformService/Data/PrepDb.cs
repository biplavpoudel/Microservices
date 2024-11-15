﻿using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(WebApplication app)
    {
        bool isProd = app.Environment.IsProduction();
        using (var serviceScope = app.Services.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>(), isProd);
        }
    }

    private static void SeedData(AppDbContext context, bool isProd)
    {
        if (isProd)
        {
            Console.WriteLine("--> Attempting Migrations for Production Environment....");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Couldn't run Migrations: {ex.ToString()}");
            }
        }
        if (!context.Platforms.Any())
        {
            Console.WriteLine("--> Seeding Data.....");
            context.Platforms.AddRange(
                new Platform()
                {
                    Name = "Dot Net",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "SQL Server Express",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "Kubernetes",
                    Publisher = "Cloud Native Computing Foundation",
                    Cost = "Free"
                }
            );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> We already have data!");
        }
    }
}
