﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentClinic_WebApi.Data;

#nullable disable

namespace StudentClinic_WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230607124933_CreatePrescriptionMigration")]
    partial class CreatePrescriptionMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StudentClinic_WebApi.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Allergies")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Pesel")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Drug")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("PrescriptionCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Recommendations")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("SlotId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.VisitSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time(6)");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.ToTable("VisitSlots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new TimeOnly(9, 30, 0),
                            StartTime = new TimeOnly(9, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            EndTime = new TimeOnly(10, 0, 0),
                            StartTime = new TimeOnly(9, 30, 0)
                        },
                        new
                        {
                            Id = 3,
                            EndTime = new TimeOnly(10, 30, 0),
                            StartTime = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            EndTime = new TimeOnly(11, 0, 0),
                            StartTime = new TimeOnly(10, 30, 0)
                        },
                        new
                        {
                            Id = 5,
                            EndTime = new TimeOnly(11, 30, 0),
                            StartTime = new TimeOnly(11, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            EndTime = new TimeOnly(12, 0, 0),
                            StartTime = new TimeOnly(11, 30, 0)
                        },
                        new
                        {
                            Id = 7,
                            EndTime = new TimeOnly(12, 30, 0),
                            StartTime = new TimeOnly(12, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            EndTime = new TimeOnly(13, 0, 0),
                            StartTime = new TimeOnly(12, 30, 0)
                        },
                        new
                        {
                            Id = 9,
                            EndTime = new TimeOnly(13, 30, 0),
                            StartTime = new TimeOnly(13, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            EndTime = new TimeOnly(14, 0, 0),
                            StartTime = new TimeOnly(13, 30, 0)
                        },
                        new
                        {
                            Id = 11,
                            EndTime = new TimeOnly(14, 30, 0),
                            StartTime = new TimeOnly(14, 0, 0)
                        },
                        new
                        {
                            Id = 12,
                            EndTime = new TimeOnly(15, 0, 0),
                            StartTime = new TimeOnly(14, 30, 0)
                        },
                        new
                        {
                            Id = 13,
                            EndTime = new TimeOnly(15, 30, 0),
                            StartTime = new TimeOnly(15, 0, 0)
                        },
                        new
                        {
                            Id = 14,
                            EndTime = new TimeOnly(16, 0, 0),
                            StartTime = new TimeOnly(15, 30, 0)
                        },
                        new
                        {
                            Id = 15,
                            EndTime = new TimeOnly(16, 30, 0),
                            StartTime = new TimeOnly(16, 0, 0)
                        },
                        new
                        {
                            Id = 16,
                            EndTime = new TimeOnly(17, 0, 0),
                            StartTime = new TimeOnly(16, 30, 0)
                        });
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.Doctor", b =>
                {
                    b.HasOne("StudentClinic_WebApi.Models.User", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("StudentClinic_WebApi.Models.Doctor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.Patient", b =>
                {
                    b.HasOne("StudentClinic_WebApi.Models.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("StudentClinic_WebApi.Models.Patient", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.Prescription", b =>
                {
                    b.HasOne("StudentClinic_WebApi.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentClinic_WebApi.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.Visit", b =>
                {
                    b.HasOne("StudentClinic_WebApi.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentClinic_WebApi.Models.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentClinic_WebApi.Models.VisitSlot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("StudentClinic_WebApi.Models.User", b =>
                {
                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}
