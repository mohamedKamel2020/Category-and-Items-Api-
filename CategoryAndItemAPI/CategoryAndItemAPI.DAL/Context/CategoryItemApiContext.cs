using CategoryAndItemAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryAndItemAPI.DAL.Context
{
    public class CategoryItemApiContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public CategoryItemApiContext(DbContextOptions<CategoryItemApiContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
