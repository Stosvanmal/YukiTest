using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YukiTest.Domain.Interfaces;

namespace YukiTest.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void AddRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<YukiContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
                options.EnableSensitiveDataLogging(true);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
