using HT.EFCode.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HT.EFCode.EntityConfig
{
    public class UserAndRoleEntityConfig : IEntityTypeConfiguration<UserAndRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserAndRoleEntity> builder)
        {
            builder.ToTable("HT_UserAndRole");
            builder.HasKey(e => new { e.UserId, e.RoleId });
            builder.Property(e => e.RoleId).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
            //SetNull依赖实体的外键被设为null。这种级联行为只对被上下文跟踪到的实体有效。数据库里也需要设置相应的级联，
            //确保没有被上下文跟踪到的数据也具备同样的行为。如果你通过EF来创建数据库，那么EF会为你设置好数据库的级联。
            builder.HasOne(e => e.User).WithMany(e => e.UserAndRoleEntitys).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Role).WithMany(e => e.UserAndRoleEntitys).HasForeignKey(e => e.RoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
