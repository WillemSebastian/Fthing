using System.Collections.Generic;
using Fthing.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Fthing.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=localhost;Database=Onero;Trusted_Connection=True;User Id=sa;Password=123456;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.Password).HasColumnName("Password");
                entity.Property(e => e.Gender).HasColumnName("Gender");
                entity.Property(e => e.Is_married).HasColumnName("Is_married");
                entity.Property(e => e.Address).HasColumnName("Address");
            });
        }
    }
}