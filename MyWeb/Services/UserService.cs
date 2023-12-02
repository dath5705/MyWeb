using Microsoft.AspNetCore.Mvc;
using MyWeb.Models;

namespace MyWeb.Services
{
    public class UserInput
    {
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class UserService
    {
        private readonly MyWebDatabase database;
        public UserService(MyWebDatabase database ) 
        {
            this.database = database;
        }
        public string User(UserInput input)
        {
            var user = new User()
            {
                UserName = input.Name,
                Password = input.Password
            };
            database.Users.Add (user);
            database.SaveChanges();
            return "";
        }

    }
}
