using System;
using System.Collections.Generic;
using System.Text;

namespace HT.EFCode.Entitys
{
    public class RoleAndPermissionEntity
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
        public RoleEntity Role { get; set; }
        public PermissionEntity Permission { get; set; }

    }
}
