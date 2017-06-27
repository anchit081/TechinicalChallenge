using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ConferenceBarrel.Models;

namespace ConferenceBarrel.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("ConferenceBarrel.Models.InterviewData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("no_of_products");

                    b.Property<int>("quantity");

                    b.Property<int>("spend");

                    b.Property<string>("supplier");

                    b.Property<int>("year");

                    b.HasKey("Id");

                    b.ToTable("InterviewDatas");
                });

            modelBuilder.Entity("ConferenceBarrel.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InterviewDataId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("InterviewDataId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ConferenceBarrel.Models.Session", b =>
                {
                    b.HasOne("ConferenceBarrel.Models.InterviewData", "InterviewData")
                        .WithMany("Sessions")
                        .HasForeignKey("InterviewDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
