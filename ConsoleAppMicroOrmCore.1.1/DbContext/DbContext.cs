using ConsoleAppMicroOrmCore._1._1;
using Microsoft.EntityFrameworkCore;
using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppMicroOrmCore._1._1
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
