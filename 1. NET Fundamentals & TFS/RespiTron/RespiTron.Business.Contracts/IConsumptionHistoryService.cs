using System.Collections.Generic;
using RespiTron.Data.Contracts;
using RespiTron.Entities.Contracts;

namespace RespiTron.Business.Contracts
{
    public interface IConsumptionHistoryService
    {
        IConsumptionHistoryDataService ConsumptionHistoryDataService { get; set; }

        bool AddConsumptionHistory(IConsumptionHistory consumptionHistory);
        List<IConsumptionHistory> GetConsumptionHistories(int patientId);
    }
}