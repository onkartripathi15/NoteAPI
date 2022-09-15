using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteAPI.IServices;
using NoteAPI.Models;

namespace NoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost]
        public IActionResult Post([FromBody]User model)
        {
            var user = _authenticateService.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new
                {
                    message = "Usernaem or password is incorrect"
                });
            return Ok(user);

        }
    }
}
