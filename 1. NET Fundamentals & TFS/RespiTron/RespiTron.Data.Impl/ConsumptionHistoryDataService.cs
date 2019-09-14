using RespiTron.Data.Contracts;
using RespiTron.DataProviders.Contracts;
using RespiTron.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespiTron.Data.Impl
{
    public class ConsumptionHistoryDataService : BaseDataService, IConsumptionHistoryDataService
    {
        private const string className = "ConsumptionHistory";
        private const string patientClassName = "Patient";

        public ConsumptionHistoryDataService(IDataProvider dataProvider)
        {
            this.DataProvider = dataProvider;
        }

        public bool AddConsumptionHistory(IConsumptionHistory consumptionHistory)
        {
            int consumptionHistoryId = this.DataProvider.GetNextId(className);
            consumptionHistory.Id = consumptionHistoryId;

            return this.DataProvider.SaveItem($"{className}_{consumptionHistoryId}_{patientClassName}_{consumptionHistory.Patient.Id}", consumptionHistory);
        }

        public List<IConsumptionHistory> GetConsumptionHistories(int patientId)
        {
            List<IConsumptionHistory> consumptionHistories = this.DataProvider.GetItemsFromRelation<IConsumptionHistory>(className, patientClassName, patientId);

            return consumptionHistories;
        }
    }
}
