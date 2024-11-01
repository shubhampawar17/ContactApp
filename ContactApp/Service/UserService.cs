using ContactApp.Exceptions;
using ContactApp.Models;
using ContactApp.Models.ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Service
{
    public class UserService
    {
       
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Admin", IsActive = true, IsAdmin = true },
            new User { Id = 2, Name = "Staff1", IsActive = true, IsAdmin = false },
            new User { Id = 3, Name = "Staff2", IsActive = true, IsAdmin = false }
        };

        public User GetUserById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id && u.IsActive);
            if (user == null)
                throw new UserNotFoundException("User not found or is inactive.");
            return user;
        }

        public void AddUser(User user) => _users.Add(user);

        public void ModifyUser(int id, string name)
        {
            var user = GetUserById(id);
            user.Name = name;
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            user.IsActive = false;
        }

        public List<User> GetAllUsers() => _users.Where(u => u.IsActive).ToList();

    }
}