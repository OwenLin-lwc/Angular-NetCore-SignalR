using Microsoft.AspNetCore.Mvc;
using signalr_hub.DataStorage;
using signalr_hub.Models;

namespace signalr_hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        [Route("Login")]
        public User Login([FromForm]string userName)
        {
            return Users.GetUser().Find(u => u.UserName == userName);
        }
    }
}