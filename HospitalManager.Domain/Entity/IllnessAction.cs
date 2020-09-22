using HospitalManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HospitalManager.Domain.Entity
{
    public class IllnessAction : BaseEntity
    {
        [XmlElement("Patient")]
        public Patient Patient { get; set; }
        [XmlElement("Illness name")]
        public string NameOfIllness { get; set; }
        [XmlElement("Date of visit")]
        public DateTime DateOfVisit { get; set; }
        [XmlElement("Symptoms")]
        public string Symptoms { get; set; }
        [XmlElement("Illness category")]
        public CategoryOfIllness Category;
        [XmlElement("Illness level")]
        public int IllnessLevel { get; set; }
        [XmlElement("Prescripted medicines")]
        public List<string> PrescriptedMedicines { get; set; }
        [XmlElement("Date of control visit")]
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
        public IllnessAction(int id, Patient patientToAdd, string nameofillness, DateTime dateofvisit, string symptops, CategoryOfIllness category, int illnessLevel, List<string> prescriptedMedicines, DateTime dateofnextvisit)
        {
            Id = id;
            Patient = patientToAdd;
            NameOfIllness = nameofillness;
            DateOfVisit = dateofvisit;
            Symptoms = symptops;
            Category = category;
            IllnessLevel = illnessLevel;
            PrescriptedMedicines = prescriptedMedicines;
            DateOfControlVisit = dateofnextvisit;
        }
        public IllnessAction()
        {
            PrescriptedMedicines = new List<string>();
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
