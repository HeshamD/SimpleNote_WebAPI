




namespace SimpleNote_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ISecurityServices _securityServices;
        public LoginController( ISecurityServices securityServices)
        {
            _securityServices = securityServices;
        }

        [AllowAnonymous] // prevent the authentication process to happen // at the point of calling this method || LOGIN
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDto _UserLoginDto)
        {
            var user = _securityServices.Authenticate(_UserLoginDto);
            if(user == null)
            {
                return StatusCode(404, "User Not Found");
            }

            if(user!=null)
            {
                var token = _securityServices.GenerateToken(user); // generate token if the user exist, this user will contain all the user details
                return StatusCode(200,token);
            }

            return StatusCode(401, "Not authorized");
        }


        
    }
}
