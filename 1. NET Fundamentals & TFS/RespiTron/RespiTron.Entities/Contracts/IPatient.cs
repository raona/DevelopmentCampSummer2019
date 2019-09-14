using System;
using System.Collections.Generic;

namespace RespiTron.Entities.Contracts
{
    public interface IPatient : IBaseClass
    {
        int Age { get; }
        int CigarrettesDailyConsumption { get; set; }
        DateTime? DateOfBirth { get; set; }
        DateTime? DateOfDecease { get; set; }
        bool Deceased { get; }
        GendersEnum Gender { get; set; }
        string Name { get; set; }
        bool Smoker { get; set; }
        string Surname { get; set; }

        bool Validate(out List<string> errors);
    }
}