using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.CommonWeb.Models
{
    public class PageResult : ResultBase
    {
        /// <summary>
        /// 第几页
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 总户数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 取几个
        /// </summary>
        public int Limit { get; set; }
    }
}
