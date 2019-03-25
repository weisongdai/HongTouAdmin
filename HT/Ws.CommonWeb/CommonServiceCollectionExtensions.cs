using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ws.CommonWeb.Logger.IServices;
using Ws.CommonWeb.Logger.Services;
using Ws.CommonWeb.MongoDB.IServices;
using Ws.CommonWeb.MongoDB.Services;

namespace Ws.CommonWeb
{
    public static class CommonServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TMongoContext"></typeparam>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddCommonService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILoggerService, LoggerService>();
            serviceCollection.AddSingleton<IMongoService, MongoService>();
            return serviceCollection;
        }
    }
}
