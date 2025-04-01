using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YourNamespace
{
    [TestClass]
    public class CsvDataDrivenTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\TestData.csv",
            "TestData#csv",
            DataAccessMethod.Sequential)]
        public void TestWithCsvDataSource()
        {
            // Access data from the current row
            int number = Convert.ToInt32(TestContext.DataRow["Number"]);
            string name = TestContext.DataRow["Name"].ToString();

            Console.WriteLine($"Number: {number}, Name: {name}");

            // Example assertions or logic
            Assert.IsTrue(number > 0);
            Assert.IsFalse(string.IsNullOrEmpty(name));
        }
    }
}
