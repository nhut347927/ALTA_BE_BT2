﻿// <auto-generated />
using System;
using ALTA_BE_BT2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ALTA_BE_BT2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250222162314_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ALTA_BE_BT2.Models.AllowAccess", b =>
                {
                    b.Property<int>("AllowAccessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AllowAccessId"));

                    b.Property<string>("AccessProperties")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("TableName")
                        .HasColumnType("text");

                    b.HasKey("AllowAccessId");

                    b.HasIndex("RoleId");

                    b.ToTable("AllowAccesses");
                });

            modelBuilder.Entity("ALTA_BE_BT2.Models.Intern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CitizenIdentification")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CitizenIdentificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Cvfile")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("EntranceTest")
                        .HasColumnType("real");

                    b.Property<string>("ForeignLanguage")
                        .HasColumnType("text");

                    b.Property<bool?>("FullTime")
                        .HasColumnType("boolean");

                    b.Property<bool?>("HiddenToEnterprise")
                        .HasColumnType("boolean");

                    b.Property<string>("HowToKnowAlta")
                        .HasColumnType("text");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("bytea");

                    b.Property<string>("InternAddress")
                        .HasColumnType("text");

                    b.Property<bool?>("InternEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("InternMail")
                        .HasColumnType("text");

                    b.Property<string>("InternMailReplace")
                        .HasColumnType("text");

                    b.Property<string>("InternName")
                        .HasColumnType("text");

                    b.Property<string>("InternPassword")
                        .HasColumnType("text");

                    b.Property<int?>("InternSpecialized")
                        .HasColumnType("integer");

                    b.Property<string>("InternStatus")
                        .HasColumnType("text");

                    b.Property<bool?>("Internable")
                        .HasColumnType("boolean");

                    b.Property<string>("Introduction")
                        .HasColumnType("text");

                    b.Property<string>("JobFields")
                        .HasColumnType("text");

                    b.Property<string>("LinkProduct")
                        .HasColumnType("text");

                    b.Property<string>("Major")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<bool?>("PasswordStatus")
                        .HasColumnType("boolean");

                    b.Property<bool?>("ReadyToWork")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("RegisteredDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TelephoneNum")
                        .HasColumnType("text");

                    b.Property<string>("University")
                        .HasColumnType("text");

                    b.Property<short?>("YearOfExperiences")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Interns");
                });

            modelBuilder.Entity("ALTA_BE_BT2.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ALTA_BE_BT2.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ALTA_BE_BT2.Models.AllowAccess", b =>
                {
                    b.HasOne("ALTA_BE_BT2.Models.Role", "Role")
                        .WithMany("AllowAccesses")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ALTA_BE_BT2.Models.User", b =>
                {
                    b.HasOne("ALTA_BE_BT2.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ALTA_BE_BT2.Models.Role", b =>
                {
                    b.Navigation("AllowAccesses");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
