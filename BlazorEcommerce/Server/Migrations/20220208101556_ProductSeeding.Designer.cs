﻿// <auto-generated />
using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220208101556_ProductSeeding")]
    partial class ProductSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Five years after their dangerous journey across the post-pandemic United States, Ellie and Joel have settled down in Jackson, Wyoming. Living amongst a thriving community of survivors has allowed them peace and stability, despite the constant threat of the infected and other, more desperate survivors. When a violent event disrupts that peace, Ellie embarks on a relentless journey to carry out justice and find closure. As she hunts those responsible one by one, she is confronted with the devastating physical and emotional repercussions of her actions.",
                            ImageUrl = "https://gmedia.playstation.com/is/image/SIEPDC/the-last-of-us-part-ii-e3-2018-screen-08-ps4-us-10jul18?$1600px$",
                            Price = 45m,
                            Title = "The Last of Us Part II"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In the latest adventure in the Marvel’s Spider-Man universe, teenager Miles Morales is adjusting to his new home while following in the footsteps of his mentor, Peter Parker, as a new Spider-Man.But when a fierce power struggle threatens to destroy his new home, the aspiring hero realizes that with great power, there must also come great responsibility. To save all of Marvel’s New York, Miles must take up the mantle of Spider-Man and own it.",
                            ImageUrl = "https://gmedia.playstation.com/is/image/SIEPDC/spiderman-miles-morales-screenshot-04-disclaimer-en-01oct20?$1600px--t$",
                            Price = 55m,
                            Title = "Marvel's Spider-Man: Miles Morales"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Kratos is a father again. As mentor and protector to Atreus, a son determined to earn his respect, he is forced to deal with and control the rage that has long defined him while out in a very dangerous world with his son.His vengeance against the Gods of Olympus behind him, Kratos now lives in the realm of Norse deities and monsters.It’s in this harsh, unforgiving world that he must fight to survive, and not only teach his son to do the same… but also prevent him from repeating the Ghost of Sparta’s bloodstained mistakes.This staggering reimagining of God of War combines all the hallmarks of the iconic series – brutal combat, epic boss fights, and breathtaking scale – and fuses them with a powerful and moving narrative that re-establishes Kratos’ world. .",
                            ImageUrl = "https://gmedia.playstation.com/is/image/SIEPDC/god-of-war-screen-06-ps4-us-12jun17?$1600px$",
                            Price = 65m,
                            Title = "God of War"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}