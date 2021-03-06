﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bildExamNew.Data;

namespace bildExamNew.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190212210532_ChangePriceToDecimal")]
    partial class ChangePriceToDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bildExamNew.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DeviceTypeId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("bildExamNew.Models.DevicePropertyValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceId");

                    b.Property<int>("DeviceTypePropertyId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("DeviceTypePropertyId");

                    b.ToTable("DevicePropertyValues");
                });

            modelBuilder.Entity("bildExamNew.Models.DeviceTypeProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceTypeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("DeviceTypesProperties");
                });

            modelBuilder.Entity("bildExamNew.Models.DeviceTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ParentTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ParentTypeId");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("bildExamNew.Models.Device", b =>
                {
                    b.HasOne("bildExamNew.Models.DeviceTypes", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bildExamNew.Models.DevicePropertyValues", b =>
                {
                    b.HasOne("bildExamNew.Models.Device", "Device")
                        .WithMany("PropertyValues")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("bildExamNew.Models.DeviceTypeProperties", "DeviceTypeProperty")
                        .WithMany("PropertiesValue")
                        .HasForeignKey("DeviceTypePropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bildExamNew.Models.DeviceTypeProperties", b =>
                {
                    b.HasOne("bildExamNew.Models.DeviceTypes", "DeviceType")
                        .WithMany("TypeProperties")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bildExamNew.Models.DeviceTypes", b =>
                {
                    b.HasOne("bildExamNew.Models.DeviceTypes", "ParentType")
                        .WithMany("ChildrenType")
                        .HasForeignKey("ParentTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
