using RespiTron.Data.Contracts;
using RespiTron.DataProviders.Contracts;
using RespiTron.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespiTron.Data.Impl
{
    public class PatientDataService : BaseDataService, IPatientDataService
    {
        private const string className = "Patient";

        public PatientDataService(IDataProvider dataProvider)
        {
            this.DataProvider = dataProvider;
        }

        public bool SavePatient(IPatient patient)
        {
            patient.Id = this.DataProvider.GetNextId(className);
            return this.DataProvider.SaveItem($"{className}_{patient.Id}", patient);
        }

        public IPatient GetPatient(int patientId)
        {
            IPatient patient = this.DataProvider.GetItem<IPatient>($"{className}_{patientId}");

            return patient;
        }

        public List<IPatient> GetPatients()
        {
            List<IPatient> patients = this.DataProvider.GetItems<IPatient>(className);

            return patients;
        }
    }
}
