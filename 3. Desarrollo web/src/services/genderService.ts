import Gender from '../entities/gender';

export default class PatientService {
    public static async getGenders(): Promise<Gender[]> {
        // return Axios.get<any>(`${appConstants.apiBaseUrl}${patientServiceConstants.getAllPatientsEndpoint}`);
        let patientsImport = await import('../constants/genders');

        return patientsImport.default;
    }
}