﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.Data.DataAccess;

namespace MovieStore.Data.Migrations
{
    [DbContext(typeof(MovieStoreDbContext))]
    [Migration("20210228212111_dbCreated")]
    partial class dbCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MovieStore.Core.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(1681),
                            GenreName = "Action",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(2263),
                            GenreName = "Sci-Fi",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(2277),
                            GenreName = "Drama",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(2278),
                            GenreName = "Crime",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MovieStore.Core.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Plot")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(5245),
                            Plot = "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.",
                            Title = "The Matrix",
                            UserId = 1,
                            Year = 1999
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(5517),
                            Plot = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                            Title = "Pulp Fiction",
                            UserId = 1,
                            Year = 1999
                        });
                });

            modelBuilder.Entity("MovieStore.Core.Models.MovieGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(8411),
                            GenreId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(8444),
                            GenreId = 2,
                            MovieId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(8446),
                            GenreId = 3,
                            MovieId = 2
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 315, DateTimeKind.Local).AddTicks(8448),
                            GenreId = 4,
                            MovieId = 2
                        });
                });

            modelBuilder.Entity("MovieStore.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("MovieStore.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cdcf8fb8-1a87-4080-9ce7-ce3f35878a9a",
                            CreateDate = new DateTime(2021, 3, 1, 0, 21, 11, 313, DateTimeKind.Local).AddTicks(5608),
                            Email = "user1@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "USER1@GMAIL.COM",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAEAACcQAAAAEFLTKZM3sI4Uxec9PUhygjVEQpN2LgFi/XysXpyJYzyYbZjHwxsY2hKdFARVzTGeCQ==",
                            PhoneNumber = "NULL",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ",
                            TwoFactorEnabled = false,
                            UserName = "User1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("MovieStore.Core.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("MovieStore.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("MovieStore.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("MovieStore.Core.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieStore.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("MovieStore.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieStore.Core.Models.Genre", b =>
                {
                    b.HasOne("MovieStore.Core.Models.User", "User")
                        .WithMany("Genres")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieStore.Core.Models.Movie", b =>
                {
                    b.HasOne("MovieStore.Core.Models.User", "User")
                        .WithMany("Movies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieStore.Core.Models.MovieGenre", b =>
                {
                    b.HasOne("MovieStore.Core.Models.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieStore.Core.Models.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieStore.Core.Models.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("MovieStore.Core.Models.Movie", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("MovieStore.Core.Models.User", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
