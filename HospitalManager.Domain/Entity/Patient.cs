using HospitalManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HospitalManager.Domain.Entity
{
    public class Patient : BaseEntity
    {
        [XmlElement("Patient's firstname")]
        public string FirstName { get; set; }
        [XmlElement("Patient's lastname")]
        public string LastName { get; set; }
        [XmlElement("Patient's PESEL")]
        public string PESEL { get; set; }
        [XmlElement("Patient's phone number")]
        public int PhoneNumber { get; set; }
        [XmlElement("Patient's e-mail adress")]
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
        public Patient(int id, string firstname, string lastname, string pesel, int phonenumber, string email)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            PESEL = pesel;
            PhoneNumber = phonenumber;
            EmailAdress = email;
        }
    }
}
