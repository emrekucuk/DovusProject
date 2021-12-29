﻿// <auto-generated />
using System;
using DovusProject.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DovusProject.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DovusProject.Entities.DovuscuOzellikleri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CanDegeri")
                        .HasColumnType("int");

                    b.Property<int>("DuzVurusHasari")
                        .HasColumnType("int");

                    b.Property<string>("Yetenek1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Yetenek1Hasari")
                        .HasColumnType("int");

                    b.Property<string>("Yetenek2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Yetenek2Hasari")
                        .HasColumnType("int");

                    b.Property<int>("ZırhDegeri")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DovuscuOzellikleri");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "Armor King",
                            CanDegeri = 100,
                            DuzVurusHasari = 10,
                            Yetenek1 = "Aparkat",
                            Yetenek1Hasari = 25,
                            Yetenek2 = "Döner Tekme",
                            Yetenek2Hasari = 35,
                            ZırhDegeri = 100
                        });
                });

            modelBuilder.Entity("DovusProject.Entities.GecmisMaclar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KazananId")
                        .HasColumnType("int");

                    b.Property<int?>("Oyuncu1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Oyuncu2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Oyuncu1Id");

                    b.HasIndex("Oyuncu2Id");

                    b.ToTable("GecmisMaclar");
                });

            modelBuilder.Entity("DovusProject.Entities.MacLoglari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Olaylar")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MacLoglari");
                });

            modelBuilder.Entity("DovusProject.Entities.GecmisMaclar", b =>
                {
                    b.HasOne("DovusProject.Entities.DovuscuOzellikleri", "Oyuncu1")
                        .WithMany()
                        .HasForeignKey("Oyuncu1Id");

                    b.HasOne("DovusProject.Entities.DovuscuOzellikleri", "Oyuncu2")
                        .WithMany()
                        .HasForeignKey("Oyuncu2Id");

                    b.Navigation("Oyuncu1");

                    b.Navigation("Oyuncu2");
                });
#pragma warning restore 612, 618
        }
    }
}
