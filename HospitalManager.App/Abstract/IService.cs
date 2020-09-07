using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.App.Abstract
{
    public interface IService<T>
    {
        List<T> Items { get; set; }

        List<T> GetAll();

        void Add(T item);
        void Remove(T item);
        T GetById(int id);
    }
}
