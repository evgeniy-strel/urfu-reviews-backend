﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Project1.Data;

#nullable disable

namespace Project1.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230526085655_initial-migrations")]
    partial class initialmigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Project1.Models.Person", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Project1.Models.Prepod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PrepodName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TrackId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("b64Image")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("Prepods");
                });

            modelBuilder.Entity("Project1.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<string>>("AdditionalImages")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int>("Availability")
                        .HasColumnType("integer");

                    b.Property<int>("Benefit")
                        .HasColumnType("integer");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Interest")
                        .HasColumnType("integer");

                    b.Property<Guid>("PrepodId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("b64Image")
                        .HasColumnType("text");

                    b.Property<bool>("isMoved")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("PrepodId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Project1.Models.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<int>>("Semester")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("b64Image")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Project1.Models.Track", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("TrackName")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("b64Image")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Project1.Models.Prepod", b =>
                {
                    b.HasOne("Project1.Models.Track", "Track")
                        .WithMany("Prepods")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Project1.Models.Values", "Values", b1 =>
                        {
                            b1.Property<Guid>("PrepodId")
                                .HasColumnType("uuid");

                            b1.Property<double>("avgAvailability")
                                .HasColumnType("double precision");

                            b1.Property<double>("avgBenefit")
                                .HasColumnType("double precision");

                            b1.Property<double>("avgInterest")
                                .HasColumnType("double precision");

                            b1.Property<double>("avgRating")
                                .HasColumnType("double precision");

                            b1.Property<int>("count1")
                                .HasColumnType("integer");

                            b1.Property<int>("count2")
                                .HasColumnType("integer");

                            b1.Property<int>("count3")
                                .HasColumnType("integer");

                            b1.Property<int>("count4")
                                .HasColumnType("integer");

                            b1.Property<int>("count5")
                                .HasColumnType("integer");

                            b1.Property<int>("countReviews")
                                .HasColumnType("integer");

                            b1.HasKey("PrepodId");

                            b1.ToTable("Prepods");

                            b1.WithOwner()
                                .HasForeignKey("PrepodId");
                        });

                    b.Navigation("Track");

                    b.Navigation("Values")
                        .IsRequired();
                });

            modelBuilder.Entity("Project1.Models.Review", b =>
                {
                    b.HasOne("Project1.Models.Prepod", "Prepod")
                        .WithMany("Reviews")
                        .HasForeignKey("PrepodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prepod");
                });

            modelBuilder.Entity("Project1.Models.Track", b =>
                {
                    b.HasOne("Project1.Models.Subject", "Subject")
                        .WithMany("Tracks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Project1.Models.Prepod", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Project1.Models.Subject", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Project1.Models.Track", b =>
                {
                    b.Navigation("Prepods");
                });
#pragma warning restore 612, 618
        }
    }
}
