using HT.Services.User.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HT.Services.User
{
    public interface IUserService
    {
        /// <summary>
        /// 创建一个用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        Task CreateUserAsync(CreateUserDto userDto);
        /// <summary>
        /// 根据手机号获取用户,后期可能会添加邮箱
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<UserDto> GetUserByPhone(string phone);
    }
}
