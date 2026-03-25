using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using TerraAcquire.EntityFramework.Models;




namespace TerraAcquire.EntityFramework
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }

        public DbSet<ModelHouse> ModelHouses { get; set; }
        public DbSet<Tripping> Trippings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var modelHouses = new List<ModelHouse>
{
    new ModelHouse
    {
        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        Name = "Model House A",
        Location = "Manila",
        Price = 2500000,
        Bedrooms = 3,
        Bathrooms = 2,
        Floors = 1,
        SquareFeet = 1200,
        IsActive = true
    },
    new ModelHouse
    {
        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        Name = "Model House A",
        Location = "Manila",
        Price = 2500000,
        Bedrooms = 3,
        Bathrooms = 2,
        Floors = 1,
        SquareFeet = 1200,
        IsActive = true
    },
    new ModelHouse
    {
        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        Name = "Model House A",
        Location = "Manila",
        Price = 2500000,
        Bedrooms = 3,
        Bathrooms = 3,
        Floors = 1,
        SquareFeet = 1200,
        IsActive = true
    }
};




            var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("7fda491d-6017-445d-ac77-59f87e640778"),
                    Role = Role.Admin,
                    EmailAddress = "johndaryl@gmail.com",
                    Password = "lawrence",
                    FirstName = "john daryl",
                    LastName = "love",
                    IsActive = true
                },
                new User
                {
                    Id = Guid.Parse("bb7fbc7d-1e9e-4a3b-9902-a30605edd9e0"),
                    Role = Role.Agent,
                    EmailAddress = "neil@gmail.com",
                    Password = "sigesigesige",
                    FirstName = "neil",
                    LastName = "silvestre",
                    IsActive = true
                },
                new User
                {
                    Id = Guid.Parse("84adfe15-1c72-44af-a52d-140ae13dd6ac"),
                    Role = Role.Customer,
                    EmailAddress = "jayroaalma@gmail.com",
                    Password = "babydave",
                    FirstName = "jayroa",
                    LastName = "alma",
                    IsActive = true
                },
                new User
                {
                    Id = Guid.Parse("1a795efd-c23a-4107-bd34-a0e8910277ab"),
                    Role = Role.Staff,
                    EmailAddress = "justine@gmail.com",
                    Password = "babyjustine",
                    FirstName = "justine",
                    LastName = "pics",
                    IsActive = true
                }
            };

            // Seed: Trippings
            var trippings = new List<Tripping>
            {
                new Tripping
                {
                    Id = Guid.Parse("0276a4b7-6f0b-4e5e-af54-51382e92216f"),
                    AgentId = Guid.Parse("bb7fbc7d-1e9e-4a3b-9902-a30605edd9e0"),
                    DateTime = new DateTime(2024, 5, 22),
                }
            };

            // Apply seeds
            modelBuilder.Entity<ModelHouse>().HasData(modelHouses);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Tripping>().HasData(trippings);

            // Relationships
            modelBuilder.Entity<Tripping>()
                .HasOne(t => t.Agent)
                .WithMany()
                .HasForeignKey(t => t.AgentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}