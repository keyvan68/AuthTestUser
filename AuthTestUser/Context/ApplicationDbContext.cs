using AuthTestUser.Entities;
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
            modelBuilder.Entity<IdentityUser>().HasKey(u => u.Id);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(r => new { r.UserId, r.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().HasNoKey();
            //modelBuilder.ApplyConfiguration(new AccessConfiguration());
            modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
            new ApplicationRole
            {
                Id = Guid.NewGuid(),
                Name = "User",
                NormalizedName = "User".ToUpper()
            }
            );

            //The entity type 'IdentityUserToken<Guid>' requires a primary key to be defined.If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'.For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.
        }


    }
}
