using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HT.EFCode.EntityFrameworkCore
{
    public static class EFServiceCollectionExtensions
    {
        public static IServiceCollection AddEFDbContext(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddDbContextPool<HTDbContext>(options =>
            {
                options.UseMySQL(configuration.GetSection("ConnectionStrings").GetSection("MySqlConnection").Value);
            });
            return serviceDescriptors;
        }
    }
}
