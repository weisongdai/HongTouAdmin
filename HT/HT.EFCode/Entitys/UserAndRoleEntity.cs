using System;
using System.Collections.Generic;
using System.Text;

namespace HT.EFCode.Entitys
{
    public class UserAndRoleEntity
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
