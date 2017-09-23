using ConsoleAppMicroOrmCore._2._0;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppMicroOrmCore._2._0
{
    public class AdventureWorksContext : DbContext
    {
        public virtual DbSet<WorkOrder> WorkOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@const.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Production");
            base.OnModelCreating(modelBuilder);
        }
    }
}
