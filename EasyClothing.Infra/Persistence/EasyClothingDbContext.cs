using EasyClothing.Domain.Entities;
using EasyClothing.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EasyClothing.Infra.Persistence
{
    public class EasyClothingDbContext : DbContext
    {
        public EasyClothingDbContext(DbContextOptions<EasyClothingDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
