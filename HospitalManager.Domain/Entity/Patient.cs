using HospitalManager.Domain.Common;
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
        public Patient(User user)
        {
            CreatedById = user.Id;
            CreatedDateTime = DateTime.Now;
        }
        public Patient(int id, string firstName, string lastName, string pesel, int phoneNumber, string emailAdress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PESEL = pesel;
            PhoneNumber = phoneNumber;
            EmailAdress = emailAdress;
        }
    }
}
