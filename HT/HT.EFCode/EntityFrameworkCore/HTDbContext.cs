using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using HT.EFCode.Entitys;

namespace HT.EFCode.EntityFrameworkCore
{
    public class HTDbContext : DbContext
    {
        public HTDbContext(DbContextOptions<HTDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("HT.EFCode"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
