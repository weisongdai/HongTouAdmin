using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HT.Web
{
    public class Program
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //构建宿主服务
            CreateWebHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// 构建宿主服务,加载配置信息,管道事件
        /// IWebHostBuilder:里可以设置webServer的环境
        /// WebHost.CreateDefaultBuilder(args)://默认设置
        ///     :使用 Kestrel Web Server 服务器(监听HTTP请求) Core内置 跨平台(默认)
        ///     :IIS集成 
        ///         UseIIS(),会启动.net core 的 CLR 并且把Web应用 放在IISWorkProseese里(进程) 这个进程要么是W3WP.exe 要么就是IISExprise.exe
        ///         UserIISIntegration() 假如运行IIS服务器,允许IIS通过Windows的凭证验证来到Kestrel(对于构建内网的应用有用,)  
        ///     :Log 配置了Log
        ///     :IConfiguration 接口
        ///     
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)//默认设置
                .UseStartup<Startup>();
    }
}
