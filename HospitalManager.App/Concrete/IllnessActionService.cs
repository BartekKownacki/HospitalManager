using HospitalManager.App.Common;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;

namespace HospitalManager.App.Concrete
{
    public class IllnessActionService : BaseService<IllnessAction> 
    {
        public List<IllnessAction> GetAll(int id)
        {
            List<IllnessAction> patientIllnessAll = new List<IllnessAction>();
            foreach (var patientillness in Items)
            {
                if (patientillness.patient.Id == id)
                {
                    patientIllnessAll.Add(patientillness);
                }
            }
            return patientIllnessAll;
        }

        public List<IllnessAction> GetAll(string pesel)
        {
            List<IllnessAction> patientIllnessAll = new List<IllnessAction>();
            foreach (var patientillness in Items)
            {
                if (patientillness.patient.PESEL == pesel)
                {
                    patientIllnessAll.Add(patientillness);
                }
            }
            return patientIllnessAll;
        }
    }
}
