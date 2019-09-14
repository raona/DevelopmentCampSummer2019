using RespiTron.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespiTron.Entities
{
    public class ConsumptionHistory : BaseClass, IConsumptionHistory
    {
        #region Public properties

        public IPatient Patient { get; set; }
        public DateTime? ConsumptionDate { get; set; }
        public int O2LitersConsumption { get; set; }

        #endregion

        #region Public constructor

        public ConsumptionHistory()
        { }

        public ConsumptionHistory(int Id)
        {
            this.Id = Id;
        }

        public ConsumptionHistory(int Id, IPatient patient, DateTime? consumptionDate, int o2LitersConsumption)
        {
            this.Id = Id;
            this.Patient = patient;
            this.ConsumptionDate = consumptionDate;
            this.O2LitersConsumption = o2LitersConsumption;
        }

        #endregion

        #region Public methods

        public bool Validate(out List<string> errors)
        {
            errors = new List<string>();

            if (this.Patient == null)
                errors.Add("Consumption History Patient is null");
            
            if (this.ConsumptionDate == null)
                errors.Add("Consumption History Consumption Date is null or empty");

            if (this.ConsumptionDate > DateTime.Now)
                errors.Add("Consumption History Consumption Date is most recent than now");

            return errors.Count == 0;
        }
        
        #endregion
    }
}
