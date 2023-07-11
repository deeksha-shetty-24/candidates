using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Candidate.Web.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseController
    {
        public UserController() { }


        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        //{
        //    var authModel = await _userBusiness.GetUserDetails(loginModel);
        //    if (authModel.Error == null)
        //    {
        //        await _userBusiness.PopulateJwtTokenAsync(authModel);
        //        await _userBusiness.UpdatelastLogin(authModel);
        //    }
        //    return Ok(authModel);
        //}
    }
}
