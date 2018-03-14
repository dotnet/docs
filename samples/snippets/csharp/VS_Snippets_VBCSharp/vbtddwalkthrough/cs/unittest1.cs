using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using GFUDemo_CS;



namespace TestProject1
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class AutomobileTest
    {
        public AutomobileTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion



        [TestMethod]
        public void DefaultAutomobileIsInitializedCorrectly()
        {
            Automobile myAuto = new Automobile();

            //<Snippet1>
            Assert.IsTrue((myAuto.Model == "Not specified") && (myAuto.TopSpeed == -1));
            //</Snippet1>
        }

        [TestMethod]
        public void AutomobileWithModelNameCanStart()
        {
            string model = "Contoso";
            int topSpeed = 199;
            Automobile myAuto = new Automobile(model, topSpeed);

            //<Snippet3>
            myAuto.Start();
            Assert.IsTrue(myAuto.IsRunning == true);
            //</Snippet3>
        }

    }
}
