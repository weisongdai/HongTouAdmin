using HT.EFCode.Entitys;
using HT.EFCode.Entitys.Enmus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace HT.EFCode.EntityConfig
{
    public class UserEntityConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("HT_Users");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.UserName).IsRequired().HasMaxLength(24);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(254);
            builder.Property(e => e.Avatar).HasMaxLength(254);
            builder.Property(e => e.Email).HasMaxLength(50);

            builder.Property(e => e.Enabled).HasColumnType("bit");

            builder.Property(e => e.PhoneNum).IsRequired().HasMaxLength(11);
            builder.Property(e => e.IDCard).HasMaxLength(18);
            builder.Property(e => e.Gender).IsRequired().HasDefaultValue(Genders.女);
            builder.Property(e => e.PasswordSalt).IsRequired().HasMaxLength(6);

            builder.HasIndex(e => e.IDCard).IsUnique();
            builder.HasIndex(e => e.PhoneNum).IsUnique();
        }
    }
}
