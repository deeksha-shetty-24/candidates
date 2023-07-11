using Candidate.Business.Infrastructure;
using Candidate.Common;

namespace Candidate.Web.Infrastructure
{
    public static class DependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(appSettings);
            services.AddScoped<ApplicationContext>();
            services.AddMemoryCache();
            BusinessDependencyRegistry.RegisterDependency(services, appSettings);
        }
    }
}
