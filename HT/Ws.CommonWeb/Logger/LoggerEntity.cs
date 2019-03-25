using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.CommonWeb.Logger
{
    /// <summary>
    /// 日志
    /// </summary>
    public class LoggerEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// 记录信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public LogType LogType { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 请求路径
        /// </summary>
        public string RequestPath { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
