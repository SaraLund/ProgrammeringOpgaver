using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurfsUp.Data;
using System;
using System.Linq;

namespace SurfsUp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new SurfsUpContext(serviceProvider.GetRequiredService<DbContextOptions<SurfsUpContext>>()))
            {
                if (context.Surfboard.Any())
                {
                    return;
                }
                context.Surfboard.AddRange(
                    new Surfboard
                    {
                        Name = "The Minilog",
                        Length = 6,
                        Width = 21,
                        Thickness = 2.75,
                        Volume = 38.8,
                        Price = 565
                    }

                );
                context.SaveChanges();
            }
        }
        
    }
}
