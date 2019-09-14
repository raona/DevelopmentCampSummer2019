using System.Collections.Generic;
using RespiTron.Entities;
using RespiTron.Entities.Contracts;

namespace RespiTron.Data.Contracts
{
    public interface IPatientDataService
    {
        IPatient GetPatient(int patientId);
        List<IPatient> GetPatients();
        bool SavePatient(IPatient patient);
    }
}