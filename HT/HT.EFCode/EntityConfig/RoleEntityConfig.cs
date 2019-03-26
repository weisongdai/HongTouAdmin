using HT.EFCode.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HT.EFCode.EntityConfig
{
    public class RoleEntityConfig : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {

            builder.ToTable("HT_Roles")
                .Property(e => e.Name).IsRequired().HasMaxLength(40);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(254);
        }
    }
}
