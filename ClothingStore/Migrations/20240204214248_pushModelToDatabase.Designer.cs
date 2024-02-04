﻿// <auto-generated />
using System;
using ClothingStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClothingStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240204214248_pushModelToDatabase")]
    partial class pushModelToDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClothingStore.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategorieId"));

                    b.Property<string>("NomCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategorieId");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("ClothingStore.Models.Clothe", b =>
                {
                    b.Property<int>("ClotheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClotheId"));

                    b.Property<int?>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("ClotheName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(6000)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal?>("Prix")
                        .IsRequired()
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("Quantite")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ClotheId");

                    b.HasIndex("CategorieId");

                    b.ToTable("Clothes");
                });

            modelBuilder.Entity("ClothingStore.Models.Clothe", b =>
                {
                    b.HasOne("ClothingStore.Models.Categorie", "Categorie")
                        .WithMany("clothes")
                        .HasForeignKey("CategorieId");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("ClothingStore.Models.Categorie", b =>
                {
                    b.Navigation("clothes");
                });
#pragma warning restore 612, 618
        }
    }
}
