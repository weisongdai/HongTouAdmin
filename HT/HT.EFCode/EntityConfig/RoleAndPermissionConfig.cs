using HT.EFCode.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HT.EFCode.EntityConfig
{
    public class RoleAndPermissionConfig : IEntityTypeConfiguration<RoleAndPermissionEntity>
    {
        public void Configure(EntityTypeBuilder<RoleAndPermissionEntity> builder)
        {
            builder.ToTable("HT_RoleAndPermission");
            builder.HasKey(e => new { e.RoleId, e.PermissionId });
            builder.Property(e => e.RoleId).IsRequired();
            builder.Property(e => e.PermissionId).IsRequired();
            builder.HasOne(e => e.Permission).WithMany(e => e.RoleAndPermissions).HasForeignKey(e => e.PermissionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Role).WithMany(e => e.RoleAndPermissions).HasForeignKey(e => e.RoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
