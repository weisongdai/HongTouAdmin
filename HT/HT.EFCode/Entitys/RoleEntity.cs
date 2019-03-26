using System;
using System.Collections.Generic;
using System.Text;

namespace HT.EFCode.Entitys
{
    public class RoleEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserAndRoleEntity> UserAndRoleEntitys { get; set; } = new HashSet<UserAndRoleEntity>();
    }
}
