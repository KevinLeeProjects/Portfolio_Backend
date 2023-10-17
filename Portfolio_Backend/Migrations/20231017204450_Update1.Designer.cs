﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Portfolio_Backend.Models;

#nullable disable

namespace Portfolio_Backend.Migrations
{
    [DbContext(typeof(EF_DataContext))]
    [Migration("20231017204450_Update1")]
    partial class Update1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Portfolio_Backend.Models.LoginModel", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("email");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
