using ECommerce.Domain.Abstractions;
using ECommerce.Infrastructure.DataContext;
using ECommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.DI
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            #region Database

            var connectionstring = configuration.GetConnectionString("ECommerceRead");
            services.AddDbContext<ECommerceReadContext>(option => option.UseSqlServer(connectionstring));

            var connectionstringwrite = configuration.GetConnectionString("ECommerceWrite");
            services.AddDbContext<ECommerceWriteContext>(option => option.UseSqlServer(connectionstringwrite));

            #endregion

            #region Inject Repos
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion

            return services;
        }
    }
}
