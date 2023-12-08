using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace YukiTest.Application
{
    public static class ApplicationRegistration
    {
        public static void AddRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}