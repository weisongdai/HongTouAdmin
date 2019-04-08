using HT.Repositorys.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Ws.CommonWeb.ObjectMap;
using HT.Services.User.Dto;
using Ws.CommonWeb.Checks;
using Ws.Exceptions;
using Ws.CommonWeb.Interfaces;
using Ws.CommonWeb.Encryption;
using Ws.CommonWeb.StaticHelper;

namespace HT.Services.User
{
    public class UserService : IUserService, ISupControl
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptions _encryptions;

        public UserService(IUserRepository userRepository, IEncryptions encryptions)
        {
            _userRepository = userRepository;
            _encryptions = encryptions;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public async Task CreateUserAsync(CreateUserDto userDto)
        {
            Check.NotNull(userDto, nameof(userDto));

            var anyUserPhone = _userRepository
                .GetExpression(e => e.PhoneNum == userDto.PhoneNum)
                .AsNoTracking()
                .Any();
            if (anyUserPhone)
                throw new WsBaseException("已经存在的手机号");

            var userModel = _userRepository.MapTo(userDto);

            userModel.PasswordSalt = StrHelper.CreateStr(6);

            userModel.Password = _encryptions.CreateMd5(userDto.Password + userModel.PasswordSalt);


            var createResult = await _userRepository.CreateAsync(userModel);
        }
        /// <summary>
        /// 根据手机号码获取用户,后期肯能会加邮箱
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<UserDto> GetUserByPhone(string phone)
        {
            Check.NotEmpty(phone, nameof(phone));
            var resultModel = await _userRepository.GetExpression(e => e.PhoneNum == phone).AsNoTracking().FirstOrDefaultAsync();
            return _userRepository.MapTo<UserDto>(resultModel);
        }
    }
}
