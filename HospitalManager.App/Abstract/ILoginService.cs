using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.App.Abstract
{
    public interface ILoginService<T>
    {
        List<T> Users { get; set; }

        List<T> GetAll();

        void Add(T user);
        void Remove(T user);
        LoginAction GetUser(LoginAction user);
    }
}
