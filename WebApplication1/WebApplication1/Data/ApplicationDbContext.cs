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
        public DbSet<Player> players { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<soloMatches> solomatches { get; set; }
        public DbSet<Maps> maps { get; set; }
        public DbSet<Weapons> weapons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leaderboards>()
        .Property(p => p.KD_Ratio)
        .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Leaderboards>()
            .ToTable("player_leaderboard_users")
            .HasAlternateKey(e => new
            {
                e.username,
                e.Pname
            });
        }
        
    }
}
