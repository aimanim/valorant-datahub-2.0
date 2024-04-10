using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<agents> Agents { get; set; }
        public DbSet<Leaderboards> leaderboards {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<agents>(entity =>
            {
                entity.ToTable("Agents");
                entity.HasKey(e => e.agent_name);

                entity.Property(e => e.pick_pct).IsRequired();
                entity.Property(e => e.win_pct).IsRequired();
                entity.Property(e => e.tier).IsRequired();
                entity.Property(e => e.role).IsRequired();

            });
            modelBuilder.Entity<Leaderboards>()
                .Property(p => p.KD_Ratio)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Leaderboards>()
                .ToTable("player_leaderboard_users")
                .HasAlternateKey(e => new { e.username, e.Pname });
        }
    }
}
