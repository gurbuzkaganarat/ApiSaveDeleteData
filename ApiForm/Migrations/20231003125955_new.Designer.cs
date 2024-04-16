﻿// <auto-generated />
using System;
using ApiForm.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiForm.Migrations
{
    [DbContext(typeof(Context.DbContext))]
    [Migration("20231003125955_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiForm.Entity.Meta", b =>
                {
                    b.Property<int>("MetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetaId"));

                    b.Property<int>("current_page")
                        .HasColumnType("int");

                    b.Property<int>("next_page")
                        .HasColumnType("int");

                    b.Property<int>("per_page")
                        .HasColumnType("int");

                    b.Property<int>("total_count")
                        .HasColumnType("int");

                    b.Property<int>("total_pages")
                        .HasColumnType("int");

                    b.HasKey("MetaId");

                    b.ToTable("Meta");
                });

            modelBuilder.Entity("ApiForm.Entity.Player", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("RootId")
                        .HasColumnType("int");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("height_feet")
                        .HasColumnType("int");

                    b.Property<int?>("height_inches")
                        .HasColumnType("int");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("teamid")
                        .HasColumnType("int");

                    b.Property<int?>("weight_pounds")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("RootId");

                    b.HasIndex("teamid");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("ApiForm.Entity.Root", b =>
                {
                    b.Property<int>("RootId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RootId"));

                    b.Property<int>("MetaId")
                        .HasColumnType("int");

                    b.HasKey("RootId");

                    b.HasIndex("MetaId");

                    b.ToTable("Root");
                });

            modelBuilder.Entity("ApiForm.Entity.Team", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("conference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("division")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("ApiForm.Entity.Player", b =>
                {
                    b.HasOne("ApiForm.Entity.Root", null)
                        .WithMany("data")
                        .HasForeignKey("RootId");

                    b.HasOne("ApiForm.Entity.Team", "team")
                        .WithMany()
                        .HasForeignKey("teamid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("team");
                });

            modelBuilder.Entity("ApiForm.Entity.Root", b =>
                {
                    b.HasOne("ApiForm.Entity.Meta", "meta")
                        .WithMany()
                        .HasForeignKey("MetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("meta");
                });

            modelBuilder.Entity("ApiForm.Entity.Root", b =>
                {
                    b.Navigation("data");
                });
#pragma warning restore 612, 618
        }
    }
}
