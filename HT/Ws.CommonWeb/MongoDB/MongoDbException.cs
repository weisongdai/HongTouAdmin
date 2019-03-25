using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ws.CommonWeb.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    public class MongoDbException : Exception
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
        /// <param name="line"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public MongoDbException([CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null)
        {
            this.Line = line;
            this.Path = path;
            this.Name = name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="line"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public MongoDbException(string message, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null) : base(message)
        {
            this.Line = line;
            this.Path = path;
            this.Name = name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="line"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public MongoDbException(string message, Exception innerException, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null) : base(message, innerException)
        {
            this.Line = line;
            this.Path = path;
            this.Name = name;
        }
    }
}
