using ServerHostedWasm.Shared;
using ServerHostedWasm.Server.Data;

namespace ServerHostedWasm.Server.Models
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            using (context)
            {
                if (context.Surfboard.Any())
                {
                    return;
                }

                context.Surfboard.AddRange(
                    new Surfboard
                    {
                        Name = "Minilog",
                        Price = 198.10
                    },
                    new Surfboard { 
                        Name = "Mahi Mahi", 
                        Price = 200.29 
                    },
                    new Surfboard
                    {
                        Name = "Tuna",
                        Price = 983.82
                    },
                    new Surfboard
                    {
                        Name = "Mola Mola",
                        Price = 928.74
                    },
                    new Surfboard
                    {
                        Name = "Whaleshark",
                        Price = 374.28
                    },
                    new Surfboard
                    {
                        Name = "Angler",
                        Price = 38882.38
                    },
                    new Surfboard
                    {
                        Name = "Oarfish",
                        Price = 2837.82
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
