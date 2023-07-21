using AutoMapper;
using Candidate.Entity;
using Candidate.Model;

namespace Candidate.Web.Infrastructure
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Entity to Model
            CreateMap<Applicant, ApplicantModel>();

            // Model to Entity
            CreateMap<ApplicantModel, Applicant>();
        }
    }
}
