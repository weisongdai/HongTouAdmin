using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ws.CommonWeb.Logger.IServices;
using Ws.CommonWeb.MongoDB.IServices;

namespace Ws.CommonWeb.Logger.Services
{
    /// <summary>
    /// 日志操作
    /// </summary>
    public class LoggerService: ILoggerService
    {
        /// <summary>
        /// 
        /// </summary>
        private IMongoService _mongoService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mongoService"></param>
        public LoggerService(IMongoService mongoService)
        {
            _mongoService = mongoService;
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task Log(string msg)
        {
            await this.Log(msg, LogType.系统错误, "", "");
        }
        /// <summary>
        /// 记录一条日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="logType"></param>
        /// <param name="requestPath"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public async Task Log(string msg, LogType logType, string requestPath, string ipAddress)
        {
            var logger = new LoggerEntity()
            {
                Msg = msg,
                LogType = logType,
                RequestPath = requestPath,
                IPAddress = ipAddress
            };
            await _mongoService.InsertOneAsync(logger);
        }
    }
}
