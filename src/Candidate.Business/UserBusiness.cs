using Candidate.Business.Contracts;
using Candidate.Repository.Contracts;

namespace Candidate.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task GetUserDetails()
        {
            //await _userRepository.GetByAsync(x=>x.)
        }
    }
}