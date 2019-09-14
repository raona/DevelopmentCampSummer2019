using RespiTron.DataProviders.Contracts;

namespace RespiTron.Data.Impl
{
    public interface IBaseDataService
    {
        IDataProvider DataProvider { get; set; }
    }
}