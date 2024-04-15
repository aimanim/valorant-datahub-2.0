﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<SomeModel> somemodels { get; set; }
        public DbSet<GenericModel> genericmodel { get; set; }
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

            modelBuilder.Entity<soloMatches>(entity =>
            {
                entity.ToTable("Solo_matches");
                entity.HasKey(e => e.Match_ID);

            });
            modelBuilder.Entity<Weapons>(entity =>
            {
                entity.ToTable("weaponary");
                entity.HasKey(e => e.Weapon_Name);
            });
            modelBuilder.Entity<SomeModel>().HasNoKey();
            modelBuilder.Entity<GenericModel>().HasNoKey();
        }

    }
}