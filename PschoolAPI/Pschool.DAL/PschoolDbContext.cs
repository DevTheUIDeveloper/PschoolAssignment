using Microsoft.EntityFrameworkCore;
using Pschool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pschool.DAL
{
    public class PschoolDbContext : DbContext
    {
        public PschoolDbContext(DbContextOptions<PschoolDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>().HasData(
               new Parent { Id = 1, FirstName = "First", LastName = "Parent", Email = "parent1@example.com" },
               new Parent { Id = 2, FirstName = "Second", LastName = "Parent", Email = "parent2@example.com" }
           // Add more parents as needed
           );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "John", LastName= "Doe", Age = 18, ParentId = 1 },
                new Student { Id = 2, FirstName = "Jane", LastName="Smith", Age = 20, ParentId = 1 }
                // Add more students as needed
            );

           
        }

        public DbSet<Student> Students { get;set; }
        public DbSet<Parent> Parents { get;set; }
    }
}
