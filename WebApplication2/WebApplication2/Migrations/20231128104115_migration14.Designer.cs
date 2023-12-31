﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(WebApplication2Context))]
    [Migration("20231128104115_migration14")]
    partial class migration14
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("WebApplication2.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cart_Id")
                        .HasColumnType("int");

                    b.Property<int>("Item_Id")
                        .HasColumnType("int");

                    b.Property<int?>("itemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Cart_Id");

                    b.HasIndex("itemId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("WebApplication2.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("WebApplication2.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("WebApplication2.Models.CartItem", b =>
                {
                    b.HasOne("WebApplication2.Models.Cart", "Cart")
                        .WithMany("cartItems")
                        .HasForeignKey("Cart_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("itemId");

                    b.Navigation("Cart");

                    b.Navigation("item");
                });

            modelBuilder.Entity("WebApplication2.Models.Item", b =>
                {
                    b.HasOne("WebApplication2.Models.Product", "Product")
                        .WithMany("items")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApplication2.Models.Cart", b =>
                {
                    b.Navigation("cartItems");
                });

            modelBuilder.Entity("WebApplication2.Models.Product", b =>
                {
                    b.Navigation("items");
                });
#pragma warning restore 612, 618
        }
    }
}
