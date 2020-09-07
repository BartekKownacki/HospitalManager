using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.App.Abstract
{
    public interface IUserService
    {
        List<User> Users { get; set; }

        List<User> GetAll();

        void Add(User user);
        void Remove(User user);
        User GetUser(User user);
    }
}
