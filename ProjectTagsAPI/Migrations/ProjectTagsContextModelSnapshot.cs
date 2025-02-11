﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTagsAPI.Data;

#nullable disable

namespace ProjectTagsAPI.Migrations
{
    [DbContext(typeof(ProjectTagsContext))]
    partial class ProjectTagsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectTagsAPI.Models.ProjectData", b =>
                {
                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProjectName");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectTagsAPI.Models.TagData", b =>
                {
                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CuttingTime")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("TagName");

                    b.ToTable("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
