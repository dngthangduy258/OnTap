using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTap.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> ops) : base(ops)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                  new Book { Id = 1, Title = "PHP", Author = "A", Price = 12000, Quantity = 10 },
                  new Book { Id = 2, Title = "C#", Author = "A", Price = 12000, Quantity = 15 },
                  new Book { Id = 3, Title = "Quản trị SQL Server", Author = "A", Price = 12000, Quantity = 10 },
                  new Book { Id = 4, Title = "Lập trình Node.js", Author = "A", Price = 12000, Quantity = 15 },
                  new Book { Id = 5, Title = "ASP.Net Core MVC", Author = "A", Price = 12000, Quantity = 10 },
                  new Book { Id = 6, Title = "Cấu trúc dữ liệu", Author = "A", Price = 12000, Quantity = 15 }
                );

        }
    }
}
