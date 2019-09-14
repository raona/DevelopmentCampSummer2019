using RespiTron.DataProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RespiTron.DataProviders
{
    public class MemoryDataProvider : IDataProvider
    {
        private Dictionary<string, object> memoryDictionary = new Dictionary<string, object>();

        public bool SaveItem<T>(string key, T item) where T : class
        {
            try
            {
                if (memoryDictionary.ContainsKey(key))
                {
                    return this.UpdateItem(key, item);
                }
                else
                {
                    return this.NewItem(key, item);
                }
            }
            catch
            {
                //No es una buena práctica un catch sin registrar el error o sin retornarlo a la llamada, está así solo por simplificar
                return false;
            }
        }

        public bool NewItem<T>(string key, T item) where T : class
        {
            try
            {
                memoryDictionary.Add(key, item);
                return true;
            }
            catch
            { 
                //No es una buena práctica un catch sin registrar el error o sin retornarlo a la llamada, está así solo por simplificar
                return false;
            }
        }

        public bool DeleteItem(string key)
        {
            try
            { 
                memoryDictionary.Remove(key);
                return true;
            }
            catch
            { 
                //No es una buena práctica un catch sin registrar el error o sin retornarlo a la llamada, está así solo por simplificar
                return false;
            }
        }

        public bool UpdateItem<T>(string key, T item) where T : class
        {
            try
            {
                memoryDictionary[key] = item as T;
                return true;
            }
            catch
            {
                //No es una buena práctica un catch sin registrar el error o sin retornarlo a la llamada, está así solo por simplificar
                return false;
            }
        }

        public T GetItem<T>(string key) where T : class
        {
            try
            {
                return memoryDictionary[key] as T;
            }
            catch
            {
                //No es una buena práctica un catch sin registrar el error o sin retornarlo a la llamada, está así solo por simplificar
                return null;
            }
        }

        public List<T> GetItems<T>(string className) where T : class
        {
            try
            {
                return memoryDictionary.Where(x => x.Key.StartsWith(className)).Select(x => x.Value as T).ToList();
            }
            catch
            {
                //No es una buena práctica un catch sin registrar el error o sin retornarlo a la llamada, está así solo por simplificar
                return null;
            }
        }

        public List<T> GetItemsFromRelation<T>(string className, string relationClass, int relationItemId) where T : class
        {
            try
            {
                return memoryDictionary.Where(x => x.Key.StartsWith(className) && x.Key.EndsWith($"{relationClass}_{relationItemId}")).Select(x => x.Value as T).ToList();
            }
            catch
            {
                //No es una buena práctica un catch sin registrar el error o sin retornarlo a la llamada, está así solo por simplificar
                return null;
            }
        }

        public int GetNextId(string className)
        {
            try
            {
                return memoryDictionary.Count(x => x.Key.StartsWith(className)) + 1;
            }
            catch
            {
                //No es una buena práctica un catch sin registrar el error o sin retornarlo a la llamada, está así solo por simplificar
                return -1;
            }
        }
    }
}
