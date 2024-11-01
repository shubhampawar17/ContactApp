using ContactApp.Models.ContactApp.Models;
using ContactApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Controller
{
    public class UserController
    {
        private readonly UserService _userService = new UserService();

        public void AddUser(User user)
        {
            _userService.AddUser(user);
        }
        public void ModifyUser(int id, string name)
        {
            _userService.ModifyUser(id, name);
        }
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }
        //===================================================================================
        //private readonly UserService _userService = new UserService();

        //public void AddUser(User user) => _userService.AddUser(user);

        //public void ModifyUser(int id, string name) => _userService.ModifyUser(id, name);

        //public void DeleteUser(int id) => _userService.DeleteUser(id);

        //public List<User> GetAllUsers() => _userService.GetAllUsers();

        //public User GetUserById(int id) => _userService.GetUserById(id);
        //public User FindUserById(int id) => _userService.GetUserById(id);
    }
}