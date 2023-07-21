using Candidate.Entity;
using Candidate.Repository.Contracts;

namespace Candidate.Repository
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        private readonly CandidateDbContext _dbContext;
        public ApplicantRepository(CandidateDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
