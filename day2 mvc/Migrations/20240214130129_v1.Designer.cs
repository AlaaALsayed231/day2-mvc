﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using day2_mvc.Models;

#nullable disable

namespace day2_mvc.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20240214130129_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("day2_mvc.Models.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MGRSSN")
                        .HasColumnType("int");

                    b.Property<DateOnly>("MGRStartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("MGRSSN")
                        .IsUnique()
                        .HasFilter("[MGRSSN] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("day2_mvc.Models.Dependent", b =>
                {
                    b.Property<int?>("ESSN")
                        .HasColumnType("int");

                    b.Property<string>("Department_name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly?>("Bdate")
                        .HasColumnType("date");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.HasKey("ESSN", "Department_name");

                    b.HasIndex("employeeId");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("day2_mvc.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("Bdate")
                        .HasColumnType("date");

                    b.Property<int?>("Dno")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Superssn")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Dno");

                    b.HasIndex("Superssn");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("day2_mvc.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dnum")
                        .HasColumnType("int");

                    b.Property<string>("Plocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Dnum");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("day2_mvc.Models.Works_For", b =>
                {
                    b.Property<int?>("ESSN")
                        .HasColumnType("int");

                    b.Property<int?>("Pno")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.HasKey("ESSN", "Pno");

                    b.HasIndex("Pno");

                    b.ToTable("WorkFor");
                });

            modelBuilder.Entity("day2_mvc.Models.Departments", b =>
                {
                    b.HasOne("day2_mvc.Models.Employee", "manger")
                        .WithOne("mangeDepartment")
                        .HasForeignKey("day2_mvc.Models.Departments", "MGRSSN");

                    b.Navigation("manger");
                });

            modelBuilder.Entity("day2_mvc.Models.Dependent", b =>
                {
                    b.HasOne("day2_mvc.Models.Employee", "employee")
                        .WithMany("dependents")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("day2_mvc.Models.Employee", b =>
                {
                    b.HasOne("day2_mvc.Models.Departments", "workDepartment")
                        .WithMany("employees")
                        .HasForeignKey("Dno");

                    b.HasOne("day2_mvc.Models.Employee", "leader")
                        .WithMany("group")
                        .HasForeignKey("Superssn");

                    b.Navigation("leader");

                    b.Navigation("workDepartment");
                });

            modelBuilder.Entity("day2_mvc.Models.Project", b =>
                {
                    b.HasOne("day2_mvc.Models.Departments", "departments")
                        .WithMany("projects")
                        .HasForeignKey("Dnum");

                    b.Navigation("departments");
                });

            modelBuilder.Entity("day2_mvc.Models.Works_For", b =>
                {
                    b.HasOne("day2_mvc.Models.Employee", "employee")
                        .WithMany("works_Fors")
                        .HasForeignKey("ESSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("day2_mvc.Models.Project", "project")
                        .WithMany("works_Fors")
                        .HasForeignKey("Pno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");

                    b.Navigation("project");
                });

            modelBuilder.Entity("day2_mvc.Models.Departments", b =>
                {
                    b.Navigation("employees");

                    b.Navigation("projects");
                });

            modelBuilder.Entity("day2_mvc.Models.Employee", b =>
                {
                    b.Navigation("dependents");

                    b.Navigation("group");

                    b.Navigation("mangeDepartment")
                        .IsRequired();

                    b.Navigation("works_Fors");
                });

            modelBuilder.Entity("day2_mvc.Models.Project", b =>
                {
                    b.Navigation("works_Fors");
                });
#pragma warning restore 612, 618
        }
    }
}
