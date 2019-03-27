using HT.EFCode.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HT.EFCode.EntityConfig
{
    public class PermissionConfig : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.ToTable("HT_Permissions");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.OperationsCode).IsRequired().HasMaxLength(254);
        }
    }
}
