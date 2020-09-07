using HospitalManager.App.Abstract;
using HospitalManager.App.Common;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManager.App.Concrete
{
    public class UserService : IUserService
    {
        public List<User> Users { get; set; }
        public UserService()
        {
            Users = new List<User>();
        }

        public void Add(User user)
        {
            Users.Add(user);
        }

        public List<User> GetAll()
        {
            return Users;
        }

        public User GetUser(User userToLogIn)
        {
            var user = Users.FirstOrDefault(p => p.Login == userToLogIn.Login && p.Password == userToLogIn.Password);
            return user;
        }

        public void Remove(User user)
        {
            Users.Remove(user);
        }
    }
}
