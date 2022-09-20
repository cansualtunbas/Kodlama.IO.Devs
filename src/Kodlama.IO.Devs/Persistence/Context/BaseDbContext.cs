using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class BaseDbContext: DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<SoftwareLanguage> SoftwareLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SoftwareLanguage>(a =>
            {
                a.ToTable("SoftwareLanguage").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Active).HasColumnName("Active");
                a.Property(p => p.CreateDate).HasColumnName("CreateDate");
                a.Property(p => p.CreateUser).HasColumnName("CreateUser");
                a.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technology").HasKey(t => t.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Active).HasColumnName("Active");
                a.Property(p => p.CreateDate).HasColumnName("CreateDate");
                a.Property(p => p.CreateUser).HasColumnName("CreateUser");
                a.HasOne(p => p.SoftwareLanguage);
            });

            //amaç örnek data oluşturmak
            SoftwareLanguage[] softwareLanguageEntitySeeds = { new(1, "C#",true,DateTime.Now,0)};
            modelBuilder.Entity<SoftwareLanguage>().HasData(softwareLanguageEntitySeeds);


            Technology[] technologyEntitySeeds = { new(1,1,"ASP.Net",true,DateTime.Now,0) };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);
        }
    }
}
