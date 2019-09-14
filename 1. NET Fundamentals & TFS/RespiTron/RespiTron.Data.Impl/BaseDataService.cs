using RespiTron.DataProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespiTron.Data.Impl
{
    public class BaseDataService : IBaseDataService
    {
        public IDataProvider DataProvider { get; set; }
    }
}
