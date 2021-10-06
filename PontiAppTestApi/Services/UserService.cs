using Microsoft.Extensions.Logging;
using System.Collections.Generic;



namespace WebApplication.Services
{
    public class UserService : IUserService
    {
        
        
        private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            { "test1", "password1" },
            { "test2", "password2" },
            { "admin", "securePassword" }
        };


        public UserService()
        {
            
        }

        public bool IsValidUserCredentials(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return false;

            return _users.TryGetValue(userName, out var pass) && pass == password;
        }

        public bool IsAnExistingUser(string userName)
        {
           return _users.ContainsKey(userName);
        }

        public string GetUserRole(string userName)
        {
            if (!IsAnExistingUser(userName))
                return string.Empty;

            if (userName == "admin")
                return UserRoles.Admin;

            return UserRoles.BasicUser;
        }
        
    }

    public static class UserRoles
    {
        public const string Admin = nameof(Admin);
        public const string BasicUser = nameof(BasicUser);
    }
}