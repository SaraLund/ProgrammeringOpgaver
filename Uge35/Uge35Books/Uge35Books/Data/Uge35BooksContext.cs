using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uge35Books.Models;

namespace Uge35Books.Data
{
    public class Uge35BooksContext : DbContext
    {
        public Uge35BooksContext (DbContextOptions<Uge35BooksContext> options)
            : base(options)
        {
        }

        public DbSet<Uge35Books.Models.Book> Book { get; set; } = default!;
    }
}
