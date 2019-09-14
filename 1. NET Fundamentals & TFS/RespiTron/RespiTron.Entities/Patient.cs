using RespiTron.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespiTron.Entities
{
    public class Patient : BaseClass, IPatient
    {
        #region Public properties

        public string Name { get; set; }
        public string Surname { get; set; }
        public GendersEnum Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool Deceased
        {
            get
            {
                return DateOfDecease != null;
            }
        }
        public DateTime? DateOfDecease { get; set; }
        public int Age {
            get
            {
                int age = 0;
                DateTime endDate = DateTime.Today;
                if (this.Deceased)
                {
                    endDate = this.DateOfDecease.Value;
                }
                age = endDate.Year - this.DateOfBirth.Value.Year;
                if (this.DateOfBirth > endDate.AddYears(-age)) age--;
                return age;
            }
        }
        public bool Smoker { get; set; }
        public int CigarrettesDailyConsumption { get; set; }

        #endregion

        #region Public constructors

        public Patient() { }

        public Patient(int id)
        {
            this.Id = id;
        }

        public Patient(int id, string name, string surname, GendersEnum gender, DateTime dateOfBirth, DateTime dateOfDecease, bool smoker, int cigarrettesDailyConsumption)
        {
            this.Id = Id;
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.DateOfDecease = dateOfDecease;
            this.Smoker = smoker;
            this.CigarrettesDailyConsumption = cigarrettesDailyConsumption;
        }

        #endregion

        #region Public methods

        public bool Validate(out List<string> errors)
        {
            errors = new List<string>();
            
            if (string.IsNullOrEmpty(this.Name))
                errors.Add("Patient Name is null or empty");

            if (string.IsNullOrEmpty(this.Surname))
                errors.Add("Patient Surname is null or empty");

            if (this.DateOfBirth == null)
                errors.Add("Patient Birth Date is null or empty");

            if (this.DateOfBirth > DateTime.Now)
                errors.Add("Patient Birth Date is most recent than now");

            if (this.DateOfDecease > DateTime.Now)
                errors.Add("Patient Decease Date is most recent than now");

            return errors.Count == 0;
        }

        #endregion
    }
}
