using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Mappings;
using System;

namespace Persistence
{
    public class DataRequestApplicationDbContext : DbContext
    {
        public DataRequestApplicationDbContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<DataRequestApplication>(new DataRequestApplicationConfiguration());
        }

        public DbSet<DataRequestApplication> DataRequestApplications { get; set; }
    }
}
