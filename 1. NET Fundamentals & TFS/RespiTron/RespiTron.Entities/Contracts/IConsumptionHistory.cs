using System;
using System.Collections.Generic;

namespace RespiTron.Entities.Contracts
{
    public interface IConsumptionHistory : IBaseClass
    {
        DateTime? ConsumptionDate { get; set; }
        int O2LitersConsumption { get; set; }
        IPatient Patient { get; set; }

        bool Validate(out List<string> errors);
    }
}