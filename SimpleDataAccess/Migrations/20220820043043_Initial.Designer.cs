﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleDataAccess;

namespace SimpleDataAccess.Migrations
{
    [DbContext(typeof(SimpleDataContext))]
    [Migration("20220820043043_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("SimpleDataAccess.SchemaModels.Tweet", b =>
                {
                    b.Property<int>("TwitterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("TwitterId");

                    b.ToTable("Tweets");

                    b.HasData(
                        new
                        {
                            TwitterId = 1,
                            AuthorId = 100,
                            CreatedAt = new DateTime(2022, 8, 20, 4, 30, 43, 338, DateTimeKind.Utc).AddTicks(4783),
                            Text = "Haha!"
                        },
                        new
                        {
                            TwitterId = 2,
                            AuthorId = 101,
                            CreatedAt = new DateTime(2022, 8, 20, 4, 30, 43, 338, DateTimeKind.Utc).AddTicks(5219),
                            Text = "Boo!"
                        });
                });

            modelBuilder.Entity("SimpleDataAccess.SchemaModels.Tweet", b =>
                {
                    b.OwnsMany("SimpleDataAccess.SchemaModels.Hashtag", "Hashtags", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Text")
                                .HasColumnType("TEXT");

                            b1.Property<int>("TweetId")
                                .HasColumnType("INTEGER");

                            b1.HasKey("Id");

                            b1.HasIndex("TweetId");

                            b1.ToTable("Hashtags");

                            b1.WithOwner("Tweet")
                                .HasForeignKey("TweetId");

                            b1.Navigation("Tweet");
                        });

                    b.Navigation("Hashtags");
                });
#pragma warning restore 612, 618
        }
    }
}