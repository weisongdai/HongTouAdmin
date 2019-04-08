using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ws.CommonWeb.Checks
{
    public static class Check
    {
        /// <summary>
        /// 不能为null和空包括参数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="line"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string NotEmpty(string value, string parameterName, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null)
        {
            Exception e = null;
            if (value is null)
            {
                e = new ArgumentNullException($"{parameterName} is null , code line in {line} ,path in {path} name is {name}");
            }
            else if (value.Trim().Length == 0)
            {
                e = new ArgumentNullException($"{parameterName} is null , code line in {line} ,path in {path} name is {name}");
            }

            if (e != null)
            {
                NotEmpty(parameterName, nameof(parameterName));
                throw e;
            }
            return value;
        }
        /// <summary>
        /// 可为null但是不可以为空
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="line"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string NullButNotEmpty(string value, string parameterName, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null)
        {
            if (!(value is null) && value.Length == 0)
            {
                NotEmpty(parameterName, nameof(parameterName), line, path, name);
                throw new ArgumentNullException($"{parameterName} is null , code line in {line} ,path in {path} name is {name}");
            }

            return value;
        }
        /// <summary>
        /// 检查集合是否为null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="line"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<T> NotEmpty<T>(IEnumerable<T> value, string parameterName, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null)
        {
            NotNull(value, parameterName);

            if (value.Count() == 0)
            {
                NotEmpty(parameterName, nameof(parameterName), line, path, name);

                throw new ArgumentException($"{parameterName} is null , code line in {line} ,path in {path} name is {name}");
            }

            return value;
        }
        /// <summary>
        /// 检查是否为空对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static T NotNull<T>(T value, string parameterName,
            [CallerLineNumber] int line = -1,
            [CallerFilePath] string path = null,
            [CallerMemberName] string name = null)
        {
            if (ReferenceEquals(value, null))
            {
                NotEmpty(parameterName, nameof(parameterName), line, path, name);
                throw new ArgumentNullException($"{parameterName} is null , code line in {line} ,path in {path} name is {name}");
            }

            return value;
        }
        /// <summary>
        /// 检查对象里是否有null存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="line"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<T> HasNoNulls<T>(IEnumerable<T> value, string parameterName, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null)
           where T : class
        {
            NotNull(value, parameterName);

            if (value.Any(e => e == null))
            {
                NotEmpty(parameterName, nameof(parameterName), line, path, name);

                throw new ArgumentException($"{parameterName} is null , code line in {line} ,path in {path} name is {name}");
            }

            return value;
        }
        /// <summary>
        /// 检查值是否小于0
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static int NotLessThanZero(int value, string parameterName, [CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null)
        {
            if (value <= 0)
            {
                NotEmpty(parameterName, parameterName);
                throw new ArgumentException($"{parameterName} is null , code line in {line} ,path in {path} name is {name}");
            }
            return value;
        }
    }
}
