using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ws.CommonWeb.MongoDB.IServices
{
    /// <summary>
    /// Mongo操作类
    /// </summary>
    public interface IMongoService
    {
        /// <summary>
        /// 操作的数据库
        /// </summary>
        string DatabaseName { get; set; }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<long> DeleteManyAsync<T>(Expression<Func<T, bool>> options = null) where T : class, new();
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<long> DeleteAsync<T>(Expression<Func<T, bool>> options = null) where T : class, new();
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task UpdateOneAsyns<T>(T input, Expression<Func<T, bool>> options = null) where T : class, new();
        /// <summary>
        /// 获取多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> options = null) where T : class, new();
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> options = null) where T : class, new();
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<int> InsertOneAsync<T>(T input) where T : class, new();
        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<int> InsertManyAsync<T>(List<T> input) where T : class, new();
    }
}
