using HospitalManager.App.Abstract;
using HospitalManager.App.Concrete;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HospitalManager.App.Common
{
    public class BaseLoginService<T> : ILoginService<T> where T : LoginAction
    {
        public List<T> Users { get; set; }
        public BaseLoginService()
        {
            Users = new List<T>();
        }

        public void Add(T user)
        {
            Users.Add(user);
        }

        public List<T> GetAll()
        {
            return Users;
        }

        public void Remove(T user)
        {
            Users.Remove(user);
        }

        public LoginAction GetUser(LoginAction userToLogIn)
        {
            var user = Users.FirstOrDefault(p => p.Login == userToLogIn.Login && p.Password == userToLogIn.Password);
            return user;
        }


    }
}
