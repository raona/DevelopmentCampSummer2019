using System;
using System.Collections.Generic;
using System.Text;

namespace RespiTron.DataProviders.Contracts
{
    public interface IDataProvider
    {
        bool DeleteItem(string key);
        T GetItem<T>(string key) where T : class;
        List<T> GetItems<T>(string className) where T : class;
        List<T> GetItemsFromRelation<T>(string className, string relationClass, int relationItemId) where T : class;
        int GetNextId(string className);
        bool NewItem<T>(string key, T item) where T : class;
        bool SaveItem<T>(string key, T item) where T : class;
        bool UpdateItem<T>(string key, T item) where T : class;
    }
}
