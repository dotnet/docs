using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using Microsoft.VisualBasic.Activities;
using System.Net;
using System.Activities.Expressions;
using WCFDataServicesActivityExample.Northwind;
using System.Collections.Generic;
using System.Data.Services.Client;

// Snippets
// 1 - Workflow using InvokeMethod activity
// 2 - Calling an OData service using WebClient
// 3 - Just the InvokeMethod activity from snippet 1

// 10 - Using OrdersByCustomer
// 20 - Using ListCustomers

// 100 - OrdersByCustomer - calling .NET Methods Async version

// 200 - ListCustomers - using a Delegate

// Steps for InvokeMethod
// Add using Statements for these:
//using Microsoft.VisualBasic.Activities;   - for VisualBasicValue
//using System.Net;                         - for WebClient
//using System.Activities.Expressions;      - for InvokeMethod<TResult>

// then just the code
// Reference this page:
// http://msdn.microsoft.com/library/dd728283.aspx

// Steps for using Northwind
// Add Service Reference: http://services.odata.org/Northwind/Northwind.svc/
// Namespace: Northwind
// add using WCFDataServicesActivityExample.Northwind;
// add using System.Collections.Generic     - for IEnumerable
// add using System.Data.Services.Client;   - for DataContext and others
// create class, OrdersByCustomer

namespace WCFDataServicesActivityExample
{

    class Program
    {
        static void Main(string[] args)
        {
            //snippet1();
            //snippet10();
            snippet20();
            //snippet2();
        }

        private static void snippet20()
        {
            //<snippet20>
            Variable<List<Customer>> customers = new Variable<List<Customer>>();
            DelegateInArgument<Customer> customer = new DelegateInArgument<Customer>();

            Activity wf = new Sequence
            {
                Variables = { customers },
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Calling WCF Data Service..."
                    },
                    new ListCustomers
                    {
                        ServiceUri = "http://services.odata.org/Northwind/Northwind.svc/",
                        Result = customers
                    },
                    new ForEach<Customer>
                    {
                        Values = customers,
                        Body = new ActivityAction<Customer>
                        {
                            Argument = customer,
                            Handler = new WriteLine
                            {
                                Text = new InArgument<string>((env) => string.Format("{0}, Contact: {1}",
                                    customer.Get(env).CompanyName, customer.Get(env).ContactName))
                            }
                        }
                    }
                }
            };

            WorkflowInvoker.Invoke(wf);
            //</snippet20>
        }

        private static void snippet10()
        {
            //<snippet10>
            Variable<IEnumerable<Order>> orders = new Variable<IEnumerable<Order>>();
            DelegateInArgument<Order> order = new DelegateInArgument<Order>();

            Activity wf = new Sequence
            {
                Variables = { orders },
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Calling WCF Data Service..."
                    },
                    new OrdersByCustomer
                    {
                        ServiceUri = "http://services.odata.org/Northwind/Northwind.svc/",
                        CustomerId = "ALFKI",
                        Result = orders
                    },
                    new ForEach<Order>
                    {
                        Values = orders,
                        Body = new ActivityAction<Order>
                        {
                            Argument = order,
                            Handler = new WriteLine
                            {
                                Text = new InArgument<string>((env) => string.Format("{0:d}", order.Get(env).OrderDate))
                            }
                        }
                    }
                }
            };

            WorkflowInvoker.Invoke(wf);
            //</snippet10>
        }

        private static void snippet1()
        {
            //<snippet1>
            Variable<string> data = new Variable<string>();

            Activity wf = new Sequence
            {
                Variables = { data },
                Activities =
                {
                    new WriteLine
                    {
                        Text = "Calling WCF Data Service..."
                    },
                    //<snippet3>
                    new InvokeMethod<string>
                    {
                        TargetObject = new InArgument<WebClient>(new VisualBasicValue<WebClient>("New System.Net.WebClient()")),
                        MethodName = "DownloadString",
                        Parameters =
                        {
                            new InArgument<string>("http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')/Orders")
                        },
                        Result = data,
                        RunAsynchronously = true
                    },
                    //</snippet3>
                    new WriteLine
                    {
                        Text = new InArgument<string>(env => string.Format("Raw data returned:\n{0}", data.Get(env)))
                    }
                }
            };

            WorkflowInvoker.Invoke(wf);
            //</snippet1>
        }

        private static void snippet2()
        {
            //<snippet2>
            string uri = "http://services.odata.org/Northwind/Northwind.svc/Customers('ALFKI')/ContactName";
            WebClient client = new WebClient();
            string data = client.DownloadString(uri);
            Console.WriteLine($"Raw data returned:\n{data}");
            //</snippet2>
        }
    }

    //<snippet100>
    class OrdersByCustomer : AsyncCodeActivity<IEnumerable<Order>>
    {
        [RequiredArgument]
        public InArgument<string> CustomerId { get; set; }

        [RequiredArgument]
        public InArgument<string> ServiceUri { get; set; }

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            NorthwindEntities dataContext = new NorthwindEntities(new Uri(ServiceUri.Get(context)));

            // Define a LINQ query that returns Orders and
            // Order_Details for a specific customer.
            DataServiceQuery<Order> ordersQuery = (DataServiceQuery<Order>)
                from o in dataContext.Orders.Expand("Order_Details")
                where o.Customer.CustomerID == CustomerId.Get(context)
                select o;

            // Specify the query as the UserState for the AsyncCodeActivityContext
            context.UserState = ordersQuery;

            // The callback and state used here are the ones passed into
            // the BeginExecute of this activity.
            return ordersQuery.BeginExecute(callback, state);
        }

        protected override IEnumerable<Order> EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            // Get the DataServiceQuery from the context.UserState
            DataServiceQuery<Order> ordersQuery = context.UserState as DataServiceQuery<Order>;

            // Return an IEnumerable of the query results.
            return ordersQuery.EndExecute(result);
        }
    }
    //</snippet100>

    //<snippet200>
    class ListCustomers : AsyncCodeActivity<List<Customer>>
    {
        [RequiredArgument]
        public InArgument<string> ServiceUri { get; set; }

        protected override IAsyncResult BeginExecute(AsyncCodeActivityContext context, AsyncCallback callback, object state)
        {
            // Create a delegate that references the method that implements
            // the asynchronous work. Assign the delegate to the UserState,
            // invoke the delegate, and return the resulting IAsyncResult.
            Func<string, List<Customer>> GetCustomersDelegate = new Func<string, List<Customer>>(GetCustomers);
            context.UserState = GetCustomersDelegate;
            return GetCustomersDelegate.BeginInvoke(ServiceUri.Get(context), callback, state);
        }

        protected override List<Customer> EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
        {
            // Get the delegate from the UserState and call EndInvoke
            Func<string, List<Customer>> GetCustomersDelegate = (Func<string, List<Customer>>)context.UserState;
            return (List<Customer>)GetCustomersDelegate.EndInvoke(result);
        }

        List<Customer> GetCustomers(string serviceUri)
        {
            // Get all customers here and add them to a list. This method doesn't have access to the
            // activity's environment of arguments, so the Service Uri is passed in.

            // Create the DataServiceContext using the service URI.
            NorthwindEntities context = new NorthwindEntities(new Uri(serviceUri));

            // Return all customers.
            QueryOperationResponse<Customer> response =
                context.Customers.Execute() as QueryOperationResponse<Customer>;

            // Add them to the list.
            List<Customer> customers = new List<Customer>(response);

            // Is this the complete list or are the results paged?
            DataServiceQueryContinuation<Customer> token;
            while ((token = response.GetContinuation()) != null)
            {
                // Load the next page of results.
                response = context.Execute<Customer>(token) as QueryOperationResponse<Customer>;

                // Add the next page of customers to the list.
                customers.AddRange(response);
            }

            // Return the list of customers
            return customers;
        }
    }
    //</snippet200>
}
    // Northwind Entities from Add Service Reference

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 5/18/2010 4:05:15 PM
namespace WCFDataServicesActivityExample.Northwind
{

