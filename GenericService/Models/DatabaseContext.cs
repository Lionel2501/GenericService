using System;
using Microsoft.EntityFrameworkCore;
using GenericService.Models;

namespace GenericService.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts) 
        {

        }

        public DbSet<Persons> Persons { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Direcciones> Direcciones { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Server=.;Database=LearnDb;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=.; Database=test;Integrated Security=True;");
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persons>(entity =>
            {
                entity
                    // .HasNoKey()
                    .ToTable("persons");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                // entity.Property(e => e.Price).HasColumnName("price");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
