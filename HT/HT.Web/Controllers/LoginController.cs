using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HT.Services.Login.Dto;
using HT.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ws.CommonWeb.Checks;
using Ws.CommonWeb.Encryption;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Ws.CommonWeb.JwtModels;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Ws.CommonWeb.Models;

namespace HT.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEncryptions _encryptions;
        private readonly JwtSettings _jwtSettings;

        public LoginController(IUserService userService, IEncryptions encryptions, IOptions<JwtSettings> jwtSettingAccesser)
        {
            _userService = userService;
            _encryptions = encryptions;
            _jwtSettings = jwtSettingAccesser.Value;
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete()
        {
            return Ok("123");
        }
        [HttpPost]
        public async Task<IActionResult> Post(LoginModel userDto)
        {
            Check.NotNull(userDto, nameof(userDto));
            //获取用户信息
            var userModel = await _userService.GetUserByPhone(userDto.UserName);
            //检查是否为空或禁用
            if (userModel == null || !userModel.Enabled)
                throw new ArgumentNullException("用户名不存在或该账号已被禁用");
            //获取加密的密码
            var md5Password = _encryptions.CreateMd5(userDto.Password + userModel.PasswordSalt);
            //判断是否一致
            if (md5Password != userModel.Password)
                throw new ArgumentNullException("帐号密码错误");
            //创建claim
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,userModel.UserName),
                new Claim(ClaimTypes.MobilePhone,userModel.PhoneNum),
                new Claim(ClaimTypes.PrimarySid,userModel.Id.ToString()),
                new Claim(ClaimTypes.Email,userModel.Email)
            };
            //创建Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            //创建creds
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //创建Token
            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims, DateTime.Now,
                DateTime.Now.AddDays(1),
                creds);
            ////////未写入数据库Token


            return new JsonResult(new ResultModel(0, "获取成功", new JwtSecurityTokenHandler().WriteToken(token)));
        }
    }
}