using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple_Inventory_Management_System;
using Inventory_Management_System;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Inventory inventory;

        [TestInitialize]
        public void Setup()
        {
            inventory = new Inventory();
        }

        [TestMethod]
        public void Test_Add_Product()
        {
            var product = new Product("Apple", 1.5, 10);
            inventory.Add(product);
            Assert.AreEqual(1, inventory.Products.Count);
        }

        [TestMethod]
        public void Test_Delete_Product()
        {
            var product = new Product("Apple", 1.5, 10);
            inventory.Add(product);
            bool result = inventory.Delete("Apple");
            Assert.IsTrue(result);
            Assert.AreEqual(0, inventory.Products.Count);
        }

        [TestMethod]
        public void Test_Delete_NonExistent_Product()
        {
            bool result = inventory.Delete("Banana");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Find_Product()
        {
            var product = new Product("Apple", 1.5, 10);
            inventory.Add(product);
            var found = inventory.Find("Apple");
            Assert.IsNotNull(found);
            Assert.AreEqual("Apple", found.Name);
        }

        [TestMethod]
        public void Test_Find_NonExistent_Product()
        {
            var found = inventory.Find("Mango");
            Assert.IsNull(found);
        }

        [TestMethod]
        public void Test_Product_ToString_Format()
        {
            var product = new Product("Orange", 2.5, 8);
            string expected = "Product Name: Orange, Price: 2.5, Quantity: 8 ";
            Assert.AreEqual(expected, product.ToString());
        }

        [TestMethod]
        public void Test_Print_Products()
        {
            var product1 = new Product("A", 1, 1);
            var product2 = new Product("B", 2, 2);
            inventory.Add(product1);
            inventory.Add(product2);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                inventory.Print();
                string output = sw.ToString();
                Assert.IsTrue(output.Contains("Product Name: A"));
                Assert.IsTrue(output.Contains("Product Name: B"));
            }
        }

        [TestMethod]
        public void Test_Edit_Product_Name()
        {
            var product = new Product("Apple", 1.5, 10);
            inventory.Add(product);
            var found = inventory.Find("Apple");
            found.Name = "Red Apple";
            Assert.AreEqual("Red Apple", found.Name);
        }

        [TestMethod]
        public void Test_Edit_Product_Quantity()
        {
            var product = new Product("Apple", 1.5, 10);
            inventory.Add(product);
            var found = inventory.Find("Apple");
            found.Quantity = 25;
            Assert.AreEqual(25, found.Quantity);
        }

        [TestMethod]
        public void Test_Edit_Product_Price()
        {
            var product = new Product("Apple", 1.5, 10);
            inventory.Add(product);
            var found = inventory.Find("Apple");
            found.Price = 3.0;
            Assert.AreEqual(3.0, found.Price);
        }
    }
}
