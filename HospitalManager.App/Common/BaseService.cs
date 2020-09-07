using HospitalManager.App.Abstract;
using HospitalManager.Domain.Common;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManager.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }
        public BaseService()
        {
            Items = new List<T>();
        }
        public void Add(T item)
        {
            Items.Add(item);
        }

        public List<T> GetAll()
        {
            return Items;
        }

        public void Remove(T item)
        {
            Items.Remove(item);
        }

        public T GetById (int id)
        {
            var entity = Items.FirstOrDefault(p => p.Id == id);

            return entity;
        }

    }
}
