using HospitalManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.Domain.Entity
{
    public class LoginAction : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public bool IsLoggedIn;

        public LoginAction()
        {
            IsLoggedIn = false;
        }
    }
}
