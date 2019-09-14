using RespiTron.Business.Contracts;
using RespiTron.Data.Contracts;
using RespiTron.Data.Impl;
using RespiTron.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespiTron.Business.Impl
{
    public class PatientService : BaseService, IPatientService
    {
        public IPatientDataService PatientDataService { get; set; }

        public PatientService(IPatientDataService patientDataService)
        {
            this.PatientDataService = patientDataService;
        }

        public bool SavePatient(IPatient patient)
        {
            return this.PatientDataService.SavePatient(patient);
        }

        public IPatient GetPatient(int patientId)
        {
            IPatient patient = this.PatientDataService.GetPatient(patientId);

            return patient;
        }

        public List<IPatient> GetPatients()
        {
            List<IPatient> patients = this.PatientDataService.GetPatients();

            return patients;
        }
    }
}
