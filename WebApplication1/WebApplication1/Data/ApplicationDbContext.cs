using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public DbSet<solo_Matches> solomatches { get; set; }
        public DbSet<Maps> maps { get; set; }
        public DbSet<Weaponary> weapons { get; set; }
        public DbSet<SomeModel> somemodels { get; set; }
        public DbSet<GenericModel> genericmodel { get; set; }
        public DbSet<AgentAbilities> agentAbilities { get; set; }
        public DbSet<Agent_And_Abilities> agent_and_abilities { get; set; }
        public DbSet<User> users { get; set; }
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
            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");
                entity.HasKey(e => e.Pid);
            });
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");
                entity.HasKey(e => e.Location_id);
            });
            modelBuilder.Entity<Leaderboards>()
                .Property(p => p.KD_Ratio)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Leaderboards>()
                .ToTable("player_leaderboard_users")
                .HasAlternateKey(e => new { e.username, e.Pname });

            modelBuilder.Entity<solo_Matches>(entity =>
            {
                entity.ToTable("Solo_matches");
                entity.HasKey(e => e.Match_ID);

            });
            modelBuilder.Entity<Weaponary>(entity =>
            {
                entity.ToTable("weaponary");
                entity.HasKey(e => e.Weapon_Name);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(e => e.Username);
            });
			modelBuilder.Entity<SomeModel>().HasNoKey();
			modelBuilder.Entity<GenericModel>().HasNoKey();
			modelBuilder.Entity<AgentAbilities>().HasNoKey();
			modelBuilder.Entity<Agent_And_Abilities>().HasNoKey();
		}

    }
}
