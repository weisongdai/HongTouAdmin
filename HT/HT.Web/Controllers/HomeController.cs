using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ws.CommonWeb.Logger.IServices;

namespace HT.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public ILoggerService _loggerService;

        public HomeController(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public IActionResult Get()
        {
            _loggerService.Log("Get成功", Ws.CommonWeb.Logger.LogType.操作日志, Request.Path, Request.Host.Host);
            return Ok();
        }
    }
}