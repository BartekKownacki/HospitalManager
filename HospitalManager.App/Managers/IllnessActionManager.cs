using HospitalManager.App.Abstract;
using HospitalManager.App.Concrete;
using HospitalManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using HospitalManager.Helpers;

namespace HospitalManager.App.Managers
{
    public class IllnessActionManager
    {
        private IService<IllnessAction> _illnessActionService;
        public IllnessActionManager(IService<IllnessAction> illnessActionService)
        {
            _illnessActionService = illnessActionService;
        }

        public void GetPatientAndIllnessData(User user, PatientService patients)
        {
            string pesel;
            Patient patient = new Patient();
            bool isPatientInList = false;
            while (!isPatientInList)
            {
                Console.Write("Please write patients PESEL number: ");
                pesel = Console.ReadLine();
                foreach (var patientFromList in patients.GetAll())
                {
                    if (patientFromList.PESEL == pesel)
                    {
                        Console.WriteLine("Patient was found in the list!");
                        Console.WriteLine($"{patientFromList.Id} | " +
                                $"{patientFromList.FirstName} {patientFromList.LastName}  | " +
                                $"PESEL: {patientFromList.PESEL} | " +
                                $"Tel: {patientFromList.PhoneNumber} | " +
                                $"E-mail: {patientFromList.EmailAdress}");
                        patient = patientFromList;
                        isPatientInList = true;
                    }
                    else
                    {
                        Console.Write($"There's no person with PESEL: {pesel} in the list. \nPlease try again.\n");
                    }
                }
            }
            IllnessAction illnessAction = new IllnessAction();
            Console.Write("Please write number of an illness category: \n1. Infectious \n2. Cancer \n3. Chronic \n4. Civilization \n5. Psychic \n6. Genetic");
            Enum.TryParse(Console.ReadLine(), out illnessAction.Category);
            Console.Write("Please write name of the illness: ");
            illnessAction.NameOfIllness = Console.ReadLine();
            Console.Write("Please write symptoms of the illness: ");
            illnessAction.Symptoms = Console.ReadLine();
            Console.Write("Please write a stage of the illness: ");
            illnessAction.IllnessLevel = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please write prescripted medicines: ");
            bool stop = false;
            int number = 1;
            while (!stop)
            {
                Console.Write(number + ". ");
                illnessAction.PrescriptedMedicines.Add(Console.ReadLine());
                bool isAnOption = false;
                while (!isAnOption)
                {
                    Console.WriteLine("Is that's all? \n1. Yes \n2. No");
                    var option = Console.ReadKey();
                    switch (option.KeyChar)
                    {
                        case '1':
                            ConsoleActions.ClearChosenNumberFromLine();
                            stop = true;
                            isAnOption = true;
                            break;
                        case '2':
                            ConsoleActions.ClearChosenNumberFromLine();
                            isAnOption = true;
                            break;
                        default:
                            ConsoleActions.ClearChosenNumberFromLine();
                            Console.WriteLine($"Theres no option \"{option.KeyChar}\". Please try again.");
                            break;
                    }
                }
                number++;

            }
            illnessAction.DateOfVisit = DateTime.Now;

            Console.Write("In how many days should the control visit be: ");
            int days = Int32.Parse(Console.ReadLine());
            illnessAction.DateOfControlVisit = illnessAction.DateOfVisit.AddDays(days);
            illnessAction = new IllnessAction(user, patient, illnessAction);
            _illnessActionService.Add(illnessAction);
            Console.WriteLine("Illness added successfully!");

        }

    }
}
