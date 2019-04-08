using HT.EFCode.Entitys.Enmus;
using System;
using System.Collections.Generic;
using System.Text;

namespace HT.Services.User.Dto
{
    public class CreateUserDto
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; } = true;
        /// <summary>
        /// 性别
        /// </summary>
        public Genders Gender { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCard { get; set; }
    }
}
