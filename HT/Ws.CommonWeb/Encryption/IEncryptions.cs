using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ws.CommonWeb.Encryption
{
    public interface IEncryptions
    {
        /// <summary>
        /// 创建MD5
        /// </summary>
        /// <returns></returns>
         string CreateMd5(string input);
        /// <summary>
        /// 创建MD5
        /// </summary>
        /// <param name="input">加密的字节数组</param>
        /// <returns></returns>
         string CreateMd5(byte[] input);
        /// <summary>
        /// 创建MD5
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
         string CreateMd5(Stream stream);
    }
}
