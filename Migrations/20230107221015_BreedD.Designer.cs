﻿// <auto-generated />
using System;
using Dog_Grooming_Salon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dog_Grooming_Salon.Migrations
{
    [DbContext(typeof(Dog_Grooming_SalonContext))]
    [Migration("20230107221015_BreedD")]
    partial class BreedD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Dog_Grooming_Salon.Models.Breed", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BreedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Breed");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.Dog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentHour")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BreedID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BreedID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Dog");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.DogGender", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("DogID")
                        .HasColumnType("int");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DogID");

                    b.HasIndex("GenderID");

                    b.ToTable("DogGender");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.Gender", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.Dog", b =>
                {
                    b.HasOne("Dog_Grooming_Salon.Models.Breed", "Breed")
                        .WithMany("Dogs")
                        .HasForeignKey("BreedID");

                    b.HasOne("Dog_Grooming_Salon.Models.Owner", "Owner")
                        .WithMany("Dogs")
                        .HasForeignKey("OwnerID");

                    b.Navigation("Breed");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.DogGender", b =>
                {
                    b.HasOne("Dog_Grooming_Salon.Models.Dog", "Dog")
                        .WithMany("DogGenders")
                        .HasForeignKey("DogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dog_Grooming_Salon.Models.Gender", "Gender")
                        .WithMany("DogGenders")
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.Breed", b =>
                {
                    b.Navigation("Dogs");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.Dog", b =>
                {
                    b.Navigation("DogGenders");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.Gender", b =>
                {
                    b.Navigation("DogGenders");
                });

            modelBuilder.Entity("Dog_Grooming_Salon.Models.Owner", b =>
                {
                    b.Navigation("Dogs");
                });
#pragma warning restore 612, 618
        }
    }
}
