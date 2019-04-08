using HT.EFCode.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ws.CommonWeb.Encryption;
using Ws.CommonWeb.Interfaces;
using Ws.CommonWeb.Logger.IServices;
using Ws.CommonWeb.Logger.Services;
using Ws.CommonWeb.MongoDB.IServices;
using Ws.CommonWeb.MongoDB.Services;
using Ws.CommonWeb.ObjectMap;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.AspNetCore.Builder;

namespace Ws.CommonWeb
{
    /// <summary>
    /// 
    /// </summary>
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
            serviceCollection.AddSingleton<IEncryptions, Ws.CommonWeb.Encryption.Encryptions>();
            serviceCollection.AddSingleton<IObjectMap, Ws.CommonWeb.ObjectMap.ObjectMap>();

            var serviceAssemblys = new List<Assembly> { Assembly.Load("HT.Services"), Assembly.Load("HT.Repositorys") };

            foreach (var serviceAssembly in serviceAssemblys)
            {
                var serviceTypes = serviceAssembly.GetTypes().Where(e => (!e.GetTypeInfo().IsAbstract) && e.GetInterfaces().Contains(typeof(ISupControl)));

                foreach (Type serviceType in serviceTypes)
                {
                    var interfaceTypes = serviceType.GetInterfaces().Where(e => e != typeof(ISupControl));
                    foreach (var interfaceType in interfaceTypes)
                    {
                        serviceCollection.AddTransient(interfaceType, serviceType);
                    }
                }
            }

            return serviceCollection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceDescriptors"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddEFDbContext(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddDbContextPool<HTDbContext>(options =>
            {
                options.UseMySql(configuration.GetSection("ConnectionStrings").GetSection("MySqlConnection").Value);
            });
            return serviceDescriptors;
        }
        /// <summary>
        /// 添加Token
        /// </summary>
        /// <param name="serviceDescriptors"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddAuthentication(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.Configure<JwtModels.JwtSettings>(configuration.GetSection("JwtSettings"));
            var jwtSettings = new JwtModels.JwtSettings();
            configuration.Bind("JwtSettings", jwtSettings);


            serviceDescriptors.AddAuthentication(options =>
            {
                //认证中间间的配置
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;//认证方案
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//验证方案
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

            return serviceDescriptors;
        }
        /// <summary>
        /// 添加swagger
        /// </summary>
        /// <param name="serviceDescriptors"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "PledgeApi", Version = "v1" });

                option.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "请输入Token",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });


                //Json Token认证方式，此方式为全局添加
                option.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Enumerable.Empty<string>() }
                });

                var basePath = Path.GetDirectoryName(Assembly.Load("HT.Web").Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(basePath, "HT.Web.xml");
                option.IncludeXmlComments(xmlPath);
            });
            return serviceDescriptors;
        }
        /// <summary>
        /// 注册swagger
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerMid(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.ShowExtensions();
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "红头 V1");
            });


            app.UseAuthentication();

            return app;
        }

    }
}
