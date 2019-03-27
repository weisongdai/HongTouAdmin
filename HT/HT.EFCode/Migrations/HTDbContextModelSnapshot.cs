﻿// <auto-generated />
using System;
using HT.EFCode.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HT.EFCode.Migrations
{
    [DbContext(typeof(HTDbContext))]
    partial class HTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("HT.EFCode.Entitys.RoleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CareatTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("HT_Roles");
                });

            modelBuilder.Entity("HT.EFCode.Entitys.UserAndRoleEntity", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("HT_UserAndRole");
                });

            modelBuilder.Entity("HT.EFCode.Entitys.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<DateTime>("CareatTime");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<short>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue((short)1);

                    b.Property<int>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<string>("IDCard")
                        .HasMaxLength(18);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(24);

                    b.HasKey("Id");

                    b.ToTable("HT_Users");
                });

            modelBuilder.Entity("HT.EFCode.Entitys.UserAndRoleEntity", b =>
                {
                    b.HasOne("HT.EFCode.Entitys.RoleEntity", "Role")
                        .WithMany("UserAndRoleEntitys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HT.EFCode.Entitys.UserEntity", "User")
                        .WithMany("UserAndRoleEntitys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
