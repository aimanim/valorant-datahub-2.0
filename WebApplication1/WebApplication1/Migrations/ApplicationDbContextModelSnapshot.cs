﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Leaderboards", b =>
                {
                    b.Property<string>("ShadowKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("KD_Ratio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MMR")
                        .HasColumnType("int");

                    b.Property<string>("Pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deaths")
                        .HasColumnType("int");

                    b.Property<string>("fav_agent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("kills")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ShadowKey");

                    b.HasAlternateKey("username", "Pname");

                    b.ToTable("player_leaderboard_users", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Location", b =>
                {
                    b.Property<int>("Location_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Location_id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Location_id");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("WebApplication1.Models.Maps", b =>
                {
                    b.Property<string>("Map_Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Location_id")
                        .HasColumnType("int");

                    b.Property<int>("Spike_sites")
                        .HasColumnType("int");

                    b.Property<string>("Suited_Weapon")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Map_Name");

                    b.HasIndex("Location_id");

                    b.HasIndex("Suited_Weapon");

                    b.ToTable("maps");
                });

            modelBuilder.Entity("WebApplication1.Models.Player", b =>
                {
                    b.Property<int>("Pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pid"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<string>("Fav_agent")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kills")
                        .HasColumnType("int");

                    b.Property<int>("Location_id")
                        .HasColumnType("int");

                    b.Property<int>("MMR")
                        .HasColumnType("int");

                    b.Property<string>("Pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pid");

                    b.HasIndex("Fav_agent");

                    b.HasIndex("Location_id");

                    b.ToTable("players");
                });

            modelBuilder.Entity("WebApplication1.Models.Weapons", b =>
                {
                    b.Property<string>("Weapon_Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Fire_Mode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Fire_Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Max_Range")
                        .HasColumnType("int");

                    b.Property<decimal?>("Reload_Speed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Weapon_Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Weapon_Name");

                    b.ToTable("weapons");
                });

            modelBuilder.Entity("WebApplication1.Models.agents", b =>
                {
                    b.Property<string>("agent_name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("pick_pct")
                        .HasColumnType("real");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("suited_weapon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("tier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ultimate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("voiced_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("win_pct")
                        .HasColumnType("real");

                    b.HasKey("agent_name");

                    b.HasIndex("suited_weapon");

                    b.ToTable("Agents", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.soloMatches", b =>
                {
                    b.Property<int>("Match_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Match_ID"));

                    b.Property<string>("Agent_Played")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Deaths")
                        .HasColumnType("int");

                    b.Property<int?>("Kills")
                        .HasColumnType("int");

                    b.Property<string>("Map_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PlayersPid")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Match_ID");

                    b.HasIndex("Agent_Played");

                    b.HasIndex("Map_Name");

                    b.HasIndex("PlayersPid");

                    b.ToTable("Solo_matches", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Maps", b =>
                {
                    b.HasOne("WebApplication1.Models.Location", "Locations")
                        .WithMany()
                        .HasForeignKey("Location_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Weapons", "weapons")
                        .WithMany()
                        .HasForeignKey("Suited_Weapon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locations");

                    b.Navigation("weapons");
                });

            modelBuilder.Entity("WebApplication1.Models.Player", b =>
                {
                    b.HasOne("WebApplication1.Models.agents", "Agents")
                        .WithMany()
                        .HasForeignKey("Fav_agent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Location", "Locations")
                        .WithMany()
                        .HasForeignKey("Location_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agents");

                    b.Navigation("Locations");
                });

            modelBuilder.Entity("WebApplication1.Models.agents", b =>
                {
                    b.HasOne("WebApplication1.Models.Weapons", "Weapon")
                        .WithMany()
                        .HasForeignKey("suited_weapon");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("WebApplication1.Models.soloMatches", b =>
                {
                    b.HasOne("WebApplication1.Models.agents", "Agents")
                        .WithMany()
                        .HasForeignKey("Agent_Played")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Maps", "maps")
                        .WithMany()
                        .HasForeignKey("Map_Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Player", "Players")
                        .WithMany()
                        .HasForeignKey("PlayersPid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agents");

                    b.Navigation("Players");

                    b.Navigation("maps");
                });
#pragma warning restore 612, 618
        }
    }
}
