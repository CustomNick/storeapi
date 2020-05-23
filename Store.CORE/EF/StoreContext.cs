using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.CORE.EF
{
    public class StoreContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public StoreContext(DbContextOptions<StoreContext> opt) :
            base(opt)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>[]
                {
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER"
                    },
                });
            modelBuilder.Entity<RefreshToken>()
                .HasKey(rt => new { rt.UserId, rt.Token });
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
