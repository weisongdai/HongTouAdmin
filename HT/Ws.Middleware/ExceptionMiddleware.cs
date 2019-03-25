using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Ws.Middleware
{
    /// <summary>
    /// 全局异常处理中间件
    /// </summary>
    public class ExceptionMiddleware
    {
        #region 构造函数 字段
        /// <summary>
        /// 请求上下文
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 调用方法
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);//传入委托执行
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);//处理异常
            }
        }
        /// <summary>
        /// 异常处理函数
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <param name="exception">异常信息</param>
        /// <returns></returns>
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null)
                return;
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <param name="exception">异常信息</param>
        /// <returns></returns>
        private static async Task WriteExceptionAsync(HttpContext context, Exception exception)
        {
            //记录日志
            //LogHelper.Error(exception.GetBaseException().ToString());

            //返回友好的提示
            var response = context.Response;

            //状态码
            if (exception is UnauthorizedAccessException)
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            else if (exception is Exception)
                response.StatusCode = (int)HttpStatusCode.BadRequest;

            response.ContentType = "application/json; charset=utf-8";

            await response.WriteAsync("" + exception.Message).ConfigureAwait(false);

        } 
        #endregion
    }
}
