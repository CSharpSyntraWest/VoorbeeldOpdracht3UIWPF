﻿// <auto-generated />
using System;
using BierenWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BierenWebAPI.Migrations
{
    [DbContext(typeof(BierenDbContext))]
    [Migration("20210127134956_CodeFirstInit")]
    partial class CodeFirstInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BierenWebAPI.Data.Bier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Alcohol")
                        .HasColumnType("float");

                    b.Property<int?>("BrouwerId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("SoortId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrouwerId");

                    b.HasIndex("SoortId");

                    b.ToTable("Bier");
                });

            modelBuilder.Entity("BierenWebAPI.Data.Brouwer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("BrNaam")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Gemeente")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("Omzet")
                        .HasColumnType("int");

                    b.Property<short?>("PostCode")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Brouwer");
                });

            modelBuilder.Entity("BierenWebAPI.Data.Soort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SoortNaam")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Soort");
                });

            modelBuilder.Entity("BierenWebAPI.Data.Bier", b =>
                {
                    b.HasOne("BierenWebAPI.Data.Brouwer", "Brouwers")
                        .WithMany("Bieren")
                        .HasForeignKey("BrouwerId")
                        .HasConstraintName("FK_Bieren_Brouwers");

                    b.HasOne("BierenWebAPI.Data.Soort", "Soorten")
                        .WithMany("Bieren")
                        .HasForeignKey("SoortId")
                        .HasConstraintName("FK_Bieren_Soorten");
                });
#pragma warning restore 612, 618
        }
    }
}