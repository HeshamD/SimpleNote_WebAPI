using Microsoft.AspNetCore.Mvc;

namespace SimpleNote_WebAPI.Controllers
{
    public class LogoutController : Controller
    {
        [HttpDelete("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            string rawUserId = HttpContext.User.FindFirstValue("id"); // getting the id value from the claims 

            if(!int.TryParse(rawUserId, out int userId))
            {
                // meaning this id is not valid 
                return StatusCode(401, "Not Valid Id.");
            }

            return StatusCode(204, "you logged out !");
        }
    }
}
