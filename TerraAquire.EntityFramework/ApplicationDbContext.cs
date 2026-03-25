using System;
using Microsoft.EntityFrameworkCore;
using TerraAcquire.EntityFramework.Models;

namespace TerraAcquire.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ModelHouse> ModelHouses { get; set; }
        public DbSet<TrippingSchedule> TrippingSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ModelHouse>(entity =>
            {
                entity.ToTable("modelhouses");
                entity.Property(e => e.Id)
                      .HasColumnType("char(36)")
                      .ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(e => e.Id)
                      .HasColumnType("char(36)")
                      .ValueGeneratedOnAdd();
            });

            // ✅ Add this for TrippingSchedule
            modelBuilder.Entity<TrippingSchedule>(entity =>
            {
                entity.ToTable("trippingschedules");

                entity.Property(e => e.Id)
                      .HasColumnType("int")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerId)
                      .HasColumnType("char(36)")
                      .IsRequired(false);

                entity.Property(e => e.AgentId)
                      .HasColumnType("char(36)")
                      .IsRequired(false);

                entity.Property(e => e.CustomerName)
                      .HasMaxLength(255);

                entity.Property(e => e.AgentName)
                      .HasMaxLength(255);

    
                entity.Property(e => e.DateTime)
                      .HasColumnType("datetime");

                entity.Property(e => e.ScheduledBy)
                      .HasMaxLength(255);
            });
        }
    }
}