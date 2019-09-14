using Microsoft.VisualStudio.TestTools.UnitTesting;
using RespiTron.DataProviders;
using System.Collections.Generic;

namespace RespiTron.Test
{
    [TestClass]
    public class MemoryDataProviderUnitTest
    {
        [TestMethod]
        public void SaveItem_NewObject_True()
        {
            //Arrange
            MemoryDataProvider memoryDataProvider = new MemoryDataProvider();
            string key = "testKey";
            List<string> item = new List<string>()
            {
                "item1", "item2", "item3"
            };

            
            //Act
            bool result = memoryDataProvider.SaveItem(key, item);

            //Assert
            Assert.IsTrue(result, "SaveItem is returning a False when have to return a True");
        }

        [TestMethod]
        public void SaveItem_NewObject_False()
        {
            //Arrange
            MemoryDataProvider memoryDataProvider = new MemoryDataProvider();
            string key = null;
            List<string> item = new List<string>()
            {
                "item1", "item2", "item3"
            };


            //Act
            bool result = memoryDataProvider.SaveItem(key, item);

            //Assert
            Assert.IsFalse(result, "SaveItem is returning a True when have to return a False");
        }

        [TestMethod]
        public void SaveItem_NewObject_TrueWithAsserts()
        {
            //Arrange
            MemoryDataProvider memoryDataProvider = new MemoryDataProvider();
            string key = "testKey";
            List<string> item = new List<string>()
            {
                "item1", "item2", "item3"
            };


            //Act
            bool result = memoryDataProvider.SaveItem(key, item);

            //Assert
            Assert.IsTrue(result, "SaveItem is returning a False when have to return a True");
            Assert.ReferenceEquals(item, memoryDataProvider.GetItem<List<string>>(key));
        }

        [TestMethod]
        public void SaveItem_AddedTwoObjects_TrueWithAsserts()
        {
            //Arrange
            MemoryDataProvider memoryDataProvider = new MemoryDataProvider();
            string className = "testKeyClassName";
            string key1 = $"{className}_1";
            List<string> item1 = new List<string>()
            {
                "item1", "item2", "item3"
            };

            string key2 = $"{className}_2";
            List<string> item2 = new List<string>()
            {
                "item1", "item2", "item3"
            };


            //Act2
            bool result1 = memoryDataProvider.SaveItem(key1, item1);
            bool result2 = memoryDataProvider.SaveItem(key2, item2);

            //Assert
            Assert.IsTrue(result1, "SaveItem is returning a False in item 1 when have to return a True");
            Assert.IsTrue(result2, "SaveItem is returning a False in item 2 when have to return a True");
            Assert.ReferenceEquals(item1, memoryDataProvider.GetItem<List<string>>(key1));
            Assert.ReferenceEquals(item2, memoryDataProvider.GetItem<List<string>>(key2));
            Assert.AreEqual(memoryDataProvider.GetItems<List<List<string>>>(className).Count, 2);
        }

        [TestMethod]
        public void SaveItem_AddedTwoObjects_TrueWithCrossReferenceAssert()
        {
            //Arrange
            MemoryDataProvider memoryDataProvider = new MemoryDataProvider();
            string className = "testKeyClassName";
            string key1 = $"{className}_1";
            List<string> item1 = new List<string>()
            {
                "item1", "item2", "item3"
            };

            string key2 = $"{className}_2";
            List<string> item2 = new List<string>()
            {
                "item1", "item2", "item3"
            };

            //Act2
            bool result1 = memoryDataProvider.SaveItem(key1, item1);
            bool result2 = memoryDataProvider.SaveItem(key2, item2);

            //Assert
            Assert.IsTrue(result1, "SaveItem is returning a False in item 1 when have to return a True");
            Assert.IsTrue(result2, "SaveItem is returning a False in item 2 when have to return a True");
            Assert.ReferenceEquals(item1, memoryDataProvider.GetItem<List<string>>(key1));
            Assert.AreNotEqual(item1, memoryDataProvider.GetItem<List<string>>(key2));
            Assert.ReferenceEquals(item2, memoryDataProvider.GetItem<List<string>>(key2));
            Assert.AreNotEqual(item2, memoryDataProvider.GetItem<List<string>>(key1));
            Assert.AreEqual(memoryDataProvider.GetItems<List<List<string>>>(className).Count, 2);
        }
    }
}
