using HospitalManager.App.Common;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManager.App.Concrete
{
    public class IllnessActionService : BaseService<IllnessAction> 
    {
        public List<IllnessAction> GetAllByInfo(int id)
        {
            List<IllnessAction> patientIllnessAll = new List<IllnessAction>();

            patientIllnessAll = Items.Where(p =>  p.Patient.Id == id).ToList();
            
            return patientIllnessAll;
        }

        public List<IllnessAction> GetAllByInfo(string pesel)
        {
            List<IllnessAction> patientIllnessAll = new List<IllnessAction>();
            
            patientIllnessAll = Items.Where(p => p.Patient.PESEL == pesel).ToList();

            return patientIllnessAll;
        }
    }
}
