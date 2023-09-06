using Candidate.Business.Contracts;
using Candidate.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.Web.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var authModel = await _userBusiness.GetUserDetails(loginModel);
            return Ok(authModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LoginSample()
        {
            return Ok("Test");
        }
    }
}
