using Audit.EntityFramework;
using DovusProject.DataAccess.Concrete.Configuration;
using DovusProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DovusProject.DataAccess.Concrete.EntityFramework.Context
{
    public class ProjectDbContext : AuditDbContext
    {
        public DbSet<DovuscuOzellikleri> DovuscuOzellikleri { get; set; }
        public DbSet<GecmisMaclar> GecmisMaclar { get; set; }
        public DbSet<MacLoglari> MacLoglari { get; set; }


        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new DovuscuOzellikleriConfiguration());
        }
    }
}
