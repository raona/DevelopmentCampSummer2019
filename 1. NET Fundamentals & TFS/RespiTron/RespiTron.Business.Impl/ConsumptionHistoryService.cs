using RespiTron.Business.Contracts;
using RespiTron.Data.Contracts;
using RespiTron.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespiTron.Business.Impl
{
    public class ConsumptionHistoryService : BaseService, IConsumptionHistoryService
    {
        public IConsumptionHistoryDataService ConsumptionHistoryDataService { get; set; }

        public ConsumptionHistoryService(IConsumptionHistoryDataService consumptionHistoryDataService)
        {
            this.ConsumptionHistoryDataService = consumptionHistoryDataService;
        }

        public bool AddConsumptionHistory(IConsumptionHistory consumptionHistory)
        {
            return this.ConsumptionHistoryDataService.AddConsumptionHistory(consumptionHistory);
        }

        public List<IConsumptionHistory> GetConsumptionHistories(int patientId)
        {
            List<IConsumptionHistory> consumptionHistories = this.ConsumptionHistoryDataService.GetConsumptionHistories(patientId);

            return consumptionHistories;
        }
    }
}
