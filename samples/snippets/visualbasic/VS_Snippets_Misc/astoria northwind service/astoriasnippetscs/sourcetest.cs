using NorthwindClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AstoriaSnippetsCS
{
    
    
    /// <summary>
    ///This is a test class for SourceTest and is intended
    ///to contain all SourceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SourceTest
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
        ///A test for SelectCustomerAddressNonEntity
        ///</summary>
        [TestMethod()]
        public void SelectCustomerAddressNonEntityTest()
        {
            Source.SelectCustomerAddressNonEntity();
        }

        /// <summary>
        ///A test for SelectCustomerAddress
        ///</summary>
        [TestMethod()]
        public void SelectCustomerAddressTest()
        {
            Source.SelectCustomerAddress();
        }

        /// <summary>
        ///A test for ProjectWithTransform
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void ProjectWithTransformTest()
        {
            Source.ProjectWithTransform();
        }

        /// <summary>
        ///A test for ProjectWithConvertion
        ///</summary>
        [TestMethod()]
        public void ProjectWithConvertionTest()
        {
            Source.ProjectWithConvertion();
        }

        /// <summary>
        ///A test for ProjectWithConstructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void ProjectWithConstructorTest()
        {
            Source.ProjectWithConstructor();
        }

        /// <summary>
        ///A test for OrderWithFilter
        ///</summary>
        [TestMethod()]
        public void OrderWithFilterTest()
        {
            Source.OrderWithFilter();
        }

        /// <summary>
        ///A test for ModifyCustomer
        ///</summary>
        [TestMethod()]
        public void ModifyCustomerTest()
        {
            Source.ModifyCustomer();
        }

        /// <summary>
        ///A test for LoadRelatedOrderDetails
        ///</summary>
        [TestMethod()]
        public void LoadRelatedOrderDetailsTest()
        {
            Source.LoadRelatedOrderDetails();
        }

        /// <summary>
        ///A test for LoadRelatedOrderCustomer
        ///</summary>
        [TestMethod()]
        public void LoadRelatedOrderCustomerTest()
        {
            Source.LoadRelatedOrderCustomer();
        }

        /// <summary>
        ///A test for GetCustomersPagedNested
        ///</summary>
        [TestMethod()]
        public void GetCustomersPagedNestedTest()
        {
            Source.GetCustomersPagedNested();
        }

        /// <summary>
        ///A test for GetCustomersPaged
        ///</summary>
        [TestMethod()]
        public void GetCustomersPagedTest()
        {
            Source.GetCustomersPaged();
        }

        /// <summary>
        ///A test for GetAllCustomersQuery
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersQueryTest()
        {
            Source.GetAllCustomersQuery();
        }

        /// <summary>
        ///A test for GetAllCustomersLinq
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersLinqTest()
        {
            Source.GetAllCustomersLinq();
        }

        /// <summary>
        ///A test for GetAllCustomersFromContext
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersFromContextTest()
        {
            Source.GetAllCustomersFromContext();
        }

        /// <summary>
        ///A test for GetAllCustomersExplicit
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersExplicitTest()
        {
            Source.GetAllCustomersExplicit();
        }

        /// <summary>
        ///A test for GetAllCustomers
        ///</summary>
        [TestMethod()]
        public void GetAllCustomersTest()
        {
            Source.GetAllCustomers();
        }

        /// <summary>
        ///A test for ExpandOrderDetails
        ///</summary>
        [TestMethod()]
        public void ExpandOrderDetailsTest()
        {
            Source.ExpandOrderDetails();
        }

        /// <summary>
        ///A test for DeleteProduct
        ///</summary>
        [TestMethod()]
        public void DeleteProductTest()
        {
            Source.DeleteProduct();
        }

        /// <summary>
        ///A test for CountAllCustomersValueOnly
        ///</summary>
        [TestMethod()]
        public void CountAllCustomersValueOnlyTest()
        {
            Source.CountAllCustomersValueOnly();
        }

        /// <summary>
        ///A test for CountAllCustomers
        ///</summary>
        [TestMethod()]
        public void CountAllCustomersTest()
        {
            Source.CountAllCustomers();
        }

        /// <summary>
        ///A test for BeginExecuteCustomersQuery
        ///</summary>
        [TestMethod()]
        public void BeginExecuteCustomersQueryTest()
        {
            Source.BeginExecuteCustomersQuery();
        }

        /// <summary>
        ///A test for BatchQuery
        ///</summary>
        [TestMethod()]
        public void BatchQueryTest()
        {
            Source.BatchQuery();
        }

        /// <summary>
        ///A test for AttachObject
        ///</summary>
        [TestMethod()]
        public void AttachObjectTest()
        {
            Source.AttachObject();
        }

        /// <summary>
        ///A test for AddQueryOptionsLinqExpression
        ///</summary>
        [TestMethod()]
        public void AddQueryOptionsLinqExpressionTest()
        {
            Source.AddQueryOptionsLinqExpression();
        }

        /// <summary>
        ///A test for AddQueryOptionsLinq
        ///</summary>
        [TestMethod()]
        public void AddQueryOptionsLinqTest()
        {
            Source.AddQueryOptionsLinq();
        }

        /// <summary>
        ///A test for AddQueryOptions
        ///</summary>
        [TestMethod()]
        public void AddQueryOptionsTest()
        {
            Source.AddQueryOptions();
        }

        /// <summary>
        ///A test for AddProduct
        ///</summary>
        [TestMethod()]
        public void AddProductTest()
        {
            Source.AddProduct();
        }

        /// <summary>
        ///A test for AddOrderDetailToOrderAuto
        ///</summary>
        [TestMethod()]
        public void AddOrderDetailToOrderAutoTest()
        {
            Source.AddOrderDetailToOrderAuto();
        }

        /// <summary>
        ///A test for AddOrderDetailToOrder
        ///</summary>
        [TestMethod()]
        public void AddOrderDetailToOrderTest()
        {
            Source.AddOrderDetailToOrder();
        }

        /// <summary>
        ///A test for LinqWhereClause
        ///</summary>
        [TestMethod()]
        public void LinqWhereClauseTest()
        {
            Source.LinqWhereClause();
        }

        /// <summary>
        ///A test for LinqWhereMethod
        ///</summary>
        [TestMethod()]
        public void LinqWhereMethodTest()
        {
            Source.LinqWhereMethod();
        }

        /// <summary>
        ///A test for ExplicitQueryWhereMethod
        ///</summary>
        [TestMethod()]
        public void ExplicitQueryWhereMethodTest()
        {
            Source.ExplicitQueryWhereMethod();
        }

        /// <summary>
        ///A test for LinqSelectClause
        ///</summary>
        [TestMethod()]
        public void LinqSelectClauseTest()
        {
            Source.LinqSelectClause();
        }

        /// <summary>
        ///A test for LinqSelectMethod
        ///</summary>
        [TestMethod()]
        public void LinqSelectMethodTest()
        {
            Source.LinqSelectMethod();
        }

        /// <summary>
        ///A test for LinqMethodPrecedence
        ///</summary>
        [TestMethod()]
        public void LinqMethodPrecedenceTest()
        {
            Source.LinqMethodPrecedence();
        }

        /// <summary>
        ///A test for LinqQueryPrecedence
        ///</summary>
        [TestMethod()]
        public void LinqQueryPrecedenceTest()
        {
            Source.LinqQueryPrecedence();
        }

        /// <summary>
        ///A test for ExplicitQueryOrderByMethod
        ///</summary>
        [TestMethod()]
        public void ExplicitQueryOrderByMethodTest()
        {
            Source.ExplicitQueryOrderByMethod();
        }

        /// <summary>
        ///A test for ExplicitQuerySkipTakeMethod
        ///</summary>
        [TestMethod()]
        public void ExplicitQuerySkipTakeMethodTest()
        {
            Source.ExplicitQuerySkipTakeMethod();
        }

        /// <summary>
        ///A test for LinqOrderByClause
        ///</summary>
        [TestMethod()]
        public void LinqOrderByClauseTest()
        {
            Source.LinqOrderByClause();
        }

        /// <summary>
        ///A test for LinqOrderByMethod
        ///</summary>
        [TestMethod()]
        public void LinqOrderByMethodTest()
        {
            Source.LinqOrderByMethod();
        }

        /// <summary>
        ///A test for LinqQueryClientEval
        ///</summary>
        [TestMethod()]
        public void LinqQueryClientEvalTest()
        {
            Source.LinqQueryClientEval();
        }

        /// <summary>
        ///A test for LinqQueryExpand
        ///</summary>
        [TestMethod()]
        public void LinqQueryExpandTest()
        {
            Source.LinqQueryExpand();
        }

        /// <summary>
        ///A test for LinqQueryExpandMethod
        ///</summary>
        [TestMethod()]
        public void LinqQueryExpandMethodTest()
        {
            Source.LinqQueryExpandMethod();
        }

        /// <summary>
        ///A test for LinqSkipTakeMethod
        ///</summary>
        [TestMethod()]
        public void LinqSkipTakeMethodTest()
        {
            Source.LinqSkipTakeMethod();
        }

        /// <summary>
        ///A test for RegisterHeadersQuery
        ///</summary>
        [TestMethod()]
        public void RegisterHeadersQueryTest()
        {
            Source.RegisterHeadersQuery();
        }

        /// <summary>
        ///A test for CallServiceOperationAsync
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationAsyncTest()
        {
            Source.CallServiceOperationAsync();
        }

        /// <summary>
        ///A test for CallServiceOperationCreateQuery
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationCreateQueryTest()
        {
            Source.CallServiceOperationCreateQuery();
        }

        /// <summary>
        ///A test for CallServiceOperationEnumString
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationEnumStringTest()
        {
            Source.CallServiceOperationEnumString();
        }

        /// <summary>
        ///A test for CallServiceOperationIQueryable
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationIQueryableTest()
        {
            Source.CallServiceOperationIQueryable();
        }

        /// <summary>
        ///A test for CallServiceOperationSingleEntity
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationSingleEntityTest()
        {
            Source.CallServiceOperationSingleEntity();
        }

        /// <summary>
        ///A test for CallServiceOperationSingleInt
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationSingleIntTest()
        {
            Source.CallServiceOperationSingleInt();
        }

        /// <summary>
        ///A test for CallServiceOperationVoid
        ///</summary>
        [TestMethod()]
        public void CallServiceOperationVoidTest()
        {
            Source.CallServiceOperationVoid();
        }
  }
}
