using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Ws.CommonWeb.Checks;

namespace Ws.CommonWeb.Encryption
{
    public class Encryptions: IEncryptions
    {
        /// <summary>
        /// 创建MD5
        /// </summary>
        /// <returns></returns>
        public string CreateMd5(string input)
        {
            Check.NotEmpty(input, nameof(input));//检查是否为空
            return CreateMd5(Encoding.UTF8.GetBytes(input));//返回加密的MD5
        }
        /// <summary>
        /// 创建MD5
        /// </summary>
        /// <param name="input">加密的字节数组</param>
        /// <returns></returns>
        public string CreateMd5(byte[] input)
        {
            Check.NotNull(input, nameof(input));

            StringBuilder builder = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                var md5Bytes = md5.ComputeHash(input);

                foreach (var md5Byte in md5Bytes)
                {
                    builder.Append(md5Byte.ToString("X2"));
                }

            }
            return builder.ToString();
        }
        /// <summary>
        /// 创建MD5
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public string CreateMd5(Stream stream)
        {
            Check.NotNull(stream, nameof(stream));//检查是否为空
            StringBuilder builder = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                var md5Bytes = md5.ComputeHash(stream);

                foreach (var md5Byte in md5Bytes)
                {
                    builder.Append(md5Byte.ToString("X2"));
                }

            }
            return builder.ToString();
        }
    }
}
