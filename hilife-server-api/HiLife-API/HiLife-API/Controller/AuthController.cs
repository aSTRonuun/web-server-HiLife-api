using HiLife_API.Business;
using HiLife_API.Data.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiLife_API.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("Patient/signin")]
        public IActionResult Signin([FromBody] PatientVO patient)
        {
            if (patient == null) return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(patient);

            if (token == null) return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("Patient/register")]
        public IActionResult Register([FromBody] PatientVO patient)
        {
            if (patient == null) return BadRequest("Invalid client request");

            var token = _loginBusiness.CreateCredentials(patient);

            if (token == null) return Unauthorized();

            return Ok(token);
        }


    }
}
