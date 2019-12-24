﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Lib.DAL.EFCore.Context;

namespace Project.Lib.DAL.EFCore.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20191220191738_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Common.Lib.Core.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Entity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entity");
                });

            modelBuilder.Entity("Project.Lib.Models.Student", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<int>("ChairNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dni")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Guid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Project.Lib.Models.Subject", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<string>("Name")
                        .HasColumnName("Subject_Name")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
