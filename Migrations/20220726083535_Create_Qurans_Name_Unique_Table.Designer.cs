﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurahSender.Data;

#nullable disable

namespace surah_sender.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220726083535_Create_Qurans_Name_Unique_Table")]
    partial class Create_Qurans_Name_Unique_Table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("SurahSender.Entities.Quran", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("MessageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Qurans");
                });
#pragma warning restore 612, 618
        }
    }
}
