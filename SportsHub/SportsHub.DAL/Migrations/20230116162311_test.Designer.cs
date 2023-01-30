﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SportsHub.DAL.Data;

#nullable disable

namespace SportsHub.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230116162311_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("ArticleUser", b =>
                {
                    b.Property<int>("ArticlesId")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorsId")
                        .HasColumnType("integer");

                    b.HasKey("ArticlesId", "AuthorsId");

                    b.HasIndex("AuthorsId");

                    b.ToTable("ArticleUser");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("ArticlePicture")
                        .HasColumnType("bytea");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("PostedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StateId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(450)
                        .IsUnicode(true)
                        .HasColumnType("character varying(450)");

                    b.Property<DateTime>("PostedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.CommentLike", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("CommentId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsLike")
                        .HasColumnType("boolean");

                    b.HasKey("UserId", "CommentId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentLike");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("SportId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SportId");

                    b.ToTable("League");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(true)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(true)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.SubLeague", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("LeagueId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SubLeague");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("LeagueId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Team");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(true)
                        .HasColumnType("character varying(75)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("bytea");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArticleUser", b =>
                {
                    b.HasOne("SportsHub.Domain.Models.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsHub.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Article", b =>
                {
                    b.HasOne("SportsHub.Domain.Models.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsHub.Domain.Models.State", "State")
                        .WithMany("Articles")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("State");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Comment", b =>
                {
                    b.HasOne("SportsHub.Domain.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsHub.Domain.Models.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.CommentLike", b =>
                {
                    b.HasOne("SportsHub.Domain.Models.Comment", "Comment")
                        .WithMany("CommentsLikes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsHub.Domain.Models.User", "User")
                        .WithMany("CommentsLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.League", b =>
                {
                    b.HasOne("SportsHub.Domain.Models.Sport", "Sport")
                        .WithMany("Leagues")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.SubLeague", b =>
                {
                    b.HasOne("SportsHub.Domain.Models.League", "League")
                        .WithMany("SubLeagues")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Team", b =>
                {
                    b.HasOne("SportsHub.Domain.Models.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.User", b =>
                {
                    b.HasOne("SportsHub.Domain.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Article", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Comment", b =>
                {
                    b.Navigation("CommentsLikes");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.League", b =>
                {
                    b.Navigation("SubLeagues");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.Sport", b =>
                {
                    b.Navigation("Leagues");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.State", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("SportsHub.Domain.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CommentsLikes");
                });
#pragma warning restore 612, 618
        }
    }
}
