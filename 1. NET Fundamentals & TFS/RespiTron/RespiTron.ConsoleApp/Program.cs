using RespiTron.Business.Contracts;
using RespiTron.Business.Impl;
using RespiTron.Data.Impl;
using RespiTron.DataProviders;
using RespiTron.DataProviders.Contracts;
using RespiTron.Entities;
using RespiTron.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RespiTron.ConsoleApp
{
    class Program
    {
        #region Private properties

        private static IPatientService patientService;
        private static IPatientService PatientService
        {
            get
            {
                if (patientService == null)
                {
                    patientService = new PatientService(new PatientDataService(DataProvider));
                }

                return patientService;
            }
        }

        private static IConsumptionHistoryService consumptionHistoryService;
        private static IConsumptionHistoryService ConsumptionHistoryService
        {
            get
            {
                if (consumptionHistoryService == null)
                {
                    consumptionHistoryService = new ConsumptionHistoryService(new ConsumptionHistoryDataService(DataProvider));
                }

                return consumptionHistoryService;
            }
        }

        private static IDataProvider dataProvider;
        private static IDataProvider DataProvider
        {
            get
            {
                if (dataProvider == null)
                {
                    dataProvider = new MemoryDataProvider();
                }

                return dataProvider;
            }
        }

        #endregion

        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            Menu();
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to RespiTron Console Application");
        }

        private static void Menu()
        {
            PrintMenu();
            int option = ReadIntKey();
            switch (option)
            {
                case 0:
                    System.Environment.Exit(1);
                    break;
                case 1:
                    NewPatient();
                    Menu();
                    break;
                case 2:
                    AddConsumption();
                    Menu();
                    break;
                case 3:
                    ListPatients();
                    Menu();
                    break;
                case 4:
                    GetConsumptionHistoryForPatient();
                    Menu();
                    break;
                case 5:
                    GetPatient();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please, choose a valid option");
                    Menu();
                    break;
            }
        }

        private static void GetConsumptionHistoryForPatient()
        {
            Console.WriteLine("Enter the Patient Id: ");
            int patientId = ReadIntKey();

            List<IConsumptionHistory> consumptionHistories = ConsumptionHistoryService.GetConsumptionHistories(patientId);

            foreach (IConsumptionHistory consumptionHistory in consumptionHistories)
            {
                Console.WriteLine("-------------");

                Console.WriteLine($"Id: {consumptionHistory.Id}");
                Console.WriteLine($"Consumption Date: {consumptionHistory.ConsumptionDate?.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"O2 Consumption (liters): {consumptionHistory.O2LitersConsumption}");

                Console.WriteLine("-------------");
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Please, choose an option:");
            Console.WriteLine("(1) New Patient");
            Console.WriteLine("(2) Add Consumption");
            Console.WriteLine("(3) Get All Patients");
            Console.WriteLine("(4) Get Consumptions for Patient");
            Console.WriteLine("(5) Get Patient");
            Console.WriteLine("(0) Exit");
            Console.WriteLine();
        }

        private static int ReadIntKey()
        {
            int optionNumber = 0;
            if (!int.TryParse(Console.ReadLine().ToString(), out optionNumber))
                return -1;
            return optionNumber;
        }

        private static void NewPatient()
        {
            IPatient patient = new Patient();
            
            Console.WriteLine("Name:");
            patient.Name = Console.ReadLine();

            Console.WriteLine("Surname:");
            patient.Surname = Console.ReadLine();

            Console.WriteLine("Gender ((1) Female / (2) Male):");
            int gender = 0;
            while (!(gender == 1 || gender == 2))
            {
                gender = ReadIntKey();
            }
            patient.Gender = (GendersEnum)gender;

            Console.WriteLine("Date of birth (ddMMYYYY format):");
            DateTime dateofBirth = new DateTime();
            while (dateofBirth == DateTime.MinValue)
            {
                string dateToParse = Console.ReadLine().Trim();
                DateTime.TryParseExact(dateToParse, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateofBirth);
            }
            patient.DateOfBirth = dateofBirth;

            Console.WriteLine("Smoker (Y/N):");
            string smoker = "";
            while (!(smoker == "Y" || smoker == "N"))
            {
                smoker = Console.ReadLine().ToUpper();
            }
            patient.Smoker = (smoker == "Y");

            if (patient.Smoker)
            {
                Console.WriteLine("Number of daily cigarrettes:");
                int cigarretes = -1;
                while (cigarretes == -1)
                {
                    cigarretes = ReadIntKey();
                }
                patient.CigarrettesDailyConsumption = cigarretes;
            }

            Console.WriteLine("Deceased (Y/N):");
            string deceased = "";
            while (!(deceased == "Y" || deceased == "N"))
            {
                deceased = Console.ReadLine().ToUpper();
            }

            if (deceased == "Y")
            {
                Console.WriteLine("Date of decease (ddMMYYYY format):");
                DateTime dateOfDecease = new DateTime();
                while (dateOfDecease == DateTime.MinValue)
                {
                    DateTime.TryParseExact(Console.ReadLine(), "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfDecease);
                }
                patient.DateOfDecease = dateOfDecease;
            }

            List<string> errors = new List<string>();

            if (!patient.Validate(out errors))
            {
                Console.WriteLine("One or more errors in New Patient:");

                foreach (string error in errors)
                {
                    Console.WriteLine(error);
                }

                Console.WriteLine("Patient has not been saved, please correct errors and try again. \n");
                NewPatient();
            }
            else
            {
                PatientService.SavePatient(patient);
            }

        }

        private static void AddConsumption()
        {
            IConsumptionHistory consumptionHistory = new ConsumptionHistory();

            Console.WriteLine("Patient Id:");
            int patientId = -1;
            while (patientId == -1)
            {
                patientId = ReadIntKey();
            }
            consumptionHistory.Patient = PatientService.GetPatient(patientId);

            Console.WriteLine("Consumption Date (ddMMYYYY format):");
            DateTime consumptionDate = new DateTime();
            while (consumptionDate == DateTime.MinValue)
            {
                string dateToParse = Console.ReadLine().Trim();
                DateTime.TryParseExact(dateToParse, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out consumptionDate);
            }
            consumptionHistory.ConsumptionDate = consumptionDate;

            Console.WriteLine("O2 consumption (in liters):");
            int o2LitersConsumption = -1;
            while (o2LitersConsumption == -1)
            {
                o2LitersConsumption = ReadIntKey();
            }
            consumptionHistory.O2LitersConsumption = o2LitersConsumption;

            List<string> errors = new List<string>();
            if (!consumptionHistory.Validate(out errors))
            {
                Console.WriteLine("One or more errors in Add Consumption History:");

                foreach (string error in errors)
                {
                    Console.WriteLine(error);
                }

                Console.WriteLine("Consumption History has not been saved, please correct errors and try again. \n");
                AddConsumption();
            }
            else
            {
                ConsumptionHistoryService.AddConsumptionHistory(consumptionHistory);
            }
        }

        private static void ListPatients()
        {
            List<IPatient> listOfPatients = PatientService.GetPatients();
        
            foreach (IPatient patient in listOfPatients)
            {
                PrintPatient(patient);
            }
        }

        private static void GetPatient()
        {
            Console.WriteLine("Enter the Patient Id: ");
            int patientId = ReadIntKey();

            IPatient patient = PatientService.GetPatient(patientId);

            if (patient != null)
            {
                PrintPatient(patient);
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        private static void PrintPatient(IPatient patient)
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"Id: {patient.Id}");
            Console.WriteLine($"Name: {patient.Name}");
            Console.WriteLine($"Surname: {patient.Surname}");
            Console.WriteLine($"Gender: {patient.Gender}");
            Console.WriteLine($"DateOfBirth: {patient.DateOfBirth?.ToString("dd/MM/yyyy")}");

            if (patient.Deceased)
            {
                Console.WriteLine($"Date of decease: {patient.DateOfDecease?.ToString("dd / MM / yyyy")}");
            }

            Console.WriteLine($"Age: {patient.Age}");

            if (patient.Smoker)
            {
                Console.WriteLine($"Smoker patient. Number of daily cigarrettes: {patient.CigarrettesDailyConsumption}");
            }
            else
            {
                Console.WriteLine($"Non smoker patient");
            }

            Console.WriteLine("-------------");
        }
    }
}
