﻿using Lite_Berry_Pi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Data
{
    public class LiteBerryDbContext : IdentityDbContext<ApplicationUser>
    {
        //Table creators:
        public DbSet<User> User { get; set; }
        public DbSet<Design> Design { get; set; }

        public DbSet<UserDesign> UserDesign { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        //Is this required?
        //public DbSet<ApplicationUser> ApplicationUser { get; set; }
        
        public LiteBerryDbContext(DbContextOptions options) : base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<UserDesign>().HasKey(
                x => new { x.UserId, x.DesignId });

            //Seed data:
            modelBuilder.Entity<User>().HasData(
                new User { Id= 1, Name = "Bruno" },
                new User { Id = 2, Name = "Elwood"},
                new User { Id = 3, Name = "Jake"}
            );

            modelBuilder.Entity<Design>().HasData(
                new Design { Id = 1, Title = "Test1", DesignCoords = "000011111"  },
                new Design { Id = 2, Title = "Test2", DesignCoords = "10011001" },
                new Design { Id = 3, Title = "Test3", DesignCoords = "100010101" }
            );

            modelBuilder.Entity<UserDesign>().HasData(
                new UserDesign { UserId = 1, DesignId = 1 },
                new UserDesign { UserId = 2, DesignId = 2 },
                new UserDesign { UserId = 3, DesignId = 3 }
            );
        }

       
    }


}
