using System.Collections.Generic;
using RespiTron.Data.Contracts;
using RespiTron.Entities.Contracts;

namespace RespiTron.Business.Contracts
{
    public interface IPatientService
    {
        IPatientDataService PatientDataService { get; set; }

        IPatient GetPatient(int patientId);
        List<IPatient> GetPatients();
        bool SavePatient(IPatient patient);
    }
}