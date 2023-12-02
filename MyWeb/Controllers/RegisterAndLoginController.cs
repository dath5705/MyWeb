using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWeb.Commands;
using MyWeb.Models;
using MyWeb.Services;
using System.Diagnostics;

namespace MyWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterAndLoginController : Controller
    {
        private readonly ILogger<RegisterAndLoginController> logger;
        private readonly MyWebDatabase database;
        private readonly CalculationService calculationService;
        private readonly UserService userService;
        private readonly JwtService jwtService;

        public RegisterAndLoginController(ILogger<RegisterAndLoginController> logger, 
            MyWebDatabase database, 
            CalculationService calculation, 
            UserService userService,
            JwtService jwtService
            )
        {
            this.logger = logger;
            this.database = database;
            this.calculationService = calculation;
            this.userService = userService;
            this.jwtService = jwtService;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromForm] RegisterUser command)
        {
            var user = new User()
            {
                UserName = command.UserName,
                Password = command.Password,
                Revenue = 0,
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
        [HttpPost("Update")]
        public IActionResult Update()
        {
            var listUsers = database.Users.ToList();
            foreach (var u in listUsers)
            {
                u.Revenue = database.Customers.Where(c => c.UserId == u.ID).Sum(e => e.TotalMoney);
                database.Users.Update(u);
                database.SaveChanges();
            }
            return Ok("Update Successed.");
        }
        [HttpPost("Customers")]
        public IActionResult Customers([FromBody] CustomerInput command)
        {
            var customer = new Customer()
            {
                Name = command.Name,
                Number = command.Number,
                UserId = command.IDUser,
                Sex = command.Sex,
                Address = command.Address,
                TotalMoney = command.TotalMoney * 1000,
            };
            database.Customers.Add(customer);
            database.SaveChanges();
            var users = database.Users.FirstOrDefault(e => e.ID == customer.UserId);
            if (users == null)
            {
                return BadRequest();
            }
            users.Revenue = database.Customers.Where(c => c.UserId == users.ID).Sum(e => e.TotalMoney);
            database.Users.Update(users);
            database.SaveChanges();
            return Ok("Add customer successed");
        }

        // Entity Framework Core

        [HttpGet("Customers")]
        public IActionResult Customers1()
        {
            var listcustomer = database.Users.Include(e => e.Customers).ToList();
            foreach (var u in listcustomer)
            {
                if (u.Customers == null)
                {
                    return NotFound();
                }
                //var a = u.Customers!.ToList();
                foreach (var customer in u.Customers)
                {
                    Debug.WriteLine(u.UserName + " have customer " + customer.Name);
                }
            }
            return Ok();
        }

        // Dependency Injection.

        [HttpPost("Calculation")]
        public IActionResult Calculation([FromQuery] NumberInput num)
        {
            double value;
            if (num.Number1 < 10)
            {
                value = calculationService.Multiplication(num.Number1, num.Number2, num.Number3);
            }
            else
            {
                value = calculationService.Sum(num.Number1, num.Number2, num.Number3);
            }
            return Ok(value);
        }

        [HttpPost("DIUser")]
        [Authorize]
        public IActionResult User1([FromQuery] RegisterUser user)
        {
            userService.User(new UserInput
            {
                Name = user.UserName,
                Password = user.Password,
            });
            return Ok();
        }
    }



}
