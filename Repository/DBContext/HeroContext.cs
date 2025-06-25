using Microsoft.EntityFrameworkCore;
using Repository.EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DBContext
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options) { }
        public DbSet<HeroEntity> HeroEntities { get; set; }
        public DbSet<HeroSkillEntity> HeroSkillEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HeroEntity>()
                .HasMany(m => m.HeroSkillEntities)
                .WithOne(m => m.HeroEntity)
                .HasForeignKey(d => d.HeroId);
        }
    }
}
