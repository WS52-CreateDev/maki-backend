using _3_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Data.Contexts
{
    public class DesignContext : DbContext
    {
        public DbSet<DesignData> Designs { get; set; }

        public DesignContext(DbContextOptions<DesignContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DesignData>().ToTable("Designs");
        }
    }
}
