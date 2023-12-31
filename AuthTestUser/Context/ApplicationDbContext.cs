﻿using AuthTestUser.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;

namespace AuthTestUser.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext()
        {

        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.1.13\\MSSQLSERVER_IMP;Database=AuthTestUserDB;user=sa;password=2262;Encrypt=False");
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // اضافه کردن مقادیر به جدول AspNetRoles
            SeedData.Initialize(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {



                //entity.HasNoKey();
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {

                entity.HasOne(a => a.Users).WithOne(b => b.ApplicationUser)
                .HasForeignKey<User>(b => b.User_ID);


            });







        }
    }
}