    /// <summary>
    /// There are no comments for NorthwindEntities in the schema.
    /// </summary>
    public partial class NorthwindEntities : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new NorthwindEntities object.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public NorthwindEntities(global::System.Uri serviceRoot) :
            base(serviceRoot)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            if (typeName.StartsWith("NorthwindModel", global::System.StringComparison.Ordinal))
            {
                return this.GetType().Assembly.GetType(string.Concat("WCFDataServicesActivityExample.Northwind", typeName.Substring(14)), false);
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("WCFDataServicesActivityExample.Northwind", global::System.StringComparison.Ordinal))
            {
                return string.Concat("NorthwindModel.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// There are no comments for Categories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Category> Categories
        {
            get
            {
                if ((this._Categories == null))
                {
                    this._Categories = base.CreateQuery<Category>("Categories");
                }
                return this._Categories;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Category> _Categories;
        /// <summary>
        /// There are no comments for CustomerDemographics in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<CustomerDemographic> CustomerDemographics
        {
            get
            {
                if ((this._CustomerDemographics == null))
                {
                    this._CustomerDemographics = base.CreateQuery<CustomerDemographic>("CustomerDemographics");
                }
                return this._CustomerDemographics;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<CustomerDemographic> _CustomerDemographics;
        /// <summary>
        /// There are no comments for Customers in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Customer> Customers
        {
            get
            {
                if ((this._Customers == null))
                {
                    this._Customers = base.CreateQuery<Customer>("Customers");
                }
                return this._Customers;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Customer> _Customers;
        /// <summary>
        /// There are no comments for Employees in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Employee> Employees
        {
            get
            {
                if ((this._Employees == null))
                {
                    this._Employees = base.CreateQuery<Employee>("Employees");
                }
                return this._Employees;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Employee> _Employees;
        /// <summary>
        /// There are no comments for Order_Details in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Order_Detail> Order_Details
        {
            get
            {
                if ((this._Order_Details == null))
                {
                    this._Order_Details = base.CreateQuery<Order_Detail>("Order_Details");
                }
                return this._Order_Details;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Order_Detail> _Order_Details;
        /// <summary>
        /// There are no comments for Orders in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Order> Orders
        {
            get
            {
                if ((this._Orders == null))
                {
                    this._Orders = base.CreateQuery<Order>("Orders");
                }
                return this._Orders;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Order> _Orders;
        /// <summary>
        /// There are no comments for Products in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Product> Products
        {
            get
            {
                if ((this._Products == null))
                {
                    this._Products = base.CreateQuery<Product>("Products");
                }
                return this._Products;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Product> _Products;
        /// <summary>
        /// There are no comments for Regions in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Region> Regions
        {
            get
            {
                if ((this._Regions == null))
                {
                    this._Regions = base.CreateQuery<Region>("Regions");
                }
                return this._Regions;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Region> _Regions;
        /// <summary>
        /// There are no comments for Shippers in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Shipper> Shippers
        {
            get
            {
                if ((this._Shippers == null))
                {
                    this._Shippers = base.CreateQuery<Shipper>("Shippers");
                }
                return this._Shippers;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Shipper> _Shippers;
        /// <summary>
        /// There are no comments for Suppliers in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Supplier> Suppliers
        {
            get
            {
                if ((this._Suppliers == null))
                {
                    this._Suppliers = base.CreateQuery<Supplier>("Suppliers");
                }
                return this._Suppliers;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Supplier> _Suppliers;
        /// <summary>
        /// There are no comments for Territories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Territory> Territories
        {
            get
            {
                if ((this._Territories == null))
                {
                    this._Territories = base.CreateQuery<Territory>("Territories");
                }
                return this._Territories;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Territory> _Territories;
        /// <summary>
        /// There are no comments for Alphabetical_list_of_products in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Alphabetical_list_of_product> Alphabetical_list_of_products
        {
            get
            {
                if ((this._Alphabetical_list_of_products == null))
                {
                    this._Alphabetical_list_of_products = base.CreateQuery<Alphabetical_list_of_product>("Alphabetical_list_of_products");
                }
                return this._Alphabetical_list_of_products;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Alphabetical_list_of_product> _Alphabetical_list_of_products;
        /// <summary>
        /// There are no comments for Category_Sales_for_1997 in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Category_Sales_for_1997> Category_Sales_for_1997
        {
            get
            {
                if ((this._Category_Sales_for_1997 == null))
                {
                    this._Category_Sales_for_1997 = base.CreateQuery<Category_Sales_for_1997>("Category_Sales_for_1997");
                }
                return this._Category_Sales_for_1997;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Category_Sales_for_1997> _Category_Sales_for_1997;
        /// <summary>
        /// There are no comments for Current_Product_Lists in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Current_Product_List> Current_Product_Lists
        {
            get
            {
                if ((this._Current_Product_Lists == null))
                {
                    this._Current_Product_Lists = base.CreateQuery<Current_Product_List>("Current_Product_Lists");
                }
                return this._Current_Product_Lists;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Current_Product_List> _Current_Product_Lists;
        /// <summary>
        /// There are no comments for Customer_and_Suppliers_by_Cities in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Customer_and_Suppliers_by_City> Customer_and_Suppliers_by_Cities
        {
            get
            {
                if ((this._Customer_and_Suppliers_by_Cities == null))
                {
                    this._Customer_and_Suppliers_by_Cities = base.CreateQuery<Customer_and_Suppliers_by_City>("Customer_and_Suppliers_by_Cities");
                }
                return this._Customer_and_Suppliers_by_Cities;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Customer_and_Suppliers_by_City> _Customer_and_Suppliers_by_Cities;
        /// <summary>
        /// There are no comments for Invoices in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Invoice> Invoices
        {
            get
            {
                if ((this._Invoices == null))
                {
                    this._Invoices = base.CreateQuery<Invoice>("Invoices");
                }
                return this._Invoices;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Invoice> _Invoices;
        /// <summary>
        /// There are no comments for Order_Details_Extendeds in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Order_Details_Extended> Order_Details_Extendeds
        {
            get
            {
                if ((this._Order_Details_Extendeds == null))
                {
                    this._Order_Details_Extendeds = base.CreateQuery<Order_Details_Extended>("Order_Details_Extendeds");
                }
                return this._Order_Details_Extendeds;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Order_Details_Extended> _Order_Details_Extendeds;
        /// <summary>
        /// There are no comments for Order_Subtotals in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Order_Subtotal> Order_Subtotals
        {
            get
            {
                if ((this._Order_Subtotals == null))
                {
                    this._Order_Subtotals = base.CreateQuery<Order_Subtotal>("Order_Subtotals");
                }
                return this._Order_Subtotals;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Order_Subtotal> _Order_Subtotals;
        /// <summary>
        /// There are no comments for Orders_Qries in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Orders_Qry> Orders_Qries
        {
            get
            {
                if ((this._Orders_Qries == null))
                {
                    this._Orders_Qries = base.CreateQuery<Orders_Qry>("Orders_Qries");
                }
                return this._Orders_Qries;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Orders_Qry> _Orders_Qries;
        /// <summary>
        /// There are no comments for Product_Sales_for_1997 in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Product_Sales_for_1997> Product_Sales_for_1997
        {
            get
            {
                if ((this._Product_Sales_for_1997 == null))
                {
                    this._Product_Sales_for_1997 = base.CreateQuery<Product_Sales_for_1997>("Product_Sales_for_1997");
                }
                return this._Product_Sales_for_1997;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Product_Sales_for_1997> _Product_Sales_for_1997;
        /// <summary>
        /// There are no comments for Products_Above_Average_Prices in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Products_Above_Average_Price> Products_Above_Average_Prices
        {
            get
            {
                if ((this._Products_Above_Average_Prices == null))
                {
                    this._Products_Above_Average_Prices = base.CreateQuery<Products_Above_Average_Price>("Products_Above_Average_Prices");
                }
                return this._Products_Above_Average_Prices;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Products_Above_Average_Price> _Products_Above_Average_Prices;
        /// <summary>
        /// There are no comments for Products_by_Categories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Products_by_Category> Products_by_Categories
        {
            get
            {
                if ((this._Products_by_Categories == null))
                {
                    this._Products_by_Categories = base.CreateQuery<Products_by_Category>("Products_by_Categories");
                }
                return this._Products_by_Categories;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Products_by_Category> _Products_by_Categories;
        /// <summary>
        /// There are no comments for Sales_by_Categories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Sales_by_Category> Sales_by_Categories
        {
            get
            {
                if ((this._Sales_by_Categories == null))
                {
                    this._Sales_by_Categories = base.CreateQuery<Sales_by_Category>("Sales_by_Categories");
                }
                return this._Sales_by_Categories;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Sales_by_Category> _Sales_by_Categories;
        /// <summary>
        /// There are no comments for Sales_Totals_by_Amounts in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Sales_Totals_by_Amount> Sales_Totals_by_Amounts
        {
            get
            {
                if ((this._Sales_Totals_by_Amounts == null))
                {
                    this._Sales_Totals_by_Amounts = base.CreateQuery<Sales_Totals_by_Amount>("Sales_Totals_by_Amounts");
                }
                return this._Sales_Totals_by_Amounts;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Sales_Totals_by_Amount> _Sales_Totals_by_Amounts;
        /// <summary>
        /// There are no comments for Summary_of_Sales_by_Quarters in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Summary_of_Sales_by_Quarter> Summary_of_Sales_by_Quarters
        {
            get
            {
                if ((this._Summary_of_Sales_by_Quarters == null))
                {
                    this._Summary_of_Sales_by_Quarters = base.CreateQuery<Summary_of_Sales_by_Quarter>("Summary_of_Sales_by_Quarters");
                }
                return this._Summary_of_Sales_by_Quarters;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Summary_of_Sales_by_Quarter> _Summary_of_Sales_by_Quarters;
        /// <summary>
        /// There are no comments for Summary_of_Sales_by_Years in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Summary_of_Sales_by_Year> Summary_of_Sales_by_Years
        {
            get
            {
                if ((this._Summary_of_Sales_by_Years == null))
                {
                    this._Summary_of_Sales_by_Years = base.CreateQuery<Summary_of_Sales_by_Year>("Summary_of_Sales_by_Years");
                }
                return this._Summary_of_Sales_by_Years;
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Summary_of_Sales_by_Year> _Summary_of_Sales_by_Years;
        /// <summary>
        /// There are no comments for Categories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToCategories(Category category)
        {
            base.AddObject("Categories", category);
        }
        /// <summary>
        /// There are no comments for CustomerDemographics in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToCustomerDemographics(CustomerDemographic customerDemographic)
        {
            base.AddObject("CustomerDemographics", customerDemographic);
        }
        /// <summary>
        /// There are no comments for Customers in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToCustomers(Customer customer)
        {
            base.AddObject("Customers", customer);
        }
        /// <summary>
        /// There are no comments for Employees in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToEmployees(Employee employee)
        {
            base.AddObject("Employees", employee);
        }
        /// <summary>
        /// There are no comments for Order_Details in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToOrder_Details(Order_Detail order_Detail)
        {
            base.AddObject("Order_Details", order_Detail);
        }
        /// <summary>
        /// There are no comments for Orders in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToOrders(Order order)
        {
            base.AddObject("Orders", order);
        }
        /// <summary>
        /// There are no comments for Products in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToProducts(Product product)
        {
            base.AddObject("Products", product);
        }
        /// <summary>
        /// There are no comments for Regions in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToRegions(Region region)
        {
            base.AddObject("Regions", region);
        }
        /// <summary>
        /// There are no comments for Shippers in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToShippers(Shipper shipper)
        {
            base.AddObject("Shippers", shipper);
        }
        /// <summary>
        /// There are no comments for Suppliers in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToSuppliers(Supplier supplier)
        {
            base.AddObject("Suppliers", supplier);
        }
        /// <summary>
        /// There are no comments for Territories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToTerritories(Territory territory)
        {
            base.AddObject("Territories", territory);
        }
        /// <summary>
        /// There are no comments for Alphabetical_list_of_products in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToAlphabetical_list_of_products(Alphabetical_list_of_product alphabetical_list_of_product)
        {
            base.AddObject("Alphabetical_list_of_products", alphabetical_list_of_product);
        }
        /// <summary>
        /// There are no comments for Category_Sales_for_1997 in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToCategory_Sales_for_1997(Category_Sales_for_1997 category_Sales_for_1997)
        {
            base.AddObject("Category_Sales_for_1997", category_Sales_for_1997);
        }
        /// <summary>
        /// There are no comments for Current_Product_Lists in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToCurrent_Product_Lists(Current_Product_List current_Product_List)
        {
            base.AddObject("Current_Product_Lists", current_Product_List);
        }
        /// <summary>
        /// There are no comments for Customer_and_Suppliers_by_Cities in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToCustomer_and_Suppliers_by_Cities(Customer_and_Suppliers_by_City customer_and_Suppliers_by_City)
        {
            base.AddObject("Customer_and_Suppliers_by_Cities", customer_and_Suppliers_by_City);
        }
        /// <summary>
        /// There are no comments for Invoices in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToInvoices(Invoice invoice)
        {
            base.AddObject("Invoices", invoice);
        }
        /// <summary>
        /// There are no comments for Order_Details_Extendeds in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToOrder_Details_Extendeds(Order_Details_Extended order_Details_Extended)
        {
            base.AddObject("Order_Details_Extendeds", order_Details_Extended);
        }
        /// <summary>
        /// There are no comments for Order_Subtotals in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToOrder_Subtotals(Order_Subtotal order_Subtotal)
        {
            base.AddObject("Order_Subtotals", order_Subtotal);
        }
        /// <summary>
        /// There are no comments for Orders_Qries in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToOrders_Qries(Orders_Qry orders_Qry)
        {
            base.AddObject("Orders_Qries", orders_Qry);
        }
        /// <summary>
        /// There are no comments for Product_Sales_for_1997 in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToProduct_Sales_for_1997(Product_Sales_for_1997 product_Sales_for_1997)
        {
            base.AddObject("Product_Sales_for_1997", product_Sales_for_1997);
        }
        /// <summary>
        /// There are no comments for Products_Above_Average_Prices in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToProducts_Above_Average_Prices(Products_Above_Average_Price products_Above_Average_Price)
        {
            base.AddObject("Products_Above_Average_Prices", products_Above_Average_Price);
        }
        /// <summary>
        /// There are no comments for Products_by_Categories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToProducts_by_Categories(Products_by_Category products_by_Category)
        {
            base.AddObject("Products_by_Categories", products_by_Category);
        }
        /// <summary>
        /// There are no comments for Sales_by_Categories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToSales_by_Categories(Sales_by_Category sales_by_Category)
        {
            base.AddObject("Sales_by_Categories", sales_by_Category);
        }
        /// <summary>
        /// There are no comments for Sales_Totals_by_Amounts in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToSales_Totals_by_Amounts(Sales_Totals_by_Amount sales_Totals_by_Amount)
        {
            base.AddObject("Sales_Totals_by_Amounts", sales_Totals_by_Amount);
        }
        /// <summary>
        /// There are no comments for Summary_of_Sales_by_Quarters in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToSummary_of_Sales_by_Quarters(Summary_of_Sales_by_Quarter summary_of_Sales_by_Quarter)
        {
            base.AddObject("Summary_of_Sales_by_Quarters", summary_of_Sales_by_Quarter);
        }
        /// <summary>
        /// There are no comments for Summary_of_Sales_by_Years in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToSummary_of_Sales_by_Years(Summary_of_Sales_by_Year summary_of_Sales_by_Year)
        {
            base.AddObject("Summary_of_Sales_by_Years", summary_of_Sales_by_Year);
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Category in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CategoryID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Categories")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CategoryID")]
    public partial class Category : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Category object.
        /// </summary>
        /// <param name="categoryID">Initial value of CategoryID.</param>
        /// <param name="categoryName">Initial value of CategoryName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Category CreateCategory(int categoryID, string categoryName)
        {
            Category category = new Category();
            category.CategoryID = categoryID;
            category.CategoryName = categoryName;
            return category;
        }
        /// <summary>
        /// There are no comments for Property CategoryID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int CategoryID
        {
            get
            {
                return this._CategoryID;
            }
            set
            {
                this.OnCategoryIDChanging(value);
                this._CategoryID = value;
                this.OnCategoryIDChanged();
                this.OnPropertyChanged("CategoryID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _CategoryID;
        partial void OnCategoryIDChanging(int value);
        partial void OnCategoryIDChanged();
        /// <summary>
        /// There are no comments for Property CategoryName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                this.OnCategoryNameChanging(value);
                this._CategoryName = value;
                this.OnCategoryNameChanged();
                this.OnPropertyChanged("CategoryName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CategoryName;
        partial void OnCategoryNameChanging(string value);
        partial void OnCategoryNameChanged();
        /// <summary>
        /// There are no comments for Property Description in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnDescriptionChanging(value);
                this._Description = value;
                this.OnDescriptionChanged();
                this.OnPropertyChanged("Description");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Description;
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        /// <summary>
        /// There are no comments for Property Picture in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public byte[] Picture
        {
            get
            {
                if ((this._Picture != null))
                {
                    return ((byte[])(this._Picture.Clone()));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.OnPictureChanging(value);
                this._Picture = value;
                this.OnPictureChanged();
                this.OnPropertyChanged("Picture");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private byte[] _Picture;
        partial void OnPictureChanging(byte[] value);
        partial void OnPictureChanged();
        /// <summary>
        /// There are no comments for Products in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Product> Products
        {
            get
            {
                return this._Products;
            }
            set
            {
                this._Products = value;
                this.OnPropertyChanged("Products");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Product> _Products = new global::System.Data.Services.Client.DataServiceCollection<Product>(null, System.Data.Services.Client.TrackingMode.None);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.CustomerDemographic in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CustomerTypeID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("CustomerDemographics")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CustomerTypeID")]
    public partial class CustomerDemographic : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new CustomerDemographic object.
        /// </summary>
        /// <param name="customerTypeID">Initial value of CustomerTypeID.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static CustomerDemographic CreateCustomerDemographic(string customerTypeID)
        {
            CustomerDemographic customerDemographic = new CustomerDemographic();
            customerDemographic.CustomerTypeID = customerTypeID;
            return customerDemographic;
        }
        /// <summary>
        /// There are no comments for Property CustomerTypeID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CustomerTypeID
        {
            get
            {
                return this._CustomerTypeID;
            }
            set
            {
                this.OnCustomerTypeIDChanging(value);
                this._CustomerTypeID = value;
                this.OnCustomerTypeIDChanged();
                this.OnPropertyChanged("CustomerTypeID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CustomerTypeID;
        partial void OnCustomerTypeIDChanging(string value);
        partial void OnCustomerTypeIDChanged();
        /// <summary>
        /// There are no comments for Property CustomerDesc in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CustomerDesc
        {
            get
            {
                return this._CustomerDesc;
            }
            set
            {
                this.OnCustomerDescChanging(value);
                this._CustomerDesc = value;
                this.OnCustomerDescChanged();
                this.OnPropertyChanged("CustomerDesc");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CustomerDesc;
        partial void OnCustomerDescChanging(string value);
        partial void OnCustomerDescChanged();
        /// <summary>
        /// There are no comments for Customers in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Customer> Customers
        {
            get
            {
                return this._Customers;
            }
            set
            {
                this._Customers = value;
                this.OnPropertyChanged("Customers");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Customer> _Customers = new global::System.Data.Services.Client.DataServiceCollection<Customer>(null, System.Data.Services.Client.TrackingMode.None);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Customer in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CustomerID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Customers")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CustomerID")]
    public partial class Customer : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Customer object.
        /// </summary>
        /// <param name="customerID">Initial value of CustomerID.</param>
        /// <param name="companyName">Initial value of CompanyName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Customer CreateCustomer(string customerID, string companyName)
        {
            Customer customer = new Customer();
            customer.CustomerID = customerID;
            customer.CompanyName = companyName;
            return customer;
        }
        /// <summary>
        /// There are no comments for Property CustomerID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this.OnCustomerIDChanging(value);
                this._CustomerID = value;
                this.OnCustomerIDChanged();
                this.OnPropertyChanged("CustomerID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CustomerID;
        partial void OnCustomerIDChanging(string value);
        partial void OnCustomerIDChanged();
        /// <summary>
        /// There are no comments for Property CompanyName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                this.OnCompanyNameChanging(value);
                this._CompanyName = value;
                this.OnCompanyNameChanged();
                this.OnPropertyChanged("CompanyName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CompanyName;
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
        /// <summary>
        /// There are no comments for Property ContactName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ContactName
        {
            get
            {
                return this._ContactName;
            }
            set
            {
                this.OnContactNameChanging(value);
                this._ContactName = value;
                this.OnContactNameChanged();
                this.OnPropertyChanged("ContactName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ContactName;
        partial void OnContactNameChanging(string value);
        partial void OnContactNameChanged();
        /// <summary>
        /// There are no comments for Property ContactTitle in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ContactTitle
        {
            get
            {
                return this._ContactTitle;
            }
            set
            {
                this.OnContactTitleChanging(value);
                this._ContactTitle = value;
                this.OnContactTitleChanged();
                this.OnPropertyChanged("ContactTitle");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ContactTitle;
        partial void OnContactTitleChanging(string value);
        partial void OnContactTitleChanged();
        /// <summary>
        /// There are no comments for Property Address in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this.OnAddressChanging(value);
                this._Address = value;
                this.OnAddressChanged();
                this.OnPropertyChanged("Address");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Address;
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        /// <summary>
        /// There are no comments for Property City in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnCityChanging(value);
                this._City = value;
                this.OnCityChanged();
                this.OnPropertyChanged("City");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _City;
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        /// <summary>
        /// There are no comments for Property Region in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Region
        {
            get
            {
                return this._Region;
            }
            set
            {
                this.OnRegionChanging(value);
                this._Region = value;
                this.OnRegionChanged();
                this.OnPropertyChanged("Region");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Region;
        partial void OnRegionChanging(string value);
        partial void OnRegionChanged();
        /// <summary>
        /// There are no comments for Property PostalCode in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PostalCode
        {
            get
            {
                return this._PostalCode;
            }
            set
            {
                this.OnPostalCodeChanging(value);
                this._PostalCode = value;
                this.OnPostalCodeChanged();
                this.OnPropertyChanged("PostalCode");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PostalCode;
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property Country in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Country
        {
            get
            {
                return this._Country;
            }
            set
            {
                this.OnCountryChanging(value);
                this._Country = value;
                this.OnCountryChanged();
                this.OnPropertyChanged("Country");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Country;
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
        /// <summary>
        /// There are no comments for Property Phone in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                this.OnPhoneChanging(value);
                this._Phone = value;
                this.OnPhoneChanged();
                this.OnPropertyChanged("Phone");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Phone;
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
        /// <summary>
        /// There are no comments for Property Fax in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                this.OnFaxChanging(value);
                this._Fax = value;
                this.OnFaxChanged();
                this.OnPropertyChanged("Fax");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Fax;
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
        /// <summary>
        /// There are no comments for Orders in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Order> Orders
        {
            get
            {
                return this._Orders;
            }
            set
            {
                this._Orders = value;
                this.OnPropertyChanged("Orders");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Order> _Orders = new global::System.Data.Services.Client.DataServiceCollection<Order>(null, System.Data.Services.Client.TrackingMode.None);
        /// <summary>
        /// There are no comments for CustomerDemographics in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<CustomerDemographic> CustomerDemographics
        {
            get
            {
                return this._CustomerDemographics;
            }
            set
            {
                this._CustomerDemographics = value;
                this.OnPropertyChanged("CustomerDemographics");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<CustomerDemographic> _CustomerDemographics = new global::System.Data.Services.Client.DataServiceCollection<CustomerDemographic>(null, System.Data.Services.Client.TrackingMode.None);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Employee in the schema.
    /// </summary>
    /// <KeyProperties>
    /// EmployeeID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Employees")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("EmployeeID")]
    public partial class Employee : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Employee object.
        /// </summary>
        /// <param name="employeeID">Initial value of EmployeeID.</param>
        /// <param name="lastName">Initial value of LastName.</param>
        /// <param name="firstName">Initial value of FirstName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Employee CreateEmployee(int employeeID, string lastName, string firstName)
        {
            Employee employee = new Employee();
            employee.EmployeeID = employeeID;
            employee.LastName = lastName;
            employee.FirstName = firstName;
            return employee;
        }
        /// <summary>
        /// There are no comments for Property EmployeeID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                this.OnEmployeeIDChanging(value);
                this._EmployeeID = value;
                this.OnEmployeeIDChanged();
                this.OnPropertyChanged("EmployeeID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _EmployeeID;
        partial void OnEmployeeIDChanging(int value);
        partial void OnEmployeeIDChanged();
        /// <summary>
        /// There are no comments for Property LastName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this.OnLastNameChanging(value);
                this._LastName = value;
                this.OnLastNameChanged();
                this.OnPropertyChanged("LastName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _LastName;
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        /// <summary>
        /// There are no comments for Property FirstName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this.OnFirstNameChanging(value);
                this._FirstName = value;
                this.OnFirstNameChanged();
                this.OnPropertyChanged("FirstName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _FirstName;
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        /// <summary>
        /// There are no comments for Property Title in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this.OnTitleChanging(value);
                this._Title = value;
                this.OnTitleChanged();
                this.OnPropertyChanged("Title");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Title;
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        /// <summary>
        /// There are no comments for Property TitleOfCourtesy in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string TitleOfCourtesy
        {
            get
            {
                return this._TitleOfCourtesy;
            }
            set
            {
                this.OnTitleOfCourtesyChanging(value);
                this._TitleOfCourtesy = value;
                this.OnTitleOfCourtesyChanged();
                this.OnPropertyChanged("TitleOfCourtesy");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _TitleOfCourtesy;
        partial void OnTitleOfCourtesyChanging(string value);
        partial void OnTitleOfCourtesyChanged();
        /// <summary>
        /// There are no comments for Property BirthDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> BirthDate
        {
            get
            {
                return this._BirthDate;
            }
            set
            {
                this.OnBirthDateChanging(value);
                this._BirthDate = value;
                this.OnBirthDateChanged();
                this.OnPropertyChanged("BirthDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _BirthDate;
        partial void OnBirthDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnBirthDateChanged();
        /// <summary>
        /// There are no comments for Property HireDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> HireDate
        {
            get
            {
                return this._HireDate;
            }
            set
            {
                this.OnHireDateChanging(value);
                this._HireDate = value;
                this.OnHireDateChanged();
                this.OnPropertyChanged("HireDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _HireDate;
        partial void OnHireDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnHireDateChanged();
        /// <summary>
        /// There are no comments for Property Address in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this.OnAddressChanging(value);
                this._Address = value;
                this.OnAddressChanged();
                this.OnPropertyChanged("Address");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Address;
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        /// <summary>
        /// There are no comments for Property City in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnCityChanging(value);
                this._City = value;
                this.OnCityChanged();
                this.OnPropertyChanged("City");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _City;
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        /// <summary>
        /// There are no comments for Property Region in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Region
        {
            get
            {
                return this._Region;
            }
            set
            {
                this.OnRegionChanging(value);
                this._Region = value;
                this.OnRegionChanged();
                this.OnPropertyChanged("Region");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Region;
        partial void OnRegionChanging(string value);
        partial void OnRegionChanged();
        /// <summary>
        /// There are no comments for Property PostalCode in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PostalCode
        {
            get
            {
                return this._PostalCode;
            }
            set
            {
                this.OnPostalCodeChanging(value);
                this._PostalCode = value;
                this.OnPostalCodeChanged();
                this.OnPropertyChanged("PostalCode");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PostalCode;
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property Country in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Country
        {
            get
            {
                return this._Country;
            }
            set
            {
                this.OnCountryChanging(value);
                this._Country = value;
                this.OnCountryChanged();
                this.OnPropertyChanged("Country");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Country;
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
        /// <summary>
        /// There are no comments for Property HomePhone in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string HomePhone
        {
            get
            {
                return this._HomePhone;
            }
            set
            {
                this.OnHomePhoneChanging(value);
                this._HomePhone = value;
                this.OnHomePhoneChanged();
                this.OnPropertyChanged("HomePhone");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _HomePhone;
        partial void OnHomePhoneChanging(string value);
        partial void OnHomePhoneChanged();
        /// <summary>
        /// There are no comments for Property Extension in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Extension
        {
            get
            {
                return this._Extension;
            }
            set
            {
                this.OnExtensionChanging(value);
                this._Extension = value;
                this.OnExtensionChanged();
                this.OnPropertyChanged("Extension");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Extension;
        partial void OnExtensionChanging(string value);
        partial void OnExtensionChanged();
        /// <summary>
        /// There are no comments for Property Photo in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public byte[] Photo
        {
            get
            {
                if ((this._Photo != null))
                {
                    return ((byte[])(this._Photo.Clone()));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.OnPhotoChanging(value);
                this._Photo = value;
                this.OnPhotoChanged();
                this.OnPropertyChanged("Photo");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private byte[] _Photo;
        partial void OnPhotoChanging(byte[] value);
        partial void OnPhotoChanged();
        /// <summary>
        /// There are no comments for Property Notes in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Notes
        {
            get
            {
                return this._Notes;
            }
            set
            {
                this.OnNotesChanging(value);
                this._Notes = value;
                this.OnNotesChanged();
                this.OnPropertyChanged("Notes");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Notes;
        partial void OnNotesChanging(string value);
        partial void OnNotesChanged();
        /// <summary>
        /// There are no comments for Property ReportsTo in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> ReportsTo
        {
            get
            {
                return this._ReportsTo;
            }
            set
            {
                this.OnReportsToChanging(value);
                this._ReportsTo = value;
                this.OnReportsToChanged();
                this.OnPropertyChanged("ReportsTo");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _ReportsTo;
        partial void OnReportsToChanging(global::System.Nullable<int> value);
        partial void OnReportsToChanged();
        /// <summary>
        /// There are no comments for Property PhotoPath in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PhotoPath
        {
            get
            {
                return this._PhotoPath;
            }
            set
            {
                this.OnPhotoPathChanging(value);
                this._PhotoPath = value;
                this.OnPhotoPathChanged();
                this.OnPropertyChanged("PhotoPath");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PhotoPath;
        partial void OnPhotoPathChanging(string value);
        partial void OnPhotoPathChanged();
        /// <summary>
        /// There are no comments for Employees1 in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Employee> Employees1
        {
            get
            {
                return this._Employees1;
            }
            set
            {
                this._Employees1 = value;
                this.OnPropertyChanged("Employees1");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Employee> _Employees1 = new global::System.Data.Services.Client.DataServiceCollection<Employee>(null, System.Data.Services.Client.TrackingMode.None);
        /// <summary>
        /// There are no comments for Employee1 in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Employee Employee1
        {
            get
            {
                return this._Employee1;
            }
            set
            {
                this._Employee1 = value;
                this.OnPropertyChanged("Employee1");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Employee _Employee1;
        /// <summary>
        /// There are no comments for Orders in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Order> Orders
        {
            get
            {
                return this._Orders;
            }
            set
            {
                this._Orders = value;
                this.OnPropertyChanged("Orders");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Order> _Orders = new global::System.Data.Services.Client.DataServiceCollection<Order>(null, System.Data.Services.Client.TrackingMode.None);
        /// <summary>
        /// There are no comments for Territories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Territory> Territories
        {
            get
            {
                return this._Territories;
            }
            set
            {
                this._Territories = value;
                this.OnPropertyChanged("Territories");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Territory> _Territories = new global::System.Data.Services.Client.DataServiceCollection<Territory>(null, System.Data.Services.Client.TrackingMode.None);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Order_Detail in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderID
    /// ProductID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Order_Details")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("OrderID", "ProductID")]
    public partial class Order_Detail : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Order_Detail object.
        /// </summary>
        /// <param name="orderID">Initial value of OrderID.</param>
        /// <param name="productID">Initial value of ProductID.</param>
        /// <param name="unitPrice">Initial value of UnitPrice.</param>
        /// <param name="quantity">Initial value of Quantity.</param>
        /// <param name="discount">Initial value of Discount.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Order_Detail CreateOrder_Detail(int orderID, int productID, decimal unitPrice, short quantity, float discount)
        {
            Order_Detail order_Detail = new Order_Detail();
            order_Detail.OrderID = orderID;
            order_Detail.ProductID = productID;
            order_Detail.UnitPrice = unitPrice;
            order_Detail.Quantity = quantity;
            order_Detail.Discount = discount;
            return order_Detail;
        }
        /// <summary>
        /// There are no comments for Property OrderID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnOrderIDChanging(value);
                this._OrderID = value;
                this.OnOrderIDChanged();
                this.OnPropertyChanged("OrderID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderID;
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        /// <summary>
        /// There are no comments for Property ProductID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this.OnProductIDChanging(value);
                this._ProductID = value;
                this.OnProductIDChanged();
                this.OnPropertyChanged("ProductID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _ProductID;
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
        /// <summary>
        /// There are no comments for Property UnitPrice in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public decimal UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this.OnUnitPriceChanging(value);
                this._UnitPrice = value;
                this.OnUnitPriceChanged();
                this.OnPropertyChanged("UnitPrice");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private decimal _UnitPrice;
        partial void OnUnitPriceChanging(decimal value);
        partial void OnUnitPriceChanged();
        /// <summary>
        /// There are no comments for Property Quantity in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public short Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this.OnQuantityChanging(value);
                this._Quantity = value;
                this.OnQuantityChanged();
                this.OnPropertyChanged("Quantity");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private short _Quantity;
        partial void OnQuantityChanging(short value);
        partial void OnQuantityChanged();
        /// <summary>
        /// There are no comments for Property Discount in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public float Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this.OnDiscountChanging(value);
                this._Discount = value;
                this.OnDiscountChanged();
                this.OnPropertyChanged("Discount");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private float _Discount;
        partial void OnDiscountChanging(float value);
        partial void OnDiscountChanged();
        /// <summary>
        /// There are no comments for Order in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Order Order
        {
            get
            {
                return this._Order;
            }
            set
            {
                this._Order = value;
                this.OnPropertyChanged("Order");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Order _Order;
        /// <summary>
        /// There are no comments for Product in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Product Product
        {
            get
            {
                return this._Product;
            }
            set
            {
                this._Product = value;
                this.OnPropertyChanged("Product");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Product _Product;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Order in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Orders")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("OrderID")]
    public partial class Order : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Order object.
        /// </summary>
        /// <param name="orderID">Initial value of OrderID.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Order CreateOrder(int orderID)
        {
            Order order = new Order();
            order.OrderID = orderID;
            return order;
        }
        /// <summary>
        /// There are no comments for Property OrderID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnOrderIDChanging(value);
                this._OrderID = value;
                this.OnOrderIDChanged();
                this.OnPropertyChanged("OrderID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderID;
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        /// <summary>
        /// There are no comments for Property CustomerID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this.OnCustomerIDChanging(value);
                this._CustomerID = value;
                this.OnCustomerIDChanged();
                this.OnPropertyChanged("CustomerID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CustomerID;
        partial void OnCustomerIDChanging(string value);
        partial void OnCustomerIDChanged();
        /// <summary>
        /// There are no comments for Property EmployeeID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                this.OnEmployeeIDChanging(value);
                this._EmployeeID = value;
                this.OnEmployeeIDChanged();
                this.OnPropertyChanged("EmployeeID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _EmployeeID;
        partial void OnEmployeeIDChanging(global::System.Nullable<int> value);
        partial void OnEmployeeIDChanged();
        /// <summary>
        /// There are no comments for Property OrderDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> OrderDate
        {
            get
            {
                return this._OrderDate;
            }
            set
            {
                this.OnOrderDateChanging(value);
                this._OrderDate = value;
                this.OnOrderDateChanged();
                this.OnPropertyChanged("OrderDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _OrderDate;
        partial void OnOrderDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnOrderDateChanged();
        /// <summary>
        /// There are no comments for Property RequiredDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> RequiredDate
        {
            get
            {
                return this._RequiredDate;
            }
            set
            {
                this.OnRequiredDateChanging(value);
                this._RequiredDate = value;
                this.OnRequiredDateChanged();
                this.OnPropertyChanged("RequiredDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _RequiredDate;
        partial void OnRequiredDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnRequiredDateChanged();
        /// <summary>
        /// There are no comments for Property ShippedDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> ShippedDate
        {
            get
            {
                return this._ShippedDate;
            }
            set
            {
                this.OnShippedDateChanging(value);
                this._ShippedDate = value;
                this.OnShippedDateChanged();
                this.OnPropertyChanged("ShippedDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _ShippedDate;
        partial void OnShippedDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnShippedDateChanged();
        /// <summary>
        /// There are no comments for Property ShipVia in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> ShipVia
        {
            get
            {
                return this._ShipVia;
            }
            set
            {
                this.OnShipViaChanging(value);
                this._ShipVia = value;
                this.OnShipViaChanged();
                this.OnPropertyChanged("ShipVia");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _ShipVia;
        partial void OnShipViaChanging(global::System.Nullable<int> value);
        partial void OnShipViaChanged();
        /// <summary>
        /// There are no comments for Property Freight in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> Freight
        {
            get
            {
                return this._Freight;
            }
            set
            {
                this.OnFreightChanging(value);
                this._Freight = value;
                this.OnFreightChanged();
                this.OnPropertyChanged("Freight");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _Freight;
        partial void OnFreightChanging(global::System.Nullable<decimal> value);
        partial void OnFreightChanged();
        /// <summary>
        /// There are no comments for Property ShipName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipName
        {
            get
            {
                return this._ShipName;
            }
            set
            {
                this.OnShipNameChanging(value);
                this._ShipName = value;
                this.OnShipNameChanged();
                this.OnPropertyChanged("ShipName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipName;
        partial void OnShipNameChanging(string value);
        partial void OnShipNameChanged();
        /// <summary>
        /// There are no comments for Property ShipAddress in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipAddress
        {
            get
            {
                return this._ShipAddress;
            }
            set
            {
                this.OnShipAddressChanging(value);
                this._ShipAddress = value;
                this.OnShipAddressChanged();
                this.OnPropertyChanged("ShipAddress");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipAddress;
        partial void OnShipAddressChanging(string value);
        partial void OnShipAddressChanged();
        /// <summary>
        /// There are no comments for Property ShipCity in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipCity
        {
            get
            {
                return this._ShipCity;
            }
            set
            {
                this.OnShipCityChanging(value);
                this._ShipCity = value;
                this.OnShipCityChanged();
                this.OnPropertyChanged("ShipCity");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipCity;
        partial void OnShipCityChanging(string value);
        partial void OnShipCityChanged();
        /// <summary>
        /// There are no comments for Property ShipRegion in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipRegion
        {
            get
            {
                return this._ShipRegion;
            }
            set
            {
                this.OnShipRegionChanging(value);
                this._ShipRegion = value;
                this.OnShipRegionChanged();
                this.OnPropertyChanged("ShipRegion");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipRegion;
        partial void OnShipRegionChanging(string value);
        partial void OnShipRegionChanged();
        /// <summary>
        /// There are no comments for Property ShipPostalCode in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipPostalCode
        {
            get
            {
                return this._ShipPostalCode;
            }
            set
            {
                this.OnShipPostalCodeChanging(value);
                this._ShipPostalCode = value;
                this.OnShipPostalCodeChanged();
                this.OnPropertyChanged("ShipPostalCode");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipPostalCode;
        partial void OnShipPostalCodeChanging(string value);
        partial void OnShipPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property ShipCountry in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipCountry
        {
            get
            {
                return this._ShipCountry;
            }
            set
            {
                this.OnShipCountryChanging(value);
                this._ShipCountry = value;
                this.OnShipCountryChanged();
                this.OnPropertyChanged("ShipCountry");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipCountry;
        partial void OnShipCountryChanging(string value);
        partial void OnShipCountryChanged();
        /// <summary>
        /// There are no comments for Customer in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Customer Customer
        {
            get
            {
                return this._Customer;
            }
            set
            {
                this._Customer = value;
                this.OnPropertyChanged("Customer");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Customer _Customer;
        /// <summary>
        /// There are no comments for Employee in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Employee Employee
        {
            get
            {
                return this._Employee;
            }
            set
            {
                this._Employee = value;
                this.OnPropertyChanged("Employee");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Employee _Employee;
        /// <summary>
        /// There are no comments for Order_Details in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Order_Detail> Order_Details
        {
            get
            {
                return this._Order_Details;
            }
            set
            {
                this._Order_Details = value;
                this.OnPropertyChanged("Order_Details");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Order_Detail> _Order_Details = new global::System.Data.Services.Client.DataServiceCollection<Order_Detail>(null, System.Data.Services.Client.TrackingMode.None);
        /// <summary>
        /// There are no comments for Shipper in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Shipper Shipper
        {
            get
            {
                return this._Shipper;
            }
            set
            {
                this._Shipper = value;
                this.OnPropertyChanged("Shipper");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Shipper _Shipper;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Product in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ProductID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Products")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("ProductID")]
    public partial class Product : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Product object.
        /// </summary>
        /// <param name="productID">Initial value of ProductID.</param>
        /// <param name="productName">Initial value of ProductName.</param>
        /// <param name="discontinued">Initial value of Discontinued.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Product CreateProduct(int productID, string productName, bool discontinued)
        {
            Product product = new Product();
            product.ProductID = productID;
            product.ProductName = productName;
            product.Discontinued = discontinued;
            return product;
        }
        /// <summary>
        /// There are no comments for Property ProductID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this.OnProductIDChanging(value);
                this._ProductID = value;
                this.OnProductIDChanged();
                this.OnPropertyChanged("ProductID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _ProductID;
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
        /// <summary>
        /// There are no comments for Property ProductName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnProductNameChanging(value);
                this._ProductName = value;
                this.OnProductNameChanged();
                this.OnPropertyChanged("ProductName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProductName;
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
        /// <summary>
        /// There are no comments for Property SupplierID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> SupplierID
        {
            get
            {
                return this._SupplierID;
            }
            set
            {
                this.OnSupplierIDChanging(value);
                this._SupplierID = value;
                this.OnSupplierIDChanged();
                this.OnPropertyChanged("SupplierID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _SupplierID;
        partial void OnSupplierIDChanging(global::System.Nullable<int> value);
        partial void OnSupplierIDChanged();
        /// <summary>
        /// There are no comments for Property CategoryID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> CategoryID
        {
            get
            {
                return this._CategoryID;
            }
            set
            {
                this.OnCategoryIDChanging(value);
                this._CategoryID = value;
                this.OnCategoryIDChanged();
                this.OnPropertyChanged("CategoryID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _CategoryID;
        partial void OnCategoryIDChanging(global::System.Nullable<int> value);
        partial void OnCategoryIDChanged();
        /// <summary>
        /// There are no comments for Property QuantityPerUnit in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string QuantityPerUnit
        {
            get
            {
                return this._QuantityPerUnit;
            }
            set
            {
                this.OnQuantityPerUnitChanging(value);
                this._QuantityPerUnit = value;
                this.OnQuantityPerUnitChanged();
                this.OnPropertyChanged("QuantityPerUnit");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _QuantityPerUnit;
        partial void OnQuantityPerUnitChanging(string value);
        partial void OnQuantityPerUnitChanged();
        /// <summary>
        /// There are no comments for Property UnitPrice in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this.OnUnitPriceChanging(value);
                this._UnitPrice = value;
                this.OnUnitPriceChanged();
                this.OnPropertyChanged("UnitPrice");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _UnitPrice;
        partial void OnUnitPriceChanging(global::System.Nullable<decimal> value);
        partial void OnUnitPriceChanged();
        /// <summary>
        /// There are no comments for Property UnitsInStock in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<short> UnitsInStock
        {
            get
            {
                return this._UnitsInStock;
            }
            set
            {
                this.OnUnitsInStockChanging(value);
                this._UnitsInStock = value;
                this.OnUnitsInStockChanged();
                this.OnPropertyChanged("UnitsInStock");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<short> _UnitsInStock;
        partial void OnUnitsInStockChanging(global::System.Nullable<short> value);
        partial void OnUnitsInStockChanged();
        /// <summary>
        /// There are no comments for Property UnitsOnOrder in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<short> UnitsOnOrder
        {
            get
            {
                return this._UnitsOnOrder;
            }
            set
            {
                this.OnUnitsOnOrderChanging(value);
                this._UnitsOnOrder = value;
                this.OnUnitsOnOrderChanged();
                this.OnPropertyChanged("UnitsOnOrder");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<short> _UnitsOnOrder;
        partial void OnUnitsOnOrderChanging(global::System.Nullable<short> value);
        partial void OnUnitsOnOrderChanged();
        /// <summary>
        /// There are no comments for Property ReorderLevel in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<short> ReorderLevel
        {
            get
            {
                return this._ReorderLevel;
            }
            set
            {
                this.OnReorderLevelChanging(value);
                this._ReorderLevel = value;
                this.OnReorderLevelChanged();
                this.OnPropertyChanged("ReorderLevel");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<short> _ReorderLevel;
        partial void OnReorderLevelChanging(global::System.Nullable<short> value);
        partial void OnReorderLevelChanged();
        /// <summary>
        /// There are no comments for Property Discontinued in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool Discontinued
        {
            get
            {
                return this._Discontinued;
            }
            set
            {
                this.OnDiscontinuedChanging(value);
                this._Discontinued = value;
                this.OnDiscontinuedChanged();
                this.OnPropertyChanged("Discontinued");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _Discontinued;
        partial void OnDiscontinuedChanging(bool value);
        partial void OnDiscontinuedChanged();
        /// <summary>
        /// There are no comments for Category in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Category Category
        {
            get
            {
                return this._Category;
            }
            set
            {
                this._Category = value;
                this.OnPropertyChanged("Category");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Category _Category;
        /// <summary>
        /// There are no comments for Order_Details in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Order_Detail> Order_Details
        {
            get
            {
                return this._Order_Details;
            }
            set
            {
                this._Order_Details = value;
                this.OnPropertyChanged("Order_Details");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Order_Detail> _Order_Details = new global::System.Data.Services.Client.DataServiceCollection<Order_Detail>(null, System.Data.Services.Client.TrackingMode.None);
        /// <summary>
        /// There are no comments for Supplier in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Supplier Supplier
        {
            get
            {
                return this._Supplier;
            }
            set
            {
                this._Supplier = value;
                this.OnPropertyChanged("Supplier");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Supplier _Supplier;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Region in the schema.
    /// </summary>
    /// <KeyProperties>
    /// RegionID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Regions")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("RegionID")]
    public partial class Region : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Region object.
        /// </summary>
        /// <param name="regionID">Initial value of RegionID.</param>
        /// <param name="regionDescription">Initial value of RegionDescription.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Region CreateRegion(int regionID, string regionDescription)
        {
            Region region = new Region();
            region.RegionID = regionID;
            region.RegionDescription = regionDescription;
            return region;
        }
        /// <summary>
        /// There are no comments for Property RegionID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int RegionID
        {
            get
            {
                return this._RegionID;
            }
            set
            {
                this.OnRegionIDChanging(value);
                this._RegionID = value;
                this.OnRegionIDChanged();
                this.OnPropertyChanged("RegionID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _RegionID;
        partial void OnRegionIDChanging(int value);
        partial void OnRegionIDChanged();
        /// <summary>
        /// There are no comments for Property RegionDescription in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string RegionDescription
        {
            get
            {
                return this._RegionDescription;
            }
            set
            {
                this.OnRegionDescriptionChanging(value);
                this._RegionDescription = value;
                this.OnRegionDescriptionChanged();
                this.OnPropertyChanged("RegionDescription");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _RegionDescription;
        partial void OnRegionDescriptionChanging(string value);
        partial void OnRegionDescriptionChanged();
        /// <summary>
        /// There are no comments for Territories in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Territory> Territories
        {
            get
            {
                return this._Territories;
            }
            set
            {
                this._Territories = value;
                this.OnPropertyChanged("Territories");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Territory> _Territories = new global::System.Data.Services.Client.DataServiceCollection<Territory>(null, System.Data.Services.Client.TrackingMode.None);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Shipper in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ShipperID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Shippers")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("ShipperID")]
    public partial class Shipper : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Shipper object.
        /// </summary>
        /// <param name="shipperID">Initial value of ShipperID.</param>
        /// <param name="companyName">Initial value of CompanyName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Shipper CreateShipper(int shipperID, string companyName)
        {
            Shipper shipper = new Shipper();
            shipper.ShipperID = shipperID;
            shipper.CompanyName = companyName;
            return shipper;
        }
        /// <summary>
        /// There are no comments for Property ShipperID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int ShipperID
        {
            get
            {
                return this._ShipperID;
            }
            set
            {
                this.OnShipperIDChanging(value);
                this._ShipperID = value;
                this.OnShipperIDChanged();
                this.OnPropertyChanged("ShipperID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _ShipperID;
        partial void OnShipperIDChanging(int value);
        partial void OnShipperIDChanged();
        /// <summary>
        /// There are no comments for Property CompanyName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                this.OnCompanyNameChanging(value);
                this._CompanyName = value;
                this.OnCompanyNameChanged();
                this.OnPropertyChanged("CompanyName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CompanyName;
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
        /// <summary>
        /// There are no comments for Property Phone in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                this.OnPhoneChanging(value);
                this._Phone = value;
                this.OnPhoneChanged();
                this.OnPropertyChanged("Phone");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Phone;
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
        /// <summary>
        /// There are no comments for Orders in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Order> Orders
        {
            get
            {
                return this._Orders;
            }
            set
            {
                this._Orders = value;
                this.OnPropertyChanged("Orders");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Order> _Orders = new global::System.Data.Services.Client.DataServiceCollection<Order>(null, System.Data.Services.Client.TrackingMode.None);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Supplier in the schema.
    /// </summary>
    /// <KeyProperties>
    /// SupplierID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Suppliers")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("SupplierID")]
    public partial class Supplier : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Supplier object.
        /// </summary>
        /// <param name="supplierID">Initial value of SupplierID.</param>
        /// <param name="companyName">Initial value of CompanyName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Supplier CreateSupplier(int supplierID, string companyName)
        {
            Supplier supplier = new Supplier();
            supplier.SupplierID = supplierID;
            supplier.CompanyName = companyName;
            return supplier;
        }
        /// <summary>
        /// There are no comments for Property SupplierID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int SupplierID
        {
            get
            {
                return this._SupplierID;
            }
            set
            {
                this.OnSupplierIDChanging(value);
                this._SupplierID = value;
                this.OnSupplierIDChanged();
                this.OnPropertyChanged("SupplierID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _SupplierID;
        partial void OnSupplierIDChanging(int value);
        partial void OnSupplierIDChanged();
        /// <summary>
        /// There are no comments for Property CompanyName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                this.OnCompanyNameChanging(value);
                this._CompanyName = value;
                this.OnCompanyNameChanged();
                this.OnPropertyChanged("CompanyName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CompanyName;
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
        /// <summary>
        /// There are no comments for Property ContactName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ContactName
        {
            get
            {
                return this._ContactName;
            }
            set
            {
                this.OnContactNameChanging(value);
                this._ContactName = value;
                this.OnContactNameChanged();
                this.OnPropertyChanged("ContactName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ContactName;
        partial void OnContactNameChanging(string value);
        partial void OnContactNameChanged();
        /// <summary>
        /// There are no comments for Property ContactTitle in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ContactTitle
        {
            get
            {
                return this._ContactTitle;
            }
            set
            {
                this.OnContactTitleChanging(value);
                this._ContactTitle = value;
                this.OnContactTitleChanged();
                this.OnPropertyChanged("ContactTitle");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ContactTitle;
        partial void OnContactTitleChanging(string value);
        partial void OnContactTitleChanged();
        /// <summary>
        /// There are no comments for Property Address in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this.OnAddressChanging(value);
                this._Address = value;
                this.OnAddressChanged();
                this.OnPropertyChanged("Address");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Address;
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        /// <summary>
        /// There are no comments for Property City in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnCityChanging(value);
                this._City = value;
                this.OnCityChanged();
                this.OnPropertyChanged("City");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _City;
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        /// <summary>
        /// There are no comments for Property Region in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Region
        {
            get
            {
                return this._Region;
            }
            set
            {
                this.OnRegionChanging(value);
                this._Region = value;
                this.OnRegionChanged();
                this.OnPropertyChanged("Region");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Region;
        partial void OnRegionChanging(string value);
        partial void OnRegionChanged();
        /// <summary>
        /// There are no comments for Property PostalCode in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PostalCode
        {
            get
            {
                return this._PostalCode;
            }
            set
            {
                this.OnPostalCodeChanging(value);
                this._PostalCode = value;
                this.OnPostalCodeChanged();
                this.OnPropertyChanged("PostalCode");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PostalCode;
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property Country in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Country
        {
            get
            {
                return this._Country;
            }
            set
            {
                this.OnCountryChanging(value);
                this._Country = value;
                this.OnCountryChanged();
                this.OnPropertyChanged("Country");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Country;
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
        /// <summary>
        /// There are no comments for Property Phone in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                this.OnPhoneChanging(value);
                this._Phone = value;
                this.OnPhoneChanged();
                this.OnPropertyChanged("Phone");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Phone;
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
        /// <summary>
        /// There are no comments for Property Fax in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                this.OnFaxChanging(value);
                this._Fax = value;
                this.OnFaxChanged();
                this.OnPropertyChanged("Fax");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Fax;
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
        /// <summary>
        /// There are no comments for Property HomePage in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string HomePage
        {
            get
            {
                return this._HomePage;
            }
            set
            {
                this.OnHomePageChanging(value);
                this._HomePage = value;
                this.OnHomePageChanged();
                this.OnPropertyChanged("HomePage");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _HomePage;
        partial void OnHomePageChanging(string value);
        partial void OnHomePageChanged();
        /// <summary>
        /// There are no comments for Products in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Product> Products
        {
            get
            {
                return this._Products;
            }
            set
            {
                this._Products = value;
                this.OnPropertyChanged("Products");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Product> _Products = new global::System.Data.Services.Client.DataServiceCollection<Product>(null, System.Data.Services.Client.TrackingMode.None);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Territory in the schema.
    /// </summary>
    /// <KeyProperties>
    /// TerritoryID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Territories")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("TerritoryID")]
    public partial class Territory : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Territory object.
        /// </summary>
        /// <param name="territoryID">Initial value of TerritoryID.</param>
        /// <param name="territoryDescription">Initial value of TerritoryDescription.</param>
        /// <param name="regionID">Initial value of RegionID.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Territory CreateTerritory(string territoryID, string territoryDescription, int regionID)
        {
            Territory territory = new Territory();
            territory.TerritoryID = territoryID;
            territory.TerritoryDescription = territoryDescription;
            territory.RegionID = regionID;
            return territory;
        }
        /// <summary>
        /// There are no comments for Property TerritoryID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string TerritoryID
        {
            get
            {
                return this._TerritoryID;
            }
            set
            {
                this.OnTerritoryIDChanging(value);
                this._TerritoryID = value;
                this.OnTerritoryIDChanged();
                this.OnPropertyChanged("TerritoryID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _TerritoryID;
        partial void OnTerritoryIDChanging(string value);
        partial void OnTerritoryIDChanged();
        /// <summary>
        /// There are no comments for Property TerritoryDescription in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string TerritoryDescription
        {
            get
            {
                return this._TerritoryDescription;
            }
            set
            {
                this.OnTerritoryDescriptionChanging(value);
                this._TerritoryDescription = value;
                this.OnTerritoryDescriptionChanged();
                this.OnPropertyChanged("TerritoryDescription");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _TerritoryDescription;
        partial void OnTerritoryDescriptionChanging(string value);
        partial void OnTerritoryDescriptionChanged();
        /// <summary>
        /// There are no comments for Property RegionID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int RegionID
        {
            get
            {
                return this._RegionID;
            }
            set
            {
                this.OnRegionIDChanging(value);
                this._RegionID = value;
                this.OnRegionIDChanged();
                this.OnPropertyChanged("RegionID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _RegionID;
        partial void OnRegionIDChanging(int value);
        partial void OnRegionIDChanged();
        /// <summary>
        /// There are no comments for Region in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Region Region
        {
            get
            {
                return this._Region;
            }
            set
            {
                this._Region = value;
                this.OnPropertyChanged("Region");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Region _Region;
        /// <summary>
        /// There are no comments for Employees in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceCollection<Employee> Employees
        {
            get
            {
                return this._Employees;
            }
            set
            {
                this._Employees = value;
                this.OnPropertyChanged("Employees");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceCollection<Employee> _Employees = new global::System.Data.Services.Client.DataServiceCollection<Employee>(null, System.Data.Services.Client.TrackingMode.None);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Alphabetical_list_of_product in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ProductID
    /// ProductName
    /// Discontinued
    /// CategoryName
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Alphabetical_list_of_products")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("ProductID", "ProductName", "Discontinued", "CategoryName")]
    public partial class Alphabetical_list_of_product : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Alphabetical_list_of_product object.
        /// </summary>
        /// <param name="productID">Initial value of ProductID.</param>
        /// <param name="productName">Initial value of ProductName.</param>
        /// <param name="discontinued">Initial value of Discontinued.</param>
        /// <param name="categoryName">Initial value of CategoryName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Alphabetical_list_of_product CreateAlphabetical_list_of_product(int productID, string productName, bool discontinued, string categoryName)
        {
            Alphabetical_list_of_product alphabetical_list_of_product = new Alphabetical_list_of_product();
            alphabetical_list_of_product.ProductID = productID;
            alphabetical_list_of_product.ProductName = productName;
            alphabetical_list_of_product.Discontinued = discontinued;
            alphabetical_list_of_product.CategoryName = categoryName;
            return alphabetical_list_of_product;
        }
        /// <summary>
        /// There are no comments for Property ProductID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this.OnProductIDChanging(value);
                this._ProductID = value;
                this.OnProductIDChanged();
                this.OnPropertyChanged("ProductID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _ProductID;
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
        /// <summary>
        /// There are no comments for Property ProductName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnProductNameChanging(value);
                this._ProductName = value;
                this.OnProductNameChanged();
                this.OnPropertyChanged("ProductName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProductName;
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
        /// <summary>
        /// There are no comments for Property SupplierID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> SupplierID
        {
            get
            {
                return this._SupplierID;
            }
            set
            {
                this.OnSupplierIDChanging(value);
                this._SupplierID = value;
                this.OnSupplierIDChanged();
                this.OnPropertyChanged("SupplierID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _SupplierID;
        partial void OnSupplierIDChanging(global::System.Nullable<int> value);
        partial void OnSupplierIDChanged();
        /// <summary>
        /// There are no comments for Property CategoryID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> CategoryID
        {
            get
            {
                return this._CategoryID;
            }
            set
            {
                this.OnCategoryIDChanging(value);
                this._CategoryID = value;
                this.OnCategoryIDChanged();
                this.OnPropertyChanged("CategoryID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _CategoryID;
        partial void OnCategoryIDChanging(global::System.Nullable<int> value);
        partial void OnCategoryIDChanged();
        /// <summary>
        /// There are no comments for Property QuantityPerUnit in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string QuantityPerUnit
        {
            get
            {
                return this._QuantityPerUnit;
            }
            set
            {
                this.OnQuantityPerUnitChanging(value);
                this._QuantityPerUnit = value;
                this.OnQuantityPerUnitChanged();
                this.OnPropertyChanged("QuantityPerUnit");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _QuantityPerUnit;
        partial void OnQuantityPerUnitChanging(string value);
        partial void OnQuantityPerUnitChanged();
        /// <summary>
        /// There are no comments for Property UnitPrice in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this.OnUnitPriceChanging(value);
                this._UnitPrice = value;
                this.OnUnitPriceChanged();
                this.OnPropertyChanged("UnitPrice");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _UnitPrice;
        partial void OnUnitPriceChanging(global::System.Nullable<decimal> value);
        partial void OnUnitPriceChanged();
        /// <summary>
        /// There are no comments for Property UnitsInStock in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<short> UnitsInStock
        {
            get
            {
                return this._UnitsInStock;
            }
            set
            {
                this.OnUnitsInStockChanging(value);
                this._UnitsInStock = value;
                this.OnUnitsInStockChanged();
                this.OnPropertyChanged("UnitsInStock");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<short> _UnitsInStock;
        partial void OnUnitsInStockChanging(global::System.Nullable<short> value);
        partial void OnUnitsInStockChanged();
        /// <summary>
        /// There are no comments for Property UnitsOnOrder in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<short> UnitsOnOrder
        {
            get
            {
                return this._UnitsOnOrder;
            }
            set
            {
                this.OnUnitsOnOrderChanging(value);
                this._UnitsOnOrder = value;
                this.OnUnitsOnOrderChanged();
                this.OnPropertyChanged("UnitsOnOrder");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<short> _UnitsOnOrder;
        partial void OnUnitsOnOrderChanging(global::System.Nullable<short> value);
        partial void OnUnitsOnOrderChanged();
        /// <summary>
        /// There are no comments for Property ReorderLevel in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<short> ReorderLevel
        {
            get
            {
                return this._ReorderLevel;
            }
            set
            {
                this.OnReorderLevelChanging(value);
                this._ReorderLevel = value;
                this.OnReorderLevelChanged();
                this.OnPropertyChanged("ReorderLevel");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<short> _ReorderLevel;
        partial void OnReorderLevelChanging(global::System.Nullable<short> value);
        partial void OnReorderLevelChanged();
        /// <summary>
        /// There are no comments for Property Discontinued in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool Discontinued
        {
            get
            {
                return this._Discontinued;
            }
            set
            {
                this.OnDiscontinuedChanging(value);
                this._Discontinued = value;
                this.OnDiscontinuedChanged();
                this.OnPropertyChanged("Discontinued");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _Discontinued;
        partial void OnDiscontinuedChanging(bool value);
        partial void OnDiscontinuedChanged();
        /// <summary>
        /// There are no comments for Property CategoryName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                this.OnCategoryNameChanging(value);
                this._CategoryName = value;
                this.OnCategoryNameChanged();
                this.OnPropertyChanged("CategoryName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CategoryName;
        partial void OnCategoryNameChanging(string value);
        partial void OnCategoryNameChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Category_Sales_for_1997 in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CategoryName
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Category_Sales_for_1997")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CategoryName")]
    public partial class Category_Sales_for_1997 : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Category_Sales_for_1997 object.
        /// </summary>
        /// <param name="categoryName">Initial value of CategoryName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Category_Sales_for_1997 CreateCategory_Sales_for_1997(string categoryName)
        {
            Category_Sales_for_1997 category_Sales_for_1997 = new Category_Sales_for_1997();
            category_Sales_for_1997.CategoryName = categoryName;
            return category_Sales_for_1997;
        }
        /// <summary>
        /// There are no comments for Property CategoryName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                this.OnCategoryNameChanging(value);
                this._CategoryName = value;
                this.OnCategoryNameChanged();
                this.OnPropertyChanged("CategoryName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CategoryName;
        partial void OnCategoryNameChanging(string value);
        partial void OnCategoryNameChanged();
        /// <summary>
        /// There are no comments for Property CategorySales in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> CategorySales
        {
            get
            {
                return this._CategorySales;
            }
            set
            {
                this.OnCategorySalesChanging(value);
                this._CategorySales = value;
                this.OnCategorySalesChanged();
                this.OnPropertyChanged("CategorySales");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _CategorySales;
        partial void OnCategorySalesChanging(global::System.Nullable<decimal> value);
        partial void OnCategorySalesChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Current_Product_List in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ProductID
    /// ProductName
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Current_Product_Lists")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("ProductID", "ProductName")]
    public partial class Current_Product_List : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Current_Product_List object.
        /// </summary>
        /// <param name="productID">Initial value of ProductID.</param>
        /// <param name="productName">Initial value of ProductName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Current_Product_List CreateCurrent_Product_List(int productID, string productName)
        {
            Current_Product_List current_Product_List = new Current_Product_List();
            current_Product_List.ProductID = productID;
            current_Product_List.ProductName = productName;
            return current_Product_List;
        }
        /// <summary>
        /// There are no comments for Property ProductID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this.OnProductIDChanging(value);
                this._ProductID = value;
                this.OnProductIDChanged();
                this.OnPropertyChanged("ProductID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _ProductID;
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
        /// <summary>
        /// There are no comments for Property ProductName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnProductNameChanging(value);
                this._ProductName = value;
                this.OnProductNameChanged();
                this.OnPropertyChanged("ProductName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProductName;
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Customer_and_Suppliers_by_City in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CompanyName
    /// Relationship
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Customer_and_Suppliers_by_Cities")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CompanyName", "Relationship")]
    public partial class Customer_and_Suppliers_by_City : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Customer_and_Suppliers_by_City object.
        /// </summary>
        /// <param name="companyName">Initial value of CompanyName.</param>
        /// <param name="relationship">Initial value of Relationship.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Customer_and_Suppliers_by_City CreateCustomer_and_Suppliers_by_City(string companyName, string relationship)
        {
            Customer_and_Suppliers_by_City customer_and_Suppliers_by_City = new Customer_and_Suppliers_by_City();
            customer_and_Suppliers_by_City.CompanyName = companyName;
            customer_and_Suppliers_by_City.Relationship = relationship;
            return customer_and_Suppliers_by_City;
        }
        /// <summary>
        /// There are no comments for Property City in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnCityChanging(value);
                this._City = value;
                this.OnCityChanged();
                this.OnPropertyChanged("City");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _City;
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        /// <summary>
        /// There are no comments for Property CompanyName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                this.OnCompanyNameChanging(value);
                this._CompanyName = value;
                this.OnCompanyNameChanged();
                this.OnPropertyChanged("CompanyName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CompanyName;
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
        /// <summary>
        /// There are no comments for Property ContactName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ContactName
        {
            get
            {
                return this._ContactName;
            }
            set
            {
                this.OnContactNameChanging(value);
                this._ContactName = value;
                this.OnContactNameChanged();
                this.OnPropertyChanged("ContactName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ContactName;
        partial void OnContactNameChanging(string value);
        partial void OnContactNameChanged();
        /// <summary>
        /// There are no comments for Property Relationship in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Relationship
        {
            get
            {
                return this._Relationship;
            }
            set
            {
                this.OnRelationshipChanging(value);
                this._Relationship = value;
                this.OnRelationshipChanged();
                this.OnPropertyChanged("Relationship");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Relationship;
        partial void OnRelationshipChanging(string value);
        partial void OnRelationshipChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Invoice in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CustomerName
    /// Salesperson
    /// OrderID
    /// ShipperName
    /// ProductID
    /// ProductName
    /// UnitPrice
    /// Quantity
    /// Discount
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Invoices")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CustomerName", "Salesperson", "OrderID", "ShipperName", "ProductID", "ProductName", "UnitPrice", "Quantity", "Discount")]
    public partial class Invoice : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Invoice object.
        /// </summary>
        /// <param name="customerName">Initial value of CustomerName.</param>
        /// <param name="salesperson">Initial value of Salesperson.</param>
        /// <param name="orderID">Initial value of OrderID.</param>
        /// <param name="shipperName">Initial value of ShipperName.</param>
        /// <param name="productID">Initial value of ProductID.</param>
        /// <param name="productName">Initial value of ProductName.</param>
        /// <param name="unitPrice">Initial value of UnitPrice.</param>
        /// <param name="quantity">Initial value of Quantity.</param>
        /// <param name="discount">Initial value of Discount.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Invoice CreateInvoice(string customerName, string salesperson, int orderID, string shipperName, int productID, string productName, decimal unitPrice, short quantity, float discount)
        {
            Invoice invoice = new Invoice();
            invoice.CustomerName = customerName;
            invoice.Salesperson = salesperson;
            invoice.OrderID = orderID;
            invoice.ShipperName = shipperName;
            invoice.ProductID = productID;
            invoice.ProductName = productName;
            invoice.UnitPrice = unitPrice;
            invoice.Quantity = quantity;
            invoice.Discount = discount;
            return invoice;
        }
        /// <summary>
        /// There are no comments for Property ShipName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipName
        {
            get
            {
                return this._ShipName;
            }
            set
            {
                this.OnShipNameChanging(value);
                this._ShipName = value;
                this.OnShipNameChanged();
                this.OnPropertyChanged("ShipName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipName;
        partial void OnShipNameChanging(string value);
        partial void OnShipNameChanged();
        /// <summary>
        /// There are no comments for Property ShipAddress in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipAddress
        {
            get
            {
                return this._ShipAddress;
            }
            set
            {
                this.OnShipAddressChanging(value);
                this._ShipAddress = value;
                this.OnShipAddressChanged();
                this.OnPropertyChanged("ShipAddress");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipAddress;
        partial void OnShipAddressChanging(string value);
        partial void OnShipAddressChanged();
        /// <summary>
        /// There are no comments for Property ShipCity in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipCity
        {
            get
            {
                return this._ShipCity;
            }
            set
            {
                this.OnShipCityChanging(value);
                this._ShipCity = value;
                this.OnShipCityChanged();
                this.OnPropertyChanged("ShipCity");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipCity;
        partial void OnShipCityChanging(string value);
        partial void OnShipCityChanged();
        /// <summary>
        /// There are no comments for Property ShipRegion in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipRegion
        {
            get
            {
                return this._ShipRegion;
            }
            set
            {
                this.OnShipRegionChanging(value);
                this._ShipRegion = value;
                this.OnShipRegionChanged();
                this.OnPropertyChanged("ShipRegion");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipRegion;
        partial void OnShipRegionChanging(string value);
        partial void OnShipRegionChanged();
        /// <summary>
        /// There are no comments for Property ShipPostalCode in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipPostalCode
        {
            get
            {
                return this._ShipPostalCode;
            }
            set
            {
                this.OnShipPostalCodeChanging(value);
                this._ShipPostalCode = value;
                this.OnShipPostalCodeChanged();
                this.OnPropertyChanged("ShipPostalCode");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipPostalCode;
        partial void OnShipPostalCodeChanging(string value);
        partial void OnShipPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property ShipCountry in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipCountry
        {
            get
            {
                return this._ShipCountry;
            }
            set
            {
                this.OnShipCountryChanging(value);
                this._ShipCountry = value;
                this.OnShipCountryChanged();
                this.OnPropertyChanged("ShipCountry");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipCountry;
        partial void OnShipCountryChanging(string value);
        partial void OnShipCountryChanged();
        /// <summary>
        /// There are no comments for Property CustomerID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this.OnCustomerIDChanging(value);
                this._CustomerID = value;
                this.OnCustomerIDChanged();
                this.OnPropertyChanged("CustomerID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CustomerID;
        partial void OnCustomerIDChanging(string value);
        partial void OnCustomerIDChanged();
        /// <summary>
        /// There are no comments for Property CustomerName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CustomerName
        {
            get
            {
                return this._CustomerName;
            }
            set
            {
                this.OnCustomerNameChanging(value);
                this._CustomerName = value;
                this.OnCustomerNameChanged();
                this.OnPropertyChanged("CustomerName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CustomerName;
        partial void OnCustomerNameChanging(string value);
        partial void OnCustomerNameChanged();
        /// <summary>
        /// There are no comments for Property Address in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this.OnAddressChanging(value);
                this._Address = value;
                this.OnAddressChanged();
                this.OnPropertyChanged("Address");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Address;
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        /// <summary>
        /// There are no comments for Property City in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnCityChanging(value);
                this._City = value;
                this.OnCityChanged();
                this.OnPropertyChanged("City");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _City;
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        /// <summary>
        /// There are no comments for Property Region in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Region
        {
            get
            {
                return this._Region;
            }
            set
            {
                this.OnRegionChanging(value);
                this._Region = value;
                this.OnRegionChanged();
                this.OnPropertyChanged("Region");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Region;
        partial void OnRegionChanging(string value);
        partial void OnRegionChanged();
        /// <summary>
        /// There are no comments for Property PostalCode in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PostalCode
        {
            get
            {
                return this._PostalCode;
            }
            set
            {
                this.OnPostalCodeChanging(value);
                this._PostalCode = value;
                this.OnPostalCodeChanged();
                this.OnPropertyChanged("PostalCode");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PostalCode;
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property Country in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Country
        {
            get
            {
                return this._Country;
            }
            set
            {
                this.OnCountryChanging(value);
                this._Country = value;
                this.OnCountryChanged();
                this.OnPropertyChanged("Country");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Country;
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
        /// <summary>
        /// There are no comments for Property Salesperson in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Salesperson
        {
            get
            {
                return this._Salesperson;
            }
            set
            {
                this.OnSalespersonChanging(value);
                this._Salesperson = value;
                this.OnSalespersonChanged();
                this.OnPropertyChanged("Salesperson");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Salesperson;
        partial void OnSalespersonChanging(string value);
        partial void OnSalespersonChanged();
        /// <summary>
        /// There are no comments for Property OrderID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnOrderIDChanging(value);
                this._OrderID = value;
                this.OnOrderIDChanged();
                this.OnPropertyChanged("OrderID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderID;
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        /// <summary>
        /// There are no comments for Property OrderDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> OrderDate
        {
            get
            {
                return this._OrderDate;
            }
            set
            {
                this.OnOrderDateChanging(value);
                this._OrderDate = value;
                this.OnOrderDateChanged();
                this.OnPropertyChanged("OrderDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _OrderDate;
        partial void OnOrderDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnOrderDateChanged();
        /// <summary>
        /// There are no comments for Property RequiredDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> RequiredDate
        {
            get
            {
                return this._RequiredDate;
            }
            set
            {
                this.OnRequiredDateChanging(value);
                this._RequiredDate = value;
                this.OnRequiredDateChanged();
                this.OnPropertyChanged("RequiredDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _RequiredDate;
        partial void OnRequiredDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnRequiredDateChanged();
        /// <summary>
        /// There are no comments for Property ShippedDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> ShippedDate
        {
            get
            {
                return this._ShippedDate;
            }
            set
            {
                this.OnShippedDateChanging(value);
                this._ShippedDate = value;
                this.OnShippedDateChanged();
                this.OnPropertyChanged("ShippedDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _ShippedDate;
        partial void OnShippedDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnShippedDateChanged();
        /// <summary>
        /// There are no comments for Property ShipperName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipperName
        {
            get
            {
                return this._ShipperName;
            }
            set
            {
                this.OnShipperNameChanging(value);
                this._ShipperName = value;
                this.OnShipperNameChanged();
                this.OnPropertyChanged("ShipperName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipperName;
        partial void OnShipperNameChanging(string value);
        partial void OnShipperNameChanged();
        /// <summary>
        /// There are no comments for Property ProductID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this.OnProductIDChanging(value);
                this._ProductID = value;
                this.OnProductIDChanged();
                this.OnPropertyChanged("ProductID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _ProductID;
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
        /// <summary>
        /// There are no comments for Property ProductName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnProductNameChanging(value);
                this._ProductName = value;
                this.OnProductNameChanged();
                this.OnPropertyChanged("ProductName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProductName;
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
        /// <summary>
        /// There are no comments for Property UnitPrice in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public decimal UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this.OnUnitPriceChanging(value);
                this._UnitPrice = value;
                this.OnUnitPriceChanged();
                this.OnPropertyChanged("UnitPrice");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private decimal _UnitPrice;
        partial void OnUnitPriceChanging(decimal value);
        partial void OnUnitPriceChanged();
        /// <summary>
        /// There are no comments for Property Quantity in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public short Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this.OnQuantityChanging(value);
                this._Quantity = value;
                this.OnQuantityChanged();
                this.OnPropertyChanged("Quantity");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private short _Quantity;
        partial void OnQuantityChanging(short value);
        partial void OnQuantityChanged();
        /// <summary>
        /// There are no comments for Property Discount in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public float Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this.OnDiscountChanging(value);
                this._Discount = value;
                this.OnDiscountChanged();
                this.OnPropertyChanged("Discount");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private float _Discount;
        partial void OnDiscountChanging(float value);
        partial void OnDiscountChanged();
        /// <summary>
        /// There are no comments for Property ExtendedPrice in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> ExtendedPrice
        {
            get
            {
                return this._ExtendedPrice;
            }
            set
            {
                this.OnExtendedPriceChanging(value);
                this._ExtendedPrice = value;
                this.OnExtendedPriceChanged();
                this.OnPropertyChanged("ExtendedPrice");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _ExtendedPrice;
        partial void OnExtendedPriceChanging(global::System.Nullable<decimal> value);
        partial void OnExtendedPriceChanged();
        /// <summary>
        /// There are no comments for Property Freight in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> Freight
        {
            get
            {
                return this._Freight;
            }
            set
            {
                this.OnFreightChanging(value);
                this._Freight = value;
                this.OnFreightChanged();
                this.OnPropertyChanged("Freight");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _Freight;
        partial void OnFreightChanging(global::System.Nullable<decimal> value);
        partial void OnFreightChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Order_Details_Extended in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderID
    /// ProductID
    /// ProductName
    /// UnitPrice
    /// Quantity
    /// Discount
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Order_Details_Extendeds")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("OrderID", "ProductID", "ProductName", "UnitPrice", "Quantity", "Discount")]
    public partial class Order_Details_Extended : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Order_Details_Extended object.
        /// </summary>
        /// <param name="orderID">Initial value of OrderID.</param>
        /// <param name="productID">Initial value of ProductID.</param>
        /// <param name="productName">Initial value of ProductName.</param>
        /// <param name="unitPrice">Initial value of UnitPrice.</param>
        /// <param name="quantity">Initial value of Quantity.</param>
        /// <param name="discount">Initial value of Discount.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Order_Details_Extended CreateOrder_Details_Extended(int orderID, int productID, string productName, decimal unitPrice, short quantity, float discount)
        {
            Order_Details_Extended order_Details_Extended = new Order_Details_Extended();
            order_Details_Extended.OrderID = orderID;
            order_Details_Extended.ProductID = productID;
            order_Details_Extended.ProductName = productName;
            order_Details_Extended.UnitPrice = unitPrice;
            order_Details_Extended.Quantity = quantity;
            order_Details_Extended.Discount = discount;
            return order_Details_Extended;
        }
        /// <summary>
        /// There are no comments for Property OrderID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnOrderIDChanging(value);
                this._OrderID = value;
                this.OnOrderIDChanged();
                this.OnPropertyChanged("OrderID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderID;
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        /// <summary>
        /// There are no comments for Property ProductID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this.OnProductIDChanging(value);
                this._ProductID = value;
                this.OnProductIDChanged();
                this.OnPropertyChanged("ProductID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _ProductID;
        partial void OnProductIDChanging(int value);
        partial void OnProductIDChanged();
        /// <summary>
        /// There are no comments for Property ProductName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnProductNameChanging(value);
                this._ProductName = value;
                this.OnProductNameChanged();
                this.OnPropertyChanged("ProductName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProductName;
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
        /// <summary>
        /// There are no comments for Property UnitPrice in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public decimal UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this.OnUnitPriceChanging(value);
                this._UnitPrice = value;
                this.OnUnitPriceChanged();
                this.OnPropertyChanged("UnitPrice");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private decimal _UnitPrice;
        partial void OnUnitPriceChanging(decimal value);
        partial void OnUnitPriceChanged();
        /// <summary>
        /// There are no comments for Property Quantity in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public short Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this.OnQuantityChanging(value);
                this._Quantity = value;
                this.OnQuantityChanged();
                this.OnPropertyChanged("Quantity");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private short _Quantity;
        partial void OnQuantityChanging(short value);
        partial void OnQuantityChanged();
        /// <summary>
        /// There are no comments for Property Discount in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public float Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this.OnDiscountChanging(value);
                this._Discount = value;
                this.OnDiscountChanged();
                this.OnPropertyChanged("Discount");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private float _Discount;
        partial void OnDiscountChanging(float value);
        partial void OnDiscountChanged();
        /// <summary>
        /// There are no comments for Property ExtendedPrice in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> ExtendedPrice
        {
            get
            {
                return this._ExtendedPrice;
            }
            set
            {
                this.OnExtendedPriceChanging(value);
                this._ExtendedPrice = value;
                this.OnExtendedPriceChanged();
                this.OnPropertyChanged("ExtendedPrice");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _ExtendedPrice;
        partial void OnExtendedPriceChanging(global::System.Nullable<decimal> value);
        partial void OnExtendedPriceChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Order_Subtotal in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Order_Subtotals")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("OrderID")]
    public partial class Order_Subtotal : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Order_Subtotal object.
        /// </summary>
        /// <param name="orderID">Initial value of OrderID.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Order_Subtotal CreateOrder_Subtotal(int orderID)
        {
            Order_Subtotal order_Subtotal = new Order_Subtotal();
            order_Subtotal.OrderID = orderID;
            return order_Subtotal;
        }
        /// <summary>
        /// There are no comments for Property OrderID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnOrderIDChanging(value);
                this._OrderID = value;
                this.OnOrderIDChanged();
                this.OnPropertyChanged("OrderID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderID;
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        /// <summary>
        /// There are no comments for Property Subtotal in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> Subtotal
        {
            get
            {
                return this._Subtotal;
            }
            set
            {
                this.OnSubtotalChanging(value);
                this._Subtotal = value;
                this.OnSubtotalChanged();
                this.OnPropertyChanged("Subtotal");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _Subtotal;
        partial void OnSubtotalChanging(global::System.Nullable<decimal> value);
        partial void OnSubtotalChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Orders_Qry in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderID
    /// CompanyName
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Orders_Qries")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("OrderID", "CompanyName")]
    public partial class Orders_Qry : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Orders_Qry object.
        /// </summary>
        /// <param name="orderID">Initial value of OrderID.</param>
        /// <param name="companyName">Initial value of CompanyName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Orders_Qry CreateOrders_Qry(int orderID, string companyName)
        {
            Orders_Qry orders_Qry = new Orders_Qry();
            orders_Qry.OrderID = orderID;
            orders_Qry.CompanyName = companyName;
            return orders_Qry;
        }
        /// <summary>
        /// There are no comments for Property OrderID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnOrderIDChanging(value);
                this._OrderID = value;
                this.OnOrderIDChanged();
                this.OnPropertyChanged("OrderID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderID;
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        /// <summary>
        /// There are no comments for Property CustomerID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this.OnCustomerIDChanging(value);
                this._CustomerID = value;
                this.OnCustomerIDChanged();
                this.OnPropertyChanged("CustomerID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CustomerID;
        partial void OnCustomerIDChanging(string value);
        partial void OnCustomerIDChanged();
        /// <summary>
        /// There are no comments for Property EmployeeID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                this.OnEmployeeIDChanging(value);
                this._EmployeeID = value;
                this.OnEmployeeIDChanged();
                this.OnPropertyChanged("EmployeeID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _EmployeeID;
        partial void OnEmployeeIDChanging(global::System.Nullable<int> value);
        partial void OnEmployeeIDChanged();
        /// <summary>
        /// There are no comments for Property OrderDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> OrderDate
        {
            get
            {
                return this._OrderDate;
            }
            set
            {
                this.OnOrderDateChanging(value);
                this._OrderDate = value;
                this.OnOrderDateChanged();
                this.OnPropertyChanged("OrderDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _OrderDate;
        partial void OnOrderDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnOrderDateChanged();
        /// <summary>
        /// There are no comments for Property RequiredDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> RequiredDate
        {
            get
            {
                return this._RequiredDate;
            }
            set
            {
                this.OnRequiredDateChanging(value);
                this._RequiredDate = value;
                this.OnRequiredDateChanged();
                this.OnPropertyChanged("RequiredDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _RequiredDate;
        partial void OnRequiredDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnRequiredDateChanged();
        /// <summary>
        /// There are no comments for Property ShippedDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> ShippedDate
        {
            get
            {
                return this._ShippedDate;
            }
            set
            {
                this.OnShippedDateChanging(value);
                this._ShippedDate = value;
                this.OnShippedDateChanged();
                this.OnPropertyChanged("ShippedDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _ShippedDate;
        partial void OnShippedDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnShippedDateChanged();
        /// <summary>
        /// There are no comments for Property ShipVia in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> ShipVia
        {
            get
            {
                return this._ShipVia;
            }
            set
            {
                this.OnShipViaChanging(value);
                this._ShipVia = value;
                this.OnShipViaChanged();
                this.OnPropertyChanged("ShipVia");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _ShipVia;
        partial void OnShipViaChanging(global::System.Nullable<int> value);
        partial void OnShipViaChanged();
        /// <summary>
        /// There are no comments for Property Freight in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> Freight
        {
            get
            {
                return this._Freight;
            }
            set
            {
                this.OnFreightChanging(value);
                this._Freight = value;
                this.OnFreightChanged();
                this.OnPropertyChanged("Freight");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _Freight;
        partial void OnFreightChanging(global::System.Nullable<decimal> value);
        partial void OnFreightChanged();
        /// <summary>
        /// There are no comments for Property ShipName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipName
        {
            get
            {
                return this._ShipName;
            }
            set
            {
                this.OnShipNameChanging(value);
                this._ShipName = value;
                this.OnShipNameChanged();
                this.OnPropertyChanged("ShipName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipName;
        partial void OnShipNameChanging(string value);
        partial void OnShipNameChanged();
        /// <summary>
        /// There are no comments for Property ShipAddress in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipAddress
        {
            get
            {
                return this._ShipAddress;
            }
            set
            {
                this.OnShipAddressChanging(value);
                this._ShipAddress = value;
                this.OnShipAddressChanged();
                this.OnPropertyChanged("ShipAddress");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipAddress;
        partial void OnShipAddressChanging(string value);
        partial void OnShipAddressChanged();
        /// <summary>
        /// There are no comments for Property ShipCity in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipCity
        {
            get
            {
                return this._ShipCity;
            }
            set
            {
                this.OnShipCityChanging(value);
                this._ShipCity = value;
                this.OnShipCityChanged();
                this.OnPropertyChanged("ShipCity");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipCity;
        partial void OnShipCityChanging(string value);
        partial void OnShipCityChanged();
        /// <summary>
        /// There are no comments for Property ShipRegion in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipRegion
        {
            get
            {
                return this._ShipRegion;
            }
            set
            {
                this.OnShipRegionChanging(value);
                this._ShipRegion = value;
                this.OnShipRegionChanged();
                this.OnPropertyChanged("ShipRegion");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipRegion;
        partial void OnShipRegionChanging(string value);
        partial void OnShipRegionChanged();
        /// <summary>
        /// There are no comments for Property ShipPostalCode in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipPostalCode
        {
            get
            {
                return this._ShipPostalCode;
            }
            set
            {
                this.OnShipPostalCodeChanging(value);
                this._ShipPostalCode = value;
                this.OnShipPostalCodeChanged();
                this.OnPropertyChanged("ShipPostalCode");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipPostalCode;
        partial void OnShipPostalCodeChanging(string value);
        partial void OnShipPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property ShipCountry in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ShipCountry
        {
            get
            {
                return this._ShipCountry;
            }
            set
            {
                this.OnShipCountryChanging(value);
                this._ShipCountry = value;
                this.OnShipCountryChanged();
                this.OnPropertyChanged("ShipCountry");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ShipCountry;
        partial void OnShipCountryChanging(string value);
        partial void OnShipCountryChanged();
        /// <summary>
        /// There are no comments for Property CompanyName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                this.OnCompanyNameChanging(value);
                this._CompanyName = value;
                this.OnCompanyNameChanged();
                this.OnPropertyChanged("CompanyName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CompanyName;
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
        /// <summary>
        /// There are no comments for Property Address in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this.OnAddressChanging(value);
                this._Address = value;
                this.OnAddressChanged();
                this.OnPropertyChanged("Address");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Address;
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        /// <summary>
        /// There are no comments for Property City in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnCityChanging(value);
                this._City = value;
                this.OnCityChanged();
                this.OnPropertyChanged("City");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _City;
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        /// <summary>
        /// There are no comments for Property Region in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Region
        {
            get
            {
                return this._Region;
            }
            set
            {
                this.OnRegionChanging(value);
                this._Region = value;
                this.OnRegionChanged();
                this.OnPropertyChanged("Region");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Region;
        partial void OnRegionChanging(string value);
        partial void OnRegionChanged();
        /// <summary>
        /// There are no comments for Property PostalCode in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PostalCode
        {
            get
            {
                return this._PostalCode;
            }
            set
            {
                this.OnPostalCodeChanging(value);
                this._PostalCode = value;
                this.OnPostalCodeChanged();
                this.OnPropertyChanged("PostalCode");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PostalCode;
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property Country in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Country
        {
            get
            {
                return this._Country;
            }
            set
            {
                this.OnCountryChanging(value);
                this._Country = value;
                this.OnCountryChanged();
                this.OnPropertyChanged("Country");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Country;
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Product_Sales_for_1997 in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CategoryName
    /// ProductName
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Product_Sales_for_1997")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CategoryName", "ProductName")]
    public partial class Product_Sales_for_1997 : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Product_Sales_for_1997 object.
        /// </summary>
        /// <param name="categoryName">Initial value of CategoryName.</param>
        /// <param name="productName">Initial value of ProductName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Product_Sales_for_1997 CreateProduct_Sales_for_1997(string categoryName, string productName)
        {
            Product_Sales_for_1997 product_Sales_for_1997 = new Product_Sales_for_1997();
            product_Sales_for_1997.CategoryName = categoryName;
            product_Sales_for_1997.ProductName = productName;
            return product_Sales_for_1997;
        }
        /// <summary>
        /// There are no comments for Property CategoryName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                this.OnCategoryNameChanging(value);
                this._CategoryName = value;
                this.OnCategoryNameChanged();
                this.OnPropertyChanged("CategoryName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CategoryName;
        partial void OnCategoryNameChanging(string value);
        partial void OnCategoryNameChanged();
        /// <summary>
        /// There are no comments for Property ProductName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnProductNameChanging(value);
                this._ProductName = value;
                this.OnProductNameChanged();
                this.OnPropertyChanged("ProductName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProductName;
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
        /// <summary>
        /// There are no comments for Property ProductSales in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> ProductSales
        {
            get
            {
                return this._ProductSales;
            }
            set
            {
                this.OnProductSalesChanging(value);
                this._ProductSales = value;
                this.OnProductSalesChanged();
                this.OnPropertyChanged("ProductSales");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _ProductSales;
        partial void OnProductSalesChanging(global::System.Nullable<decimal> value);
        partial void OnProductSalesChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Products_Above_Average_Price in the schema.
    /// </summary>
    /// <KeyProperties>
    /// ProductName
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Products_Above_Average_Prices")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("ProductName")]
    public partial class Products_Above_Average_Price : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Products_Above_Average_Price object.
        /// </summary>
        /// <param name="productName">Initial value of ProductName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Products_Above_Average_Price CreateProducts_Above_Average_Price(string productName)
        {
            Products_Above_Average_Price products_Above_Average_Price = new Products_Above_Average_Price();
            products_Above_Average_Price.ProductName = productName;
            return products_Above_Average_Price;
        }
        /// <summary>
        /// There are no comments for Property ProductName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnProductNameChanging(value);
                this._ProductName = value;
                this.OnProductNameChanged();
                this.OnPropertyChanged("ProductName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProductName;
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
        /// <summary>
        /// There are no comments for Property UnitPrice in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this.OnUnitPriceChanging(value);
                this._UnitPrice = value;
                this.OnUnitPriceChanged();
                this.OnPropertyChanged("UnitPrice");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _UnitPrice;
        partial void OnUnitPriceChanging(global::System.Nullable<decimal> value);
        partial void OnUnitPriceChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Products_by_Category in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CategoryName
    /// ProductName
    /// Discontinued
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Products_by_Categories")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CategoryName", "ProductName", "Discontinued")]
    public partial class Products_by_Category : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Products_by_Category object.
        /// </summary>
        /// <param name="categoryName">Initial value of CategoryName.</param>
        /// <param name="productName">Initial value of ProductName.</param>
        /// <param name="discontinued">Initial value of Discontinued.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Products_by_Category CreateProducts_by_Category(string categoryName, string productName, bool discontinued)
        {
            Products_by_Category products_by_Category = new Products_by_Category();
            products_by_Category.CategoryName = categoryName;
            products_by_Category.ProductName = productName;
            products_by_Category.Discontinued = discontinued;
            return products_by_Category;
        }
        /// <summary>
        /// There are no comments for Property CategoryName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                this.OnCategoryNameChanging(value);
                this._CategoryName = value;
                this.OnCategoryNameChanged();
                this.OnPropertyChanged("CategoryName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CategoryName;
        partial void OnCategoryNameChanging(string value);
        partial void OnCategoryNameChanged();
        /// <summary>
        /// There are no comments for Property ProductName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnProductNameChanging(value);
                this._ProductName = value;
                this.OnProductNameChanged();
                this.OnPropertyChanged("ProductName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProductName;
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
        /// <summary>
        /// There are no comments for Property QuantityPerUnit in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string QuantityPerUnit
        {
            get
            {
                return this._QuantityPerUnit;
            }
            set
            {
                this.OnQuantityPerUnitChanging(value);
                this._QuantityPerUnit = value;
                this.OnQuantityPerUnitChanged();
                this.OnPropertyChanged("QuantityPerUnit");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _QuantityPerUnit;
        partial void OnQuantityPerUnitChanging(string value);
        partial void OnQuantityPerUnitChanged();
        /// <summary>
        /// There are no comments for Property UnitsInStock in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<short> UnitsInStock
        {
            get
            {
                return this._UnitsInStock;
            }
            set
            {
                this.OnUnitsInStockChanging(value);
                this._UnitsInStock = value;
                this.OnUnitsInStockChanged();
                this.OnPropertyChanged("UnitsInStock");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<short> _UnitsInStock;
        partial void OnUnitsInStockChanging(global::System.Nullable<short> value);
        partial void OnUnitsInStockChanged();
        /// <summary>
        /// There are no comments for Property Discontinued in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool Discontinued
        {
            get
            {
                return this._Discontinued;
            }
            set
            {
                this.OnDiscontinuedChanging(value);
                this._Discontinued = value;
                this.OnDiscontinuedChanged();
                this.OnPropertyChanged("Discontinued");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _Discontinued;
        partial void OnDiscontinuedChanging(bool value);
        partial void OnDiscontinuedChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Sales_by_Category in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CategoryID
    /// CategoryName
    /// ProductName
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Sales_by_Categories")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CategoryID", "CategoryName", "ProductName")]
    public partial class Sales_by_Category : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Sales_by_Category object.
        /// </summary>
        /// <param name="categoryID">Initial value of CategoryID.</param>
        /// <param name="categoryName">Initial value of CategoryName.</param>
        /// <param name="productName">Initial value of ProductName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Sales_by_Category CreateSales_by_Category(int categoryID, string categoryName, string productName)
        {
            Sales_by_Category sales_by_Category = new Sales_by_Category();
            sales_by_Category.CategoryID = categoryID;
            sales_by_Category.CategoryName = categoryName;
            sales_by_Category.ProductName = productName;
            return sales_by_Category;
        }
        /// <summary>
        /// There are no comments for Property CategoryID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int CategoryID
        {
            get
            {
                return this._CategoryID;
            }
            set
            {
                this.OnCategoryIDChanging(value);
                this._CategoryID = value;
                this.OnCategoryIDChanged();
                this.OnPropertyChanged("CategoryID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _CategoryID;
        partial void OnCategoryIDChanging(int value);
        partial void OnCategoryIDChanged();
        /// <summary>
        /// There are no comments for Property CategoryName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CategoryName
        {
            get
            {
                return this._CategoryName;
            }
            set
            {
                this.OnCategoryNameChanging(value);
                this._CategoryName = value;
                this.OnCategoryNameChanged();
                this.OnPropertyChanged("CategoryName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CategoryName;
        partial void OnCategoryNameChanging(string value);
        partial void OnCategoryNameChanged();
        /// <summary>
        /// There are no comments for Property ProductName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnProductNameChanging(value);
                this._ProductName = value;
                this.OnProductNameChanged();
                this.OnPropertyChanged("ProductName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProductName;
        partial void OnProductNameChanging(string value);
        partial void OnProductNameChanged();
        /// <summary>
        /// There are no comments for Property ProductSales in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> ProductSales
        {
            get
            {
                return this._ProductSales;
            }
            set
            {
                this.OnProductSalesChanging(value);
                this._ProductSales = value;
                this.OnProductSalesChanged();
                this.OnPropertyChanged("ProductSales");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _ProductSales;
        partial void OnProductSalesChanging(global::System.Nullable<decimal> value);
        partial void OnProductSalesChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Sales_Totals_by_Amount in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderID
    /// CompanyName
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Sales_Totals_by_Amounts")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("OrderID", "CompanyName")]
    public partial class Sales_Totals_by_Amount : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Sales_Totals_by_Amount object.
        /// </summary>
        /// <param name="orderID">Initial value of OrderID.</param>
        /// <param name="companyName">Initial value of CompanyName.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Sales_Totals_by_Amount CreateSales_Totals_by_Amount(int orderID, string companyName)
        {
            Sales_Totals_by_Amount sales_Totals_by_Amount = new Sales_Totals_by_Amount();
            sales_Totals_by_Amount.OrderID = orderID;
            sales_Totals_by_Amount.CompanyName = companyName;
            return sales_Totals_by_Amount;
        }
        /// <summary>
        /// There are no comments for Property SaleAmount in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> SaleAmount
        {
            get
            {
                return this._SaleAmount;
            }
            set
            {
                this.OnSaleAmountChanging(value);
                this._SaleAmount = value;
                this.OnSaleAmountChanged();
                this.OnPropertyChanged("SaleAmount");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _SaleAmount;
        partial void OnSaleAmountChanging(global::System.Nullable<decimal> value);
        partial void OnSaleAmountChanged();
        /// <summary>
        /// There are no comments for Property OrderID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnOrderIDChanging(value);
                this._OrderID = value;
                this.OnOrderIDChanged();
                this.OnPropertyChanged("OrderID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderID;
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        /// <summary>
        /// There are no comments for Property CompanyName in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CompanyName
        {
            get
            {
                return this._CompanyName;
            }
            set
            {
                this.OnCompanyNameChanging(value);
                this._CompanyName = value;
                this.OnCompanyNameChanged();
                this.OnPropertyChanged("CompanyName");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CompanyName;
        partial void OnCompanyNameChanging(string value);
        partial void OnCompanyNameChanged();
        /// <summary>
        /// There are no comments for Property ShippedDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> ShippedDate
        {
            get
            {
                return this._ShippedDate;
            }
            set
            {
                this.OnShippedDateChanging(value);
                this._ShippedDate = value;
                this.OnShippedDateChanged();
                this.OnPropertyChanged("ShippedDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _ShippedDate;
        partial void OnShippedDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnShippedDateChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Summary_of_Sales_by_Quarter in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Summary_of_Sales_by_Quarters")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("OrderID")]
    public partial class Summary_of_Sales_by_Quarter : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Summary_of_Sales_by_Quarter object.
        /// </summary>
        /// <param name="orderID">Initial value of OrderID.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Summary_of_Sales_by_Quarter CreateSummary_of_Sales_by_Quarter(int orderID)
        {
            Summary_of_Sales_by_Quarter summary_of_Sales_by_Quarter = new Summary_of_Sales_by_Quarter();
            summary_of_Sales_by_Quarter.OrderID = orderID;
            return summary_of_Sales_by_Quarter;
        }
        /// <summary>
        /// There are no comments for Property ShippedDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> ShippedDate
        {
            get
            {
                return this._ShippedDate;
            }
            set
            {
                this.OnShippedDateChanging(value);
                this._ShippedDate = value;
                this.OnShippedDateChanged();
                this.OnPropertyChanged("ShippedDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _ShippedDate;
        partial void OnShippedDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnShippedDateChanged();
        /// <summary>
        /// There are no comments for Property OrderID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnOrderIDChanging(value);
                this._OrderID = value;
                this.OnOrderIDChanged();
                this.OnPropertyChanged("OrderID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderID;
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        /// <summary>
        /// There are no comments for Property Subtotal in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> Subtotal
        {
            get
            {
                return this._Subtotal;
            }
            set
            {
                this.OnSubtotalChanging(value);
                this._Subtotal = value;
                this.OnSubtotalChanged();
                this.OnPropertyChanged("Subtotal");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _Subtotal;
        partial void OnSubtotalChanging(global::System.Nullable<decimal> value);
        partial void OnSubtotalChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for NorthwindModel.Summary_of_Sales_by_Year in the schema.
    /// </summary>
    /// <KeyProperties>
    /// OrderID
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Summary_of_Sales_by_Years")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("OrderID")]
    public partial class Summary_of_Sales_by_Year : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Summary_of_Sales_by_Year object.
        /// </summary>
        /// <param name="orderID">Initial value of OrderID.</param>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Summary_of_Sales_by_Year CreateSummary_of_Sales_by_Year(int orderID)
        {
            Summary_of_Sales_by_Year summary_of_Sales_by_Year = new Summary_of_Sales_by_Year();
            summary_of_Sales_by_Year.OrderID = orderID;
            return summary_of_Sales_by_Year;
        }
        /// <summary>
        /// There are no comments for Property ShippedDate in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<global::System.DateTime> ShippedDate
        {
            get
            {
                return this._ShippedDate;
            }
            set
            {
                this.OnShippedDateChanging(value);
                this._ShippedDate = value;
                this.OnShippedDateChanged();
                this.OnPropertyChanged("ShippedDate");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<global::System.DateTime> _ShippedDate;
        partial void OnShippedDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnShippedDateChanged();
        /// <summary>
        /// There are no comments for Property OrderID in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnOrderIDChanging(value);
                this._OrderID = value;
                this.OnOrderIDChanged();
                this.OnPropertyChanged("OrderID");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _OrderID;
        partial void OnOrderIDChanging(int value);
        partial void OnOrderIDChanged();
        /// <summary>
        /// There are no comments for Property Subtotal in the schema.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<decimal> Subtotal
        {
            get
            {
                return this._Subtotal;
            }
            set
            {
                this.OnSubtotalChanging(value);
                this._Subtotal = value;
                this.OnSubtotalChanged();
                this.OnPropertyChanged("Subtotal");
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<decimal> _Subtotal;
        partial void OnSubtotalChanging(global::System.Nullable<decimal> value);
        partial void OnSubtotalChanged();
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}
