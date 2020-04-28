using NorthwindClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Markup;

namespace AstoriaSnippetsVB
{

    /// <summary>
    ///This is a test class for CustomerOrdersWpf3Test and is intended
    ///to contain all CustomerOrdersWpf3Test Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerOrdersWpf3Test
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
        ///A test for CustomerOrdersWpf3 Constructor
        ///</summary>
        [TestMethod()]
        public void CustomerOrdersWpf3ConstructorTest()
        {
            CustomerOrdersWpf3 target = new CustomerOrdersWpf3();
        }

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        [TestMethod()]
        public void InitializeComponentTest()
        {
            IComponentConnector target = new CustomerOrdersWpf3(); // TODO: Initialize to an appropriate value
            target.InitializeComponent();
        }

        /// <summary>
        ///A test for System_Windows_Markup_IComponentConnector_Connect
        ///</summary>
        [TestMethod()]
        public void ConnectTest()
        {
            IComponentConnector target = new CustomerOrdersWpf3(); // TODO: Initialize to an appropriate value
            int connectionId = 0; // TODO: Initialize to an appropriate value
            object target1 = null; // TODO: Initialize to an appropriate value
            target.Connect(connectionId, target1);
        }
    }
}
