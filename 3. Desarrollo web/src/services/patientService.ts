import Patient from '../entities/patient';

export default class PatientService {
    public static async getPatients(): Promise<Patient[]> {
        // return Axios.get<any>(`${appConstants.apiBaseUrl}${patientServiceConstants.getAllPatientsEndpoint}`);
        let patientsImport = await import('../constants/patients');

        return patientsImport.default;
    }
}