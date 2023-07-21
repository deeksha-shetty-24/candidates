using AutoMapper;
using Candidate.Business.Contracts;
using Candidate.Entity;
using Candidate.Model;
using Candidate.Repository.Contracts;

namespace Candidate.Business
{
    public class ApplicantBusiness : IApplicantBusiness
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;
        public ApplicantBusiness(IApplicantRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task AddUpdateApplicant(ApplicantModel applicantModel)
        {
            if (applicantModel.Id == 0)
            {
                var applicant = _mapper.Map<Applicant>(applicantModel);
                _applicantRepository.Add(applicant);
                await this._applicantRepository.SaveChangesAsync();
            }
            else
            {
                var applicant = (await _applicantRepository.GetByAsync(x => x.Id == applicantModel.Id)).SingleOrDefault();
                if (applicant != null)
                {
                    applicant.FirstName = applicantModel.FirstName;
                    applicant.LastName = applicantModel.LastName;
                    applicant.PhoneNumber = applicantModel.PhoneNumber;
                    applicant.Email = applicantModel.Email;
                    applicant.Address = applicantModel.Address;
                    applicant.ExperienceInYears = applicantModel.ExperienceInYears;
                    applicant.FileName = applicantModel.FileName;
                    applicant.ResumeFile = applicantModel.ResumeFile;
                }
                await _applicantRepository.SaveChangesAsync();
            }
        }

        public async Task<ApplicantModel> GetApplicantById(int applicantId)
        {
            var applicantModel = new ApplicantModel();
            var applicant = (await _applicantRepository.GetByAsync(x => x.Id == applicantId)).SingleOrDefault();
            if (applicant != null)
            {
                applicantModel = _mapper.Map<ApplicantModel>(applicant);
            }
            return applicantModel;
        }

        public async Task<List<ApplicantModel>> GetAllApplicants()
        {
            var applicants = await _applicantRepository.GetAllAsync();
            var applicantModels = _mapper.Map<List<ApplicantModel>>(applicants);
            return applicantModels;
        }

        public async Task DeleteApplicant(int applicantId)
        {
            var applicant = (await _applicantRepository.GetByAsync(x => x.Id == applicantId)).SingleOrDefault();
            if (applicant != null)
            {
                _applicantRepository.Remove(applicant);
                await this._applicantRepository.SaveChangesAsync();
            }
        }
    }
}
