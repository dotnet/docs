using NorthwindClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AstoriaSnippetsVB
{

    /// <summary>
    ///This is a test class for SourceVbTest and is intended
    ///to contain all SourceVbTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SourceVbTest
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
        ///A test for SourceVb Constructor
        ///</summary>
        [TestMethod()]
        public void SourceVbConstructorTest()
        {
            SourceVb target = new SourceVb();
        }

        /// <summary>
        ///A test for AddOrderDetailToOrder
        ///</summary>
        [TestMethod()]
        public void AddOrderDetailToOrderTest()
        {
            SourceVb.AddOrderDetailToOrder();
        }

        /// <summary>
        ///A test for AddOrderDetailToOrderAuto
        ///</summary>
        [TestMethod()]
        public void AddOrderDetailToOrderAutoTest()
        {
            SourceVb.AddOrderDetailToOrderAuto();
        }

        /// <summary>
        ///A test for AddProduct
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ApplicationException))]
        public void AddProductTest()
        {
            SourceVb.AddProduct();
        }

        /// <summary>
        ///A test for AddQueryOptions
        ///</summary>
        [TestMethod()]
        public void AddQueryOptionsTest()
        {
            SourceVb.AddQueryOptions();
        }

        /// <summary>
        ///A test for AddQueryOptionsLinq
        ///</summary>
        [TestMethod()]
        public void AddQueryOptionsLinqTest()
        {
            SourceVb.AddQueryOptionsLinq();
        }

        /// <summary>
        ///A test for AttachObject
        ///</summary>
        [TestMethod()]
        public void AttachObjectTest()
        {
            SourceVb.AttachObject();
        }

        /// <summary>
        ///A test for BatchQuery
        ///</summary>
        [TestMethod()]
        public void BatchQueryTest()
        {
            SourceVb.BatchQuery();
        }

        /// <summary>
        ///A test for BeginExecuteCustomersQuery
        ///</summary>
        [TestMethod()]
        public void BeginExecuteCustomersQueryTest()
        {
            SourceVb.BeginExecuteCustomersQuery();
        }

        /// <summary>
        ///A test for CountAllCustomers
        ///</summary>
        [TestMethod()]
        public void CountAllCustomersTest()
        {
            SourceVb.CountAllCustomers();
        }

        /// <summary>
        ///A test for CountAllCustomersValueOnly
        ///</summary>
        [TestMethod()]
        public void CountAllCustomersValueOnlyTest()
        {
            SourceVb.CountAllCustomersValueOnly();
        }

        /// <summary>
        ///A test for DeleteProduct
        ///</summary>
        [TestMethod()]
        public void DeleteProductTest()
        {
            SourceVb.DeleteProduct();
        }

        /// <summary>
        ///A test for ExpandOrderDetails
        ///</summary>
        [TestMethod()]
        public void ExpandOrderDetailsTest()
        {
            SourceVb.ExpandOrderDetails();
        }

        /// <summary>
        ///A test for GetAllCustomers
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersTest()
        {
            SourceVb.GetAllCustomers();
        }

        /// <summary>
        ///A test for GetAllCustomersExplicit
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersExplicitTest()
        {
            SourceVb.GetAllCustomersExplicit();
        }

        /// <summary>
        ///A test for GetAllCustomersFromContext
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersFromContextTest()
        {
            SourceVb.GetAllCustomersFromContext();
        }

        /// <summary>
        ///A test for GetAllCustomersLinq
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersLinqTest()
        {
            SourceVb.GetAllCustomersLinq();
        }

        /// <summary>
        ///A test for GetAllCustomersQuery
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersQueryTest()
        {
            SourceVb.GetAllCustomersQuery();
        }

        /// <summary>
        ///A test for GetCustomersPaged
        ///</summary>
        [TestMethod()]
        public void GetCustomersPagedTest()
        {
            SourceVb.GetCustomersPaged();
        }

        /// <summary>
        ///A test for GetCustomersPagedNested
        ///</summary>
        [TestMethod()]
        public void GetCustomersPagedNestedTest()
        {
            SourceVb.GetCustomersPagedNested();
        }

        /// <summary>
        ///A test for LoadRelatedOrderCustomer
        ///</summary>
        [TestMethod()]
        public void LoadRelatedOrderCustomerTest()
        {
            SourceVb.LoadRelatedOrderCustomer();
        }

        /// <summary>
        ///A test for LoadRelatedOrderDetails
        ///</summary>
        [TestMethod()]
        public void LoadRelatedOrderDetailsTest()
        {
            SourceVb.LoadRelatedOrderDetails();
        }

        /// <summary>
        ///A test for ModifyCustomer
        ///</summary>
        [TestMethod()]
        public void ModifyCustomerTest()
        {
            SourceVb.ModifyCustomer();
        }

        /// <summary>
        ///A test for OrderWithFilter
        ///</summary>
        [TestMethod()]
        public void OrderWithFilterTest()
        {
            SourceVb.OrderWithFilter();
        }

        /// <summary>
        ///A test for ProjectWithConstructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void ProjectWithConstructorTest()
        {
            SourceVb.ProjectWithConstructor();
        }

        /// <summary>
        ///A test for ProjectWithConvertion
        ///</summary>
        [TestMethod()]
        public void ProjectWithConvertionTest()
        {
            SourceVb.ProjectWithConvertion();
        }

        /// <summary>
        ///A test for ProjectWithTransform
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void ProjectWithTransformTest()
        {
            SourceVb.ProjectWithTransform();
        }

        /// <summary>
        ///A test for SelectCustomerAddress
        ///</summary>
        [TestMethod()]
        public void SelectCustomerAddressTest()
        {
            SourceVb.SelectCustomerAddress();
        }

        /// <summary>
        ///A test for SelectCustomerAddressNonEntity
        ///</summary>
        [TestMethod()]
        public void SelectCustomerAddressNonEntityTest()
        {
            SourceVb.SelectCustomerAddressNonEntity();
        }

        /// <summary>
        ///A test for AddQueryOptionsLinqExpression
        ///</summary>
        [TestMethod()]
        public void AddQueryOptionsLinqExpressionTest()
        {
            SourceVb.AddQueryOptionsLinqExpression();
        }

        /// <summary>
        ///A test for ExplicitQueryOrderByMethod
        ///</summary>
        [TestMethod()]
        public void ExplicitQueryOrderByMethodTest()
        {
            SourceVb.ExplicitQueryOrderByMethod();
        }

        /// <summary>
        ///A test for ExplicitQuerySkipTakeMethod
        ///</summary>
        [TestMethod()]
        public void ExplicitQuerySkipTakeMethodTest()
        {
            SourceVb.ExplicitQuerySkipTakeMethod();
        }

        /// <summary>
        ///A test for ExplicitQueryWhereMethod
        ///</summary>
        [TestMethod()]
        public void ExplicitQueryWhereMethodTest()
        {
            SourceVb.ExplicitQueryWhereMethod();
        }

        /// <summary>
        ///A test for LinqMethodPrecedence
        ///</summary>
        [TestMethod()]
        public void LinqMethodPrecedenceTest()
        {
            SourceVb.LinqMethodPrecedence();
        }

        /// <summary>
        ///A test for LinqOrderByClause
        ///</summary>
        [TestMethod()]
        public void LinqOrderByClauseTest()
        {
            SourceVb.LinqOrderByClause();
        }

        /// <summary>
        ///A test for LinqOrderByMethod
        ///</summary>
        [TestMethod()]
        public void LinqOrderByMethodTest()
        {
            SourceVb.LinqOrderByMethod();
        }

        /// <summary>
        ///A test for LinqQueryClientEval
        ///</summary>
        [TestMethod()]
        public void LinqQueryClientEvalTest()
        {
            SourceVb.LinqQueryClientEval();
        }

        /// <summary>
        ///A test for LinqQueryExpand
        ///</summary>
        [TestMethod()]
        public void LinqQueryExpandTest()
        {
            SourceVb.LinqQueryExpand();
        }

        /// <summary>
        ///A test for LinqQueryExpandMethod
        ///</summary>
        [TestMethod()]
        public void LinqQueryExpandMethodTest()
        {
            SourceVb.LinqQueryExpandMethod();
        }

        /// <summary>
        ///A test for LinqQueryPrecedence
        ///</summary>
        [TestMethod()]
        public void LinqQueryPrecedenceTest()
        {
            SourceVb.LinqQueryPrecedence();
        }

        /// <summary>
        ///A test for LinqSelectClause
        ///</summary>
        [TestMethod()]
        public void LinqSelectClauseTest()
        {
            SourceVb.LinqSelectClause();
        }

        /// <summary>
        ///A test for LinqSelectMethod
        ///</summary>
        [TestMethod()]
        public void LinqSelectMethodTest()
        {
            SourceVb.LinqSelectMethod();
        }

        /// <summary>
        ///A test for LinqSkipTakeMethod
        ///</summary>
        [TestMethod()]
        public void LinqSkipTakeMethodTest()
        {
            SourceVb.LinqSkipTakeMethod();
        }

        /// <summary>
        ///A test for LinqWhereClause
        ///</summary>
        [TestMethod()]
        public void LinqWhereClauseTest()
        {
            SourceVb.LinqWhereClause();
        }

        /// <summary>
        ///A test for LinqWhereMethod
        ///</summary>
        [TestMethod()]
        public void LinqWhereMethodTest()
        {
            SourceVb.LinqWhereMethod();
        }

        /// <summary>
        ///A test for RegisterHeadersQuery
        ///</summary>
        [TestMethod()]
        public void RegisterHeadersQueryTest()
        {
            SourceVb.RegisterHeadersQuery();
        }

        /// <summary>
        ///A test for CallServiceOperationAsync
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationAsyncTest()
        {
            SourceVb.CallServiceOperationAsync();
        }

        /// <summary>
        ///A test for CallServiceOperationIQueryable
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationIQueryableTest()
        {
            SourceVb.CallServiceOperationIQueryable();
        }

        /// <summary>
        ///A test for CallServiceOperationSingleEntity
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationSingleEntityTest()
        {
            SourceVb.CallServiceOperationSingleEntity();
        }

        /// <summary>
        ///A test for CallServiceOperationSingleInt
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationSingleIntTest()
        {
            SourceVb.CallServiceOperationSingleInt();
        }

        /// <summary>
        ///A test for CallServiceOperationVoid
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationVoidTest()
        {
            SourceVb.CallServiceOperationVoid();
        }

        /// <summary>
        ///A test for CallServiceOperationCreateQuery
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationCreateQueryTest()
        {
            SourceVb.CallServiceOperationCreateQuery();
        }
    }
}
