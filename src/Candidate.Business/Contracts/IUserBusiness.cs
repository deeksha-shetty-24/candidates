using Candidate.Model;

namespace Candidate.Business.Contracts
{
    public interface IUserBusiness
    {
        Task<AuthenticationModel> GetUserDetails(LoginModel loginModel);
    }
}
