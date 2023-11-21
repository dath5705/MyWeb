using Microsoft.AspNetCore.Mvc;
using MyWeb.Commands;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterAndLoginController : Controller
    {
        private readonly ILogger<RegisterAndLoginController> logger;
        private readonly MyWebDatabase database;

        public RegisterAndLoginController(ILogger<RegisterAndLoginController> logger, MyWebDatabase database)
        {
            this.logger = logger;
            this.database = database;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromForm] RegisterUser command)
        {
            var user = new User()
            {
                UserName = command.UserName,
                Password = command.Password,
            };
            database.Users.Add(user);
            database.SaveChanges();
            return Ok("Register Successed.");

        }
        [HttpGet("Register")]
        public IActionResult Register1()
        {
            var listUser = database.Users.ToList();
            return Ok(listUser);
        }
        [HttpGet("Login")]
        public IActionResult Login([FromQuery] RegisterUser command)
        {
            var user = database.Users.FirstOrDefault(user => user.UserName == command.UserName);
            if (user == null)
            {
                return BadRequest(" No have this username.");
            }
            if (user.Password != command.Password) 
            {
                return BadRequest("Wrong password.");
            }
            return Ok("Login Successed.");
        }
    } 

 

}
