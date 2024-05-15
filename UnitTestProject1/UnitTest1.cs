using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class OpenHashTableTests
    {
        [TestMethod]
        public void Insert_SingleItem_Success()
        {
            OpenHashTable hashTable = new OpenHashTable();
            Price price = new Price("Product1", "Shop1", 10.0);

            hashTable.Insert("Product1", price);
            Price result = hashTable.Search("Product1");

            Assert.IsNotNull(result);
            Assert.AreEqual("Product1", result.ProductName);
            Assert.AreEqual("Shop1", result.ShopName);
            Assert.AreEqual(10.0, result.PriceValue);
        }

        [TestMethod]
        public void Search_NonExistentItem_ReturnsNull()
        {
            OpenHashTable hashTable = new OpenHashTable();

            Price result = hashTable.Search("NonExistentProduct");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Insert_Collision_Success()
        {
            OpenHashTable hashTable = new OpenHashTable();
            Price price1 = new Price("Product1", "Shop1", 10.0);
            Price price2 = new Price("Product2", "Shop2", 20.0);

            hashTable.Insert("Product1", price1);
            hashTable.Insert("Product2", price2);
            Price result1 = hashTable.Search("Product1");
            Price result2 = hashTable.Search("Product2");

            Assert.IsNotNull(result1);
            Assert.AreEqual("Product1", result1.ProductName);
            Assert.AreEqual("Shop1", result1.ShopName);
            Assert.AreEqual(10.0, result1.PriceValue);

            Assert.IsNotNull(result2);
            Assert.AreEqual("Product2", result2.ProductName);
            Assert.AreEqual("Shop2", result2.ShopName);
            Assert.AreEqual(20.0, result2.PriceValue);
        }
    }
}
