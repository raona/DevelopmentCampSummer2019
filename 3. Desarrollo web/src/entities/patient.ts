export default interface Patient {
    Id: number;
    Name: string;
    Surname: string | null;
    Gender: string | null;
    GenderId: number;
    DateOfBirth: string;
    DateOfDecease: string | null;
    Smoker: boolean;
    CigarrettesDailyConsumption: number;
    City: string | null;
    CityId: number;
}