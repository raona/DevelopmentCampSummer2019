using System.Collections.Generic;
using RespiTron.Entities.Contracts;

namespace RespiTron.Data.Contracts
{
    public interface IConsumptionHistoryDataService
    {
        bool AddConsumptionHistory(IConsumptionHistory consumptionHistory);
        List<IConsumptionHistory> GetConsumptionHistories(int patientId);
    }
}