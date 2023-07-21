using Candidate.Business.Contracts;
using Candidate.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Candidate.Web.Controllers
{
    [Route("api/applicant")]
    [Authorize(AuthenticationSchemes = "ClientKey")]
    public class ApplicantController : BaseController
    {
        private readonly IApplicantBusiness _applicantBusiness;
        public ApplicantController(IApplicantBusiness applicantBusiness)
        {
            _applicantBusiness = applicantBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicant([FromForm] string candidate, [FromForm] IFormFile file)
        {
            var applicantModel = JsonConvert.DeserializeObject<ApplicantModel>(candidate);
            if (file != null && file.Length > 0 && applicantModel != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    applicantModel.ResumeFile = fileBytes;
                }
                await _applicantBusiness.AddUpdateApplicant(applicantModel);
            }
            return Ok();
        }

        [HttpGet("GetApplicantById/{applicantId}")]
        public async Task<IActionResult> GetApplicantById(int applicantId)
        {
            var applicant = await _applicantBusiness.GetApplicantById(applicantId);
            return Ok(applicant);
        }

        [HttpGet("GetAllApplicants")]
        public async Task<IActionResult> GetAllApplicants()
        {
            var applicants = await _applicantBusiness.GetAllApplicants();
            return Ok(applicants);
        }

        [HttpDelete("{applicantId}")]
        public async Task<IActionResult> DeleteApplicant(int applicantId)
        {
            await _applicantBusiness.DeleteApplicant(applicantId);
            return Ok();
        }

        [HttpPost("DownloadFile/{applicantId}")]
        public async Task<IActionResult> DownloadFile(int applicantId)
        {
            var applicant = await _applicantBusiness.GetApplicantById(applicantId);
            return File(applicant.ResumeFile, "application/pdf", fileDownloadName: applicant.FileName);
        }
    }
}
