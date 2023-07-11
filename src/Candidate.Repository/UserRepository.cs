using Candidate.Entity;
using Candidate.Repository.Contracts;

namespace Candidate.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly CandidateDbContext _candidateDbContext;
        public UserRepository(CandidateDbContext candidateDbContext) : base(candidateDbContext)
        {
            _candidateDbContext = candidateDbContext;
        }
    }
}
