using HospitalManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.Domain.Entity
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public bool IsLoggedIn { get; set; }

        public User()
        {
            IsLoggedIn = false;
        }
        public User(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
            IsLoggedIn = false;
        }
    }
}
