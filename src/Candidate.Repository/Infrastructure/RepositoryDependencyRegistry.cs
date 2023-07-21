using Candidate.Common;
using Candidate.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Candidate.Repository.Infrastructure
{
    public static class RepositoryDependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<CandidateDbContext>(options =>
            {
                options.UseSqlServer(appSettings.CandidateDbConnectionString);
            });
            services.AddDbContext<CandidateDbContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IApplicantRepository, ApplicantRepository>();
        }
    }
}
