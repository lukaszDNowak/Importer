﻿// <auto-generated />
using System;
using Importer.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Importer.Migrations
{
    [DbContext(typeof(ImporterContext))]
    [Migration("20200828152719_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Importer.Models.AdditionStdScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModuleId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StdS06")
                        .HasColumnType("int");

                    b.Property<int>("StdS07")
                        .HasColumnType("int");

                    b.Property<int>("StdS08")
                        .HasColumnType("int");

                    b.Property<int>("StdS09")
                        .HasColumnType("int");

                    b.Property<int>("StdS10")
                        .HasColumnType("int");

                    b.Property<int>("StdS11")
                        .HasColumnType("int");

                    b.Property<int>("StdS12")
                        .HasColumnType("int");

                    b.Property<int>("StdS13")
                        .HasColumnType("int");

                    b.Property<int>("StdS14")
                        .HasColumnType("int");

                    b.Property<int>("StdS15")
                        .HasColumnType("int");

                    b.Property<int>("StdS16")
                        .HasColumnType("int");

                    b.Property<int>("StdS17")
                        .HasColumnType("int");

                    b.Property<int>("StdS18")
                        .HasColumnType("int");

                    b.Property<int>("StdS19")
                        .HasColumnType("int");

                    b.Property<int>("StdS20")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("additionStdScores");
                });

            modelBuilder.Entity("Importer.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("modules");
                });

            modelBuilder.Entity("Importer.Models.ModuleErrorLookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Qnum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Target")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("moduleErrorLookups");
                });

            modelBuilder.Entity("Importer.Models.ModuleLookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Band")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("SkillLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StandardScore")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("moduleLookups");
                });

            modelBuilder.Entity("Importer.Models.MultiplicationStdScores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModuleId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StdS06")
                        .HasColumnType("int");

                    b.Property<int>("StdS07")
                        .HasColumnType("int");

                    b.Property<int>("StdS08")
                        .HasColumnType("int");

                    b.Property<int>("StdS09")
                        .HasColumnType("int");

                    b.Property<int>("StdS10")
                        .HasColumnType("int");

                    b.Property<int>("StdS11")
                        .HasColumnType("int");

                    b.Property<int>("StdS12")
                        .HasColumnType("int");

                    b.Property<int>("StdS13")
                        .HasColumnType("int");

                    b.Property<int>("StdS14")
                        .HasColumnType("int");

                    b.Property<int>("StdS15")
                        .HasColumnType("int");

                    b.Property<int>("StdS16")
                        .HasColumnType("int");

                    b.Property<int>("StdS17")
                        .HasColumnType("int");

                    b.Property<int>("StdS18")
                        .HasColumnType("int");

                    b.Property<int>("StdS19")
                        .HasColumnType("int");

                    b.Property<int>("StdS20")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("multiplicationStdScores");
                });

            modelBuilder.Entity("Importer.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<string>("Module")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Qnum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Response01")
                        .HasColumnType("int");

                    b.Property<int>("Response02")
                        .HasColumnType("int");

                    b.Property<int>("Response03")
                        .HasColumnType("int");

                    b.Property<int>("Response04")
                        .HasColumnType("int");

                    b.Property<string>("Section")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("Importer.Models.Settings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calculator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountdownTimer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinishAfterCorrectInRow")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinishAfterCorrectTotal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinishAfterIncorrectInRow")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinishAfterIncorrectTotal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarkAsProbablyGuessAfterXIncorrectAnswersAditional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarkAsProbablyGuessAfterXIncorrectAnswersInRow")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarkAsProbablyGuessAfterXIncorrectAnswersMultiplication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModuleId")
                        .HasColumnType("int");

                    b.Property<int>("ModuleNumber")
                        .HasColumnType("int");

                    b.Property<string>("ReportFull")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportSections")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportSummary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Timer")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ModuleId");

                    b.ToTable("settings");
                });

            modelBuilder.Entity("Importer.Models.AdditionStdScore", b =>
                {
                    b.HasOne("Importer.Models.Module", null)
                        .WithMany("AdditionStdScores")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("Importer.Models.ModuleErrorLookup", b =>
                {
                    b.HasOne("Importer.Models.Module", null)
                        .WithMany("ModuleErrorLookups")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("Importer.Models.ModuleLookup", b =>
                {
                    b.HasOne("Importer.Models.Module", null)
                        .WithMany("ModuleLookups")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("Importer.Models.MultiplicationStdScores", b =>
                {
                    b.HasOne("Importer.Models.Module", null)
                        .WithMany("MultiplicationStdScores")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("Importer.Models.Question", b =>
                {
                    b.HasOne("Importer.Models.Module", null)
                        .WithMany("Questions")
                        .HasForeignKey("ModuleId");
                });

            modelBuilder.Entity("Importer.Models.Settings", b =>
                {
                    b.HasOne("Importer.Models.Module", null)
                        .WithMany("Settings")
                        .HasForeignKey("ModuleId");
                });
#pragma warning restore 612, 618
        }
    }
}
