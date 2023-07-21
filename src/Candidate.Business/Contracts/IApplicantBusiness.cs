using Candidate.Model;

namespace Candidate.Business.Contracts
{
    public interface IApplicantBusiness
    {
        Task AddUpdateApplicant(ApplicantModel applicantModel);
        Task<ApplicantModel> GetApplicantById(int applicantId);
        Task<List<ApplicantModel>> GetAllApplicants();
        Task DeleteApplicant(int applicantId);
    }
}
