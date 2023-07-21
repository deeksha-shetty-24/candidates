using Candidate.Business.Contracts;
using Candidate.Common;
using Candidate.Repository.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Candidate.Business.Infrastructure
{
    public static class BusinessDependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services, AppSettings appSettings)
        {
            RepositoryDependencyRegistry.RegisterDependency(services, appSettings);
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddTransient<IApplicantBusiness, ApplicantBusiness>();
        }
    }
}
