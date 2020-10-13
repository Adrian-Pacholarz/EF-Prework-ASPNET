﻿// <auto-generated />
using System;
using EntitiFrameworkPrework.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntitiFrameworkPrework.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20201013013202_InitialModels")]
    partial class InitialModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntitiFrameworkPrework.Models.Match", b =>
                {
                    b.Property<int>("match_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("away_team_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("goals_away")
                        .HasColumnType("int");

                    b.Property<int>("goals_home")
                        .HasColumnType("int");

                    b.Property<int?>("home_team_id")
                        .HasColumnType("int");

                    b.HasKey("match_id");

                    b.HasIndex("away_team_id");

                    b.HasIndex("home_team_id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("EntitiFrameworkPrework.Models.Team", b =>
                {
                    b.Property<int>("team_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("team_id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("EntitiFrameworkPrework.Models.Match", b =>
                {
                    b.HasOne("EntitiFrameworkPrework.Models.Team", "away_team")
                        .WithMany()
                        .HasForeignKey("away_team_id");

                    b.HasOne("EntitiFrameworkPrework.Models.Team", "home_team")
                        .WithMany()
                        .HasForeignKey("home_team_id");
                });
#pragma warning restore 612, 618
        }
    }
}
