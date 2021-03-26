﻿// <auto-generated />
using System;
using Got_PTTK_PO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Got_PTTK_PO.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210116041019_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Got_PTTK_PO.Models.ObszarGorski", b =>
                {
                    b.Property<string>("NazwaOG")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("NazwaOG");

                    b.ToTable("ObszarGorski");
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.Punkt", b =>
                {
                    b.Property<string>("NazwaP")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<float>("DlGeo")
                        .HasColumnType("real")
                        .HasMaxLength(10);

                    b.Property<int>("Rodzaj")
                        .HasColumnType("int");

                    b.Property<float>("SzerGeo")
                        .HasColumnType("real")
                        .HasMaxLength(10);

                    b.Property<float>("WysNpm")
                        .HasColumnType("real");

                    b.HasKey("NazwaP");

                    b.ToTable("Punkt");
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.Punkt_RegionGorski", b =>
                {
                    b.Property<string>("NazwaP")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("IdRG")
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("NazwaP", "IdRG");

                    b.HasIndex("IdRG");

                    b.ToTable("Punkt_RegionGorski");
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.Punkt_TerenGorski", b =>
                {
                    b.Property<string>("NazwaP")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NazwaTG")
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("NazwaP", "NazwaTG");

                    b.HasIndex("NazwaTG");

                    b.ToTable("Punkt_TerenGorski");
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.RegionGorski", b =>
                {
                    b.Property<string>("IdRG")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("NazwaOG1")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdRG");

                    b.HasIndex("NazwaOG1");

                    b.ToTable("RegionGorski");
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.TerenGorski", b =>
                {
                    b.Property<string>("NazwaTG")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("NazwaTG");

                    b.ToTable("TerenGorski");
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.Trasa", b =>
                {
                    b.Property<string>("NazwaT")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("NazwaPP")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NazwaPK")
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<int>("LiczbaPkt")
                        .HasColumnType("int");

                    b.HasKey("NazwaT", "NazwaPP", "NazwaPK");

                    b.HasIndex("NazwaPK");

                    b.HasIndex("NazwaPP");

                    b.ToTable("Trasa");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.Punkt_RegionGorski", b =>
                {
                    b.HasOne("Got_PTTK_PO.Models.RegionGorski", "RegionGorski")
                        .WithMany("PunktyWRegionie")
                        .HasForeignKey("IdRG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Got_PTTK_PO.Models.Punkt", "Punkt")
                        .WithMany("RegionyGorskie")
                        .HasForeignKey("NazwaP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.Punkt_TerenGorski", b =>
                {
                    b.HasOne("Got_PTTK_PO.Models.Punkt", "Punkt")
                        .WithMany("TerenyGorskie")
                        .HasForeignKey("NazwaP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Got_PTTK_PO.Models.TerenGorski", "TerenGorski")
                        .WithMany("PunktyWTerenie")
                        .HasForeignKey("NazwaTG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.RegionGorski", b =>
                {
                    b.HasOne("Got_PTTK_PO.Models.ObszarGorski", "NazwaOG")
                        .WithMany()
                        .HasForeignKey("NazwaOG1");
                });

            modelBuilder.Entity("Got_PTTK_PO.Models.Trasa", b =>
                {
                    b.HasOne("Got_PTTK_PO.Models.Punkt", "PunktKonc")
                        .WithMany("TrasyKonczone")
                        .HasForeignKey("NazwaPK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Got_PTTK_PO.Models.Punkt", "PunktPocz")
                        .WithMany("TrasyRozpoczynane")
                        .HasForeignKey("NazwaPP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
