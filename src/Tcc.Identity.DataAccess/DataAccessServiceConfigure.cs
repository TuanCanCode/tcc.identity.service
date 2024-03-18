using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tcc.Identity.DataAccess.Persistence.MySQL;

namespace Tcc.Identity.DataAccess
{
    public static class DataAccessServiceConfigure
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<IdentityDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseMySql(configuration.GetConnectionString("IdentityDb"), ServerVersion.AutoDetect(configuration.GetConnectionString("IdentityDb")));

            });

            return services;
        }
    }
}
