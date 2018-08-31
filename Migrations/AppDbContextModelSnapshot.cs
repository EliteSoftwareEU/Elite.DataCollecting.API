﻿// <auto-generated />
using System;
using Elite.DataCollecting.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Elite.DataCollecting.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Elite.DataCollecting.API.Models.DocumentData", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DocumentImportedPath");

                    b.Property<string>("DocumentText")
                        .HasColumnType("text");

                    b.Property<string>("FileName");

                    b.Property<DateTime>("ImportedDate");

                    b.Property<string>("Sentences")
                        .HasColumnType("jsonb");

                    b.HasKey("ID");

                    b.ToTable("DocumentData");
                });
#pragma warning restore 612, 618
        }
    }
}
