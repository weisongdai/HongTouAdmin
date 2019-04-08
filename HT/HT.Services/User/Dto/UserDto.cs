using System;
using System.Collections.Generic;
using System.Text;

namespace HT.Services.User.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 密码盐
        /// </summary>
        public string PasswordSalt { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        public bool Enabled { get; set; }
    }
}
