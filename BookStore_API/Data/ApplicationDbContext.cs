using BookStore_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookStore_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> user { get; set; }
        public DbSet<Author> author { get; set; }
        public DbSet<Publisher> publisher { get; set; }
        public DbSet<Book> book { get; set; }


    }
}
