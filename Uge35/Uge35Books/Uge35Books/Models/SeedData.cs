using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Uge35Books.Data;
using System;
using System.Linq;

namespace Uge35Books.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Uge35BooksContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Uge35BooksContext>>()))
            {
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Alice",
                        Author = "Christina Henry"
                    },
                    new Book
                    {
                        Title = "Red Queen",
                        Author = "Christina Henry"
                    }, 
                    new Book
                    {
                        Title = "Lost Boy",
                        Author = "Christina Henry"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
