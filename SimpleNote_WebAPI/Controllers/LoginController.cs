




namespace SimpleNote_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private ISecurityServices _securityServices;
        public LoginController(IConfiguration config, ISecurityServices securityServices)
        {
            _config = config;
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
