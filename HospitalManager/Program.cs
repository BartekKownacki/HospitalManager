using HospitalManager.App.Concrete;
using HospitalManager.App.Managers;
using HospitalManager.Domain.Entity;
using HospitalManager.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace HospitalManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO
            //Logowanie Lekarza
            ////1. Logowanie
            ////2. Rejestracja
            //Menu:
            ////1. Sprawdz listę pacjentów w bazie
            ////2. Dodaj nowego pacjenta do listy pacjentów
            ////3. Usuń pacjenta
            ////4. Przypisz chorobę do pacjenta
            ////5. Sprawdz wczesniejsze choroby danego pacjenta (PESEL)
            ////6. Wygeneruj receptę (.csv) dla pacjenta (wykorzystując gotowy szablon)
            ////7. Wylogowanie
            //////2a. Id(numer pacjenta), Imie, Nazwisko, PESEL, Numer telefonu, Adres Email
            //////3a. Usuwanie poprzez podanie id lub numeru PESEL
            //////4a. Wybór kategorii: Zakaźna, Nowotwór, Przewlekła, Cywilizacyjna, Psychiczne, Genetyczne itd...
            //////4b. Wybór stopnia zaawansowania choroby (1-5) - różny kolor czcionki przy wypisywaniu w konsoli
            //////4c. Opis objawów
            //////4d. Zalecenia
            //////5a. 
            //////6a. Recepta: id lekarza, Zalecenia, Dawkowanie leków 

            string path = Directory.GetCurrentDirectory();

            MenuActionService menuActionService = new MenuActionService();
            var loginMenu = menuActionService.GetMenuActionsByMenuName("Login");

            UserService userService = new UserService();
            UserManager userManager = new UserManager(userService);
            User user = new User();
            bool isAnOption = true;

            do
            {
                Console.WriteLine("Please choose what you want to do: ");
                foreach (var element in loginMenu)
                {
                    Console.WriteLine($"{ element.Id }. {element.Name}");
                }
                do
                {
                    var option = Console.ReadKey();
                    switch (option.KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            Console.WriteLine($"===Log in===");
                            user = userManager.GetLoginData(user);
                            ConsoleActions.ShowWaitingDots();
                            break;
                        case '2':
                            Console.Clear();
                            Console.WriteLine($"===Register===");
                            user = userManager.GetRegisterData(user);
                            Console.WriteLine($"You have successfully registered! Your ID number is: {user.Id}");
                            ConsoleActions.ShowWaitingDots();
                            break;
                        default:
                            ConsoleActions.ClearChosenNumberFromLine();
                            Console.WriteLine($"Operation number {option.KeyChar} does not exist please try again");
                            isAnOption = false;
                            break;
                    }
                }
                while (!isAnOption);
            }
            while (!user.IsLoggedIn);

            //User can choose what he want to do

            loginMenu = menuActionService.GetMenuActionsByMenuName("mainMenu");
            IllnessActionService illnessActionService = new IllnessActionService();
            IllnessActionManager illnessActionManager = new IllnessActionManager(illnessActionService);
            PatientService patientService = new PatientService();
            PatientManager patientManager = new PatientManager(patientService);
            bool quit = true;

            do
            {
                Console.WriteLine("Please choose what you want to do: ");
                foreach (var element in loginMenu)
                {
                    Console.WriteLine($"{ element.Id }. {element.Name}");
                }

                var option = Console.ReadKey();
                switch (option.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        List<Patient> patients = new List<Patient>();
                        patients=patientService.GetAll();
                        foreach(var patient in patients)
                        {
                            Console.WriteLine($"{patient.Id} | " +
                                $"{patient.FirstName} {patient.LastName}  | " +
                                $"PESEL: {patient.PESEL} | " +
                                $"Tel: {patient.PhoneNumber} | " +
                                $"E-mail: {patient.EmailAdress}");

                        }
                        quit = false;
                        break;
                    case '2':
                        Console.Clear();
                        patientManager.GetNewPatientData(user);
                        quit = false;
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Do you want to remove by PESEL number or ID number: \n1. PESEL\n2. ID" );
                        option = Console.ReadKey();
                        switch (option.KeyChar)
                        {
                            case '1':
                                string pesel;
                                Console.Write("Please write patient's PESEL number: ");
                                pesel = Console.ReadLine();
                                patientManager.Remove(pesel);
                                break;
                            case '2':
                                int id;
                                Console.Write("Please write patient's ID number: ");
                                Int32.TryParse(Console.ReadLine(), out id);
                                patientManager.Remove(id);
                                break;
                            default:
                                Console.WriteLine($"Operation number { option.KeyChar} does not exist.");
                                break;
                        }
                        quit = false;
                        break;
                    case '4':
                        Console.Clear();
                        illnessActionManager.GetPatientAndIllnessData(user, patientService);
                        ConsoleActions.ShowWaitingDots();
                        quit = false;
                        break;

                    case '5':
                        Console.Clear();
                        Console.WriteLine("Do you want to search by PESEL number or ID number: \n1. PESEL\n2. ID\n");
                        option = Console.ReadKey();
                        XmlRootAttribute root = new XmlRootAttribute();
                        root = new XmlRootAttribute();
                        root.ElementName = "Illnesses";
                        root.IsNullable = true;
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<IllnessAction>), root);
                        switch (option.KeyChar)
                        {
                            case '1':
                                ConsoleActions.ClearChosenNumberFromLine();
                                string pesel;
                                Console.Write("Please write patient's PESEL number: ");
                                pesel = Console.ReadLine();
                                var illnesses = illnessActionManager.GetInfoToSerializeCSV(pesel);
                               
                                xmlSerializer.Serialize(new StreamWriter(path + $@"\illnesses_xml\{patientManager.GetByPesel(pesel).PESEL}.xml"), illnesses);
                                break;
                            case '2':
                                ConsoleActions.ClearChosenNumberFromLine();
                                int id;
                                Console.Write("Please write patient's ID number: ");
                                Int32.TryParse(Console.ReadLine(), out id);
                                illnesses = illnessActionManager.GetInfoToSerializeCSV(id);
                                
                                xmlSerializer.Serialize(new StreamWriter(path + $@"\illnesses_xml\{patientManager.GetById(id).PESEL}.xml"), illnesses);
                                break;
                            default:
                                ConsoleActions.ClearChosenNumberFromLine();
                                Console.WriteLine($"Operation number { option.KeyChar} does not exist.");
                                
                                break;
                        }
                        quit = false;
                        break;
                    case '6':
                        ConsoleActions.ClearChosenNumberFromLine();
                        Console.Write("Please write PESEL number of patient to read his/her prescription: ");
                        string peselFileName;
                        peselFileName = Console.ReadLine();

                        
                        root = new XmlRootAttribute();
                        root.ElementName = "Illnesses";
                        root.IsNullable = true;
                        xmlSerializer = new XmlSerializer(typeof(List<IllnessAction>), root);
                        string xml = File.ReadAllText(path + $@"\illnesses_xml\{peselFileName}.xml");

                        StringReader stringReader = new StringReader(xml);
                        var illnessItems = (List<IllnessAction>)xmlSerializer.Deserialize(stringReader);
                        

                        foreach(var item in illnessItems)
                        {
                            Console.Write(item.Id + " | "+
                               item.NameOfIllness + " | " +
                               item.IllnessLevel + " | " +
                               item.DateOfControlVisit + " | " +
                               item.Category);
                            Console.WriteLine("=============================================");
                        }

                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Operation number {option.KeyChar} does not exist please try again");
                        quit = false;
                        break;
                }

            }
            while (!quit);
                        
        }  

    }

}
