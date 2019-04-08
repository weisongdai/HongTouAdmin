using System;
using System.Collections.Generic;
using System.Text;

namespace Ws.CommonWeb.StaticHelper
{
    public static class StrHelper
    {
        /// <summary>
        /// 随机创建一个length长度的字符串,字母数字
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CreateStr(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string str = "0123456789abcdefghigklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()_+<>?,./";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                var number = random.Next(0, str.Length);
                stringBuilder.Append(str[number]);
            }
            return stringBuilder.ToString();
        }
    }
}
