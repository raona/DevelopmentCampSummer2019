import City from '../entities/city';

export default class PatientService {
    public static async getCities(): Promise<City[]> {
        // return Axios.get<any>(`${appConstants.apiBaseUrl}${patientServiceConstants.getAllPatientsEndpoint}`);
        let patientsImport = await import('../constants/cities');

        return patientsImport.default;
    }
}