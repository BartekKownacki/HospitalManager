﻿using HospitalManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.Domain.Entity
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PESEL { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAdress { get; set; }

        public Patient()
        {
            CreatedById = 0;
            CreatedDateTime = DateTime.Now;
        }
        public Patient(LoginAction user)
        {
            CreatedById = user.Id;
            CreatedDateTime = DateTime.Now;
        }
    }
}