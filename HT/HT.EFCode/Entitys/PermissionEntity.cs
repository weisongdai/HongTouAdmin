using System;
using System.Collections.Generic;
using System.Text;

namespace HT.EFCode.Entitys
{
    /// <summary>
    /// 
    /// </summary>
    public class PermissionEntity : BaseEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string OperationsCode { get; set; }
        /// <summary>
        /// 角色导航属性
        /// </summary>
        public virtual ICollection<RoleAndPermissionEntity> RoleAndPermissions { get; set; } = new List<RoleAndPermissionEntity>();
    }
}
