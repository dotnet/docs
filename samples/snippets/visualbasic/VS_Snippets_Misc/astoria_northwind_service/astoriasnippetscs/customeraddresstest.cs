using NorthwindClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AstoriaSnippetsCS
{

    /// <summary>
    ///This is a test class for CustomerAddressTest and is intended
    ///to contain all CustomerAddressTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerAddressTest
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for Region
        ///</summary>
        [TestMethod()]
        public void RegionTest()
        {
            CustomerAddress target = new CustomerAddress(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Region = expected;
            actual = target.Region;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PostalCode
        ///</summary>
        [TestMethod()]
        public void PostalCodeTest()
        {
            CustomerAddress target = new CustomerAddress(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.PostalCode = expected;
            actual = target.PostalCode;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CustomerID
        ///</summary>
        [TestMethod()]
        public void CustomerIDTest()
        {
            CustomerAddress target = new CustomerAddress(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.CustomerID = expected;
            actual = target.CustomerID;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Country
        ///</summary>
        [TestMethod()]
        public void CountryTest()
        {
            CustomerAddress target = new CustomerAddress(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Country = expected;
            actual = target.Country;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for City
        ///</summary>
        [TestMethod()]
        public void CityTest()
        {
            CustomerAddress target = new CustomerAddress(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.City = expected;
            actual = target.City;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Address
        ///</summary>
        [TestMethod()]
        public void AddressTest()
        {
            CustomerAddress target = new CustomerAddress(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Address = expected;
            actual = target.Address;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CustomerAddress Constructor
        ///</summary>
        [TestMethod()]
        public void CustomerAddressConstructorTest()
        {
            CustomerAddress target = new CustomerAddress();
        }

        /// <summary>
        ///A test for CustomerAddress Constructor
        ///</summary>
        [TestMethod()]
        public void CustomerAddressConstructorTest1()
        {
            string customerID = string.Empty; // TODO: Initialize to an appropriate value
            string address = string.Empty; // TODO: Initialize to an appropriate value
            string city = string.Empty; // TODO: Initialize to an appropriate value
            string region = string.Empty; // TODO: Initialize to an appropriate value
            string postalCode = string.Empty; // TODO: Initialize to an appropriate value
            string country = string.Empty; // TODO: Initialize to an appropriate value
            CustomerAddress target = new CustomerAddress(customerID, address, city, region, postalCode, country);
        }
    }
}
