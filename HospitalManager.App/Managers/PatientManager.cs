using HospitalManager.App.Abstract;
using HospitalManager.App.Concrete;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManager.App.Managers
{
    public class PatientManager
    {
        private IService<Patient> _patientService;
        public PatientManager(IService<Patient> patientService)
        {
            _patientService = patientService;
        }
        public void GetNewPatientData(User user)
        {
            Patient patient = new Patient(user);
            patient.Id = _patientService.Items.Count + 1;

            Console.Write("Please write patient's name: ");
            patient.FirstName = Console.ReadLine();
            Console.Write("Please write patient's lastname: ");
            patient.LastName = Console.ReadLine();
            Console.Write("Please write patient's PESEL number: ");
            patient.PESEL = Console.ReadLine();
            Console.Write("Please write patient's phone number: ");
            patient.PhoneNumber = Int32.Parse(Console.ReadLine());
            Console.Write("Please write patient's e-mail adress: ");
            patient.EmailAdress = Console.ReadLine();
            _patientService.Add(patient);
        }

        public Patient GetById(int id)
        {
            var entity = _patientService.GetById(id);
            return entity;
        }
        public Patient GetByPesel(string pesel)
        {
            var entity = _patientService.Items.FirstOrDefault(p => p.PESEL == pesel);
            return entity;
        }
        public void Remove(string pesel)
        {
            var entity = _patientService.Items.FirstOrDefault(p => p.PESEL == pesel);
            _patientService.Remove(entity);
        }

        public void Remove(int id)
        {
            var entity = _patientService.Items.FirstOrDefault(p => p.Id == id);
            _patientService.Remove(entity);
        }
    }
}
