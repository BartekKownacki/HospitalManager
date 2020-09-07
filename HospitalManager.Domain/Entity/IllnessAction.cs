using HospitalManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManager.Domain.Entity
{
    public class IllnessAction : BaseEntity
    {
        public Patient Patient { get; set; }
        public string NameOfIllness { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string Symptoms { get; set; }
        public CategoryOfIllness Category;
        public int IllnessLevel { get; set; }
        public List<string> PrescriptedMedicines { get; set; }
        public DateTime DateOfControlVisit { get; set; }

        public IllnessAction(User user, Patient patientToAdd, IllnessAction illnessActionWithoutUser)
        {
            Patient = patientToAdd;

            NameOfIllness = illnessActionWithoutUser.NameOfIllness;
            DateOfVisit = illnessActionWithoutUser.DateOfVisit;
            Symptoms = illnessActionWithoutUser.Symptoms;
            Category = illnessActionWithoutUser.Category;
            IllnessLevel = illnessActionWithoutUser.IllnessLevel;
            PrescriptedMedicines = illnessActionWithoutUser.PrescriptedMedicines;
            DateOfControlVisit = illnessActionWithoutUser.DateOfControlVisit;

            CreatedById = user.Id;
            CreatedDateTime = DateTime.Now;
        }
        public IllnessAction(Patient patientToAdd, string nameofillness, DateTime dateofvisit, string symptops, CategoryOfIllness category, int illnessLevel, string medicine, DateTime dateofnextvisit)
        {
            Patient = patientToAdd;

        }
        public IllnessAction()
        {

        }
    }
   
    public enum CategoryOfIllness
    {

        Infectious = 1, 
        Cancer, 
        Chronic, 
        Civilization, 
        Psychic, 
        Genetic
    }
}
