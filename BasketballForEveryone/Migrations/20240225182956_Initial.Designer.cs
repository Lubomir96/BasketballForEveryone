﻿// <auto-generated />
using System;
using BasketballForEveryone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasketballForEveryone.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240225182956_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasketballForEveryone.Models.BPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BPlayers");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.BPlayer_BestPlayer", b =>
                {
                    b.Property<int>("BPlayerId")
                        .HasColumnType("int");

                    b.Property<int>("BestPlayerId")
                        .HasColumnType("int");

                    b.HasKey("BPlayerId", "BestPlayerId");

                    b.HasIndex("BestPlayerId");

                    b.ToTable("BPlayers_BestPlayers");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.BestPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CareerEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CareerStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Points")
                        .HasColumnType("float");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("TeamId");

                    b.ToTable("BestPlayers");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.BPlayer_BestPlayer", b =>
                {
                    b.HasOne("BasketballForEveryone.Models.BPlayer", "BPlayer")
                        .WithMany("BPlayer_BestPlayers")
                        .HasForeignKey("BPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasketballForEveryone.Models.BestPlayer", "BestPlayer")
                        .WithMany("BPlayer_BestPlayers")
                        .HasForeignKey("BestPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BPlayer");

                    b.Navigation("BestPlayer");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.BestPlayer", b =>
                {
                    b.HasOne("BasketballForEveryone.Models.Coach", "Coach")
                        .WithMany("BestPlayers")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasketballForEveryone.Models.Team", "Team")
                        .WithMany("BestPlayers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.BPlayer", b =>
                {
                    b.Navigation("BPlayer_BestPlayers");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.BestPlayer", b =>
                {
                    b.Navigation("BPlayer_BestPlayers");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.Coach", b =>
                {
                    b.Navigation("BestPlayers");
                });

            modelBuilder.Entity("BasketballForEveryone.Models.Team", b =>
                {
                    b.Navigation("BestPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
