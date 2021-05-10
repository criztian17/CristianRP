using CristianRP.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CristianRP.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        #region DbSets
        public DbSet<PropertyEntity> Properties { get; set; }
        public DbSet<UserEntity> Users { get; set; } 
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyEntity>(entity =>
            {
                entity.HasIndex(i => i.Code).IsUnique();
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasIndex(i => i.Login).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
