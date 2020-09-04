using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.App.Abstract
{
    public interface IPatientService
    {
        List<Patient> Items { get; set; }

        List<Patient> GetAll();

        void Add(Patient item);
        void Remove(Patient item);

        Patient GetById(int id);
        Patient GetByPesel(string pesel);
    }
}
