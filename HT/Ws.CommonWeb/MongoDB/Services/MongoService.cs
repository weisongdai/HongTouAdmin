using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Ws.CommonWeb.MongoDB.IServices;

namespace Ws.CommonWeb.MongoDB.Services
{
    /// <summary>
    /// MongoDb操作类
    /// </summary>
    public class MongoService : IMongoService
    {
        #region 字段构造函数
        /// <summary>
        /// 操作的数据仓库名称
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// 连接客户端
        /// </summary>
        private readonly IMongoClient _mongoClient;
        /// <summary>
        /// 操作的数据库
        /// </summary>
        private readonly IMongoDatabase _mongoDatabase;
        /// <summary>
        /// 创建Mogo
        /// </summary>
        /// <param name="configuration"></param>
        public MongoService(IConfiguration configuration)
        {
            this._mongoClient = new MongoClient(configuration["MongoConnection:ConnectionString"] ?? throw new MongoDbException("配置Mongo链接错误"));
            this.DatabaseName = configuration["MongoConnection:Database"];
            _mongoDatabase = _mongoClient.GetDatabase(DatabaseName);
        }
        #endregion
        
        #region 方法
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="t">实体集合</param>
        /// <returns></returns>
        public async Task<int> InsertManyAsync<T>(List<T> input) where T : class, new()
        {
            try
            {
                var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
                await collection.InsertManyAsync(input);
                return 1;
            }
            catch (Exception ex)
            {
                throw new MongoDbException("添加出错", ex);
            }
        }
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<int> InsertOneAsync<T>(T input) where T : class, new()
        {
            try
            {
                var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
                await collection.InsertOneAsync(input);
                return 1;
            }
            catch (Exception ex)
            {
                throw new MongoDbException("添加出错", ex);
            }
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<T> GetSingleAsync<T>(Expression<Func<T, bool>> options = null) where T : class, new()
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            return await collection.Find(options).SingleOrDefaultAsync();
        }
        /// <summary>
        /// 获取筛选的数据
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="options">筛选</param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> options = null) where T : class, new()
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            return await collection.Find(options).ToListAsync();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task UpdateOneAsyns<T>(T input, Expression<Func<T, bool>> options = null) where T : class, new()
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            var list = new List<UpdateDefinition<T>>();
            foreach (var item in input.GetType().GetProperties())
            {
                if (item.Name.ToLower() == "id") continue;
                list.Add(Builders<T>.Update.Set(item.Name, item.GetValue(input)));
            }
            var updatefilter = Builders<T>.Update.Combine(list);
            await collection.UpdateOneAsync<T>(options, updatefilter);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<long> DeleteAsync<T>(Expression<Func<T, bool>> options = null) where T : class, new()
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            var result = await collection.DeleteOneAsync<T>(options);
            return result.DeletedCount;
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<long> DeleteManyAsync<T>(Expression<Func<T, bool>> options = null) where T : class, new()
        {
            var collection = _mongoDatabase.GetCollection<T>(typeof(T).Name);
            var result = await collection.DeleteManyAsync<T>(options);
            return result.DeletedCount;
        } 
        #endregion
    }
}
