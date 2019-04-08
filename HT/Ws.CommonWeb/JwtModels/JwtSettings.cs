using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.CommonWeb.JwtModels
{
    public class JwtSettings
    {
        /// <summary>
        /// 颁发者
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// 使用者
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        public string SecretKey { get; set; } 

    }
}
