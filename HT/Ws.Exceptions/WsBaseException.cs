using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ws.Exceptions
{
    public class WsBaseException : Exception
    {
        /// <summary>
        /// 错误的代码行数
        /// </summary>
        public int Line { get; private set; }
        /// <summary>
        /// 错误代码的路径
        /// </summary>
        public string Path { get; private set; }
        /// <summary>
        /// 错误代码的属性名或方法名
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public WsBaseException()
        {

        }
        /// <summary>
        /// 创建全局异常
        /// </summary>
        /// <param name="message">错误的信息</param>
        /// <param name="line">错误代码的行号</param>
        /// <param name="path">错误代码的路径</param>
        /// <param name="name">错误代码的属性名或方法名</param>
        public WsBaseException(string message, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null) : base(message)
        {
            this.Line = line;
            this.Path = path;
            this.Name = name;
        }
        /// <summary>
        /// 创建全局异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="line">错误代码的行号</param>
        /// <param name="path">错误代码的路径</param>
        /// <param name="name">错误代码的属性名或方法名</param>
        public WsBaseException(string message, Exception innerException, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null) : base(message, innerException)
        {
            this.Line = line;
            this.Path = path;
            this.Name = name;
        }
    }
}
