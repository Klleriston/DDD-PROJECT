using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Config
{
    public class ContextDb : IdentityDbContext<ApplicationUser>
    {
        public ContextDb(DbContextOptions<ContextDb> opt) : base (opt) { }

        public DbSet<News> News { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(e => e.Id);
            base.OnModelCreating(builder);
        }
        public string ConnectionString()
        {
            string con = "host=localhost;database=ddd;port=5432;username=postgres;password=root";
            return con;
        }
    }
}
