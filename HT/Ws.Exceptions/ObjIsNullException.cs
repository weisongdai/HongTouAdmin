using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ws.Exceptions
{
    /// <summary>
    /// 对象为null,异常
    /// </summary>
    public class ObjIsNullException : WsBaseException
    {
        public override string Message { get;  }
        /// <summary>
        /// 
        /// </summary>
        public ObjIsNullException()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ObjIsNullException(string message) : base(message)
        {
            this.Message = message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ObjIsNullException(string message, Exception innerException) : base(message, innerException)
        {
            this.Message = message;
        }
    }
}
