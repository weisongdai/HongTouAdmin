using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HT.EFCode.EntityFrameworkCore;
using HT.Services.User;
using HT.Services.User.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ws.CommonWeb.Checks;
using Ws.CommonWeb.Logger.IServices;

namespace HT.Web.Controllers
{
    /// <summary>
    /// 主页信息
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IUserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerService"></param>
        /// <param name="userService"></param>
        public HomeController(ILoggerService loggerService, IUserService userService)
        {
            _loggerService = loggerService;
            _userService = userService;
        }
        /// <summary>
        /// 创建一个用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost,Authorize]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            Check.NotNull(userDto, nameof(userDto));

            await _userService.CreateUserAsync(userDto);

            return new JsonResult(null);
        }
    }
}