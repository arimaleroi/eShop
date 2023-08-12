﻿// <auto-generated />
using System;
using Catalog.Host.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Catalog.Host.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("catalog_category_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("catalog_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("Catalog.Host.Data.Entities.CatalogCategory", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int?>("Id"), "catalog_category_hilo");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("CatalogCategory", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.CatalogItem", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int?>("Id"), "catalog_hilo");

                    b.Property<int>("CatalogCategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureFileName")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CatalogCategoryId");

                    b.ToTable("Catalog", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.CatalogItem", b =>
                {
                    b.HasOne("Catalog.Host.Data.Entities.CatalogCategory", "CatalogCategory")
                        .WithMany()
                        .HasForeignKey("CatalogCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
