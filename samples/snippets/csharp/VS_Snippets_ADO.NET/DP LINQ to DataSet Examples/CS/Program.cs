// <SnippetImportsUsing>
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
// </SnippetImportsUsing>

namespace LINQtoDataSetSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fill the DataSet.
            //DataSet ds = new DataSet();
            //ds.Locale = CultureInfo.InvariantCulture;
            //FillDataSet(ds);
            //DSInfo(ds);
            //WriteSchemaToXSD(ds);

            /*** Select Operators ***/
            //SelectSimple1();
            //SelectSimple2();
            //SelectAnonymousTypes_MQ();
            //SelectManyCompoundFrom();
            //SelectManyCompoundFrom_MQ();
            //SelectManyCompoundFrom2();
            //SelectManyCompoundFrom2_MQ();
            //SelectManyFromAssignment();

            /*** Restriction Operators ***/
            //Where1();
            //Where2();
            //Where3();
            //WhereDrilldown();
            //WhereIsNull();

            /*** Partitioning Operators ***/
            //TakeSimple();
            //SkipSimple();
            //TakeNested();
            //SkipNested();
            //TakeWhileSimple_MQ();
            //SkipWhileSimple_MQ(); // Need better example...

            /*** Ordering Operators ***/
            //OrderBySimple1();
            //OrderBySimple2();
            //OrderByComparer_MQ();
            //OrderByDescendingSimple1();
            //ThenByDescendingSimple();
            //ThenByDescendingComparer_MQ();
            //Reverse();

            /*** Grouping Operators ***/
            //GroupBySimple2();
            //GroupBySimple3();
            //GroupByNested();

            /*** Set Operators ***/
            //DistinctRows(); // Messy...
            //Distinct2(); // Pathetic...
            //Union2();
            //Intersect2();
            //Except2();

            /*** Conversion Operators ***/
            //ToArray();
            //ToArray2();
            //ToList();
            //ToDictionary();
            //OfType();

            /*** Element Operators ***/
            //FirstSimple();
            //FirstCondition_MQ();
            //ElementAt();

            /*** Generation Operators ***/
            //Range();      // Didn't use Range, couldn't get it to work.

            /*** Quantifier Operators ***/
            //AnyGrouped_MQ();
            //AllGrouped_MQ();

            /*** Aggregate Operators ***/
            //Aggregate_MQ();
            //Average_MQ();
            //Average2_MQ();
            //Count();
            //CountNested();
            //CountGrouped();
            //LongCountSimple();
            //SumProjection_MQ();
            //SumGrouped_MQ();
            //MinProjection_MQ();
            //MinGrouped_MQ();
            //MinElements_MQ();
            //AverageProjection_MQ();
            //AverageGrouped_MQ();
            //AverageElements_MQ();
            //MaxProjection_MQ();
            //MaxGrouped_MQ();
            MaxElements_MQ();

            /*** Join Operators ***/
            //Join();
            //JoinSimple_MQ();
            //JoinWithGroupedResults_MQ();
            //GroupJoin();
            //GroupJoin2();

            /*** DataSet Loading examples***/
            //LoadingQueryResultsIntoDataTable(); // Didn't include, need to update
            //LoadDataTableWithQueryResults();

            /*** DataRowComparer examples ***/
            //CompareDifferentDataRows();
            //CompareEqualDataRows();
            //CompareNullDataRows();

            /*** CopyToDataTable examples ***/
            //CopyToDataTable1();

            //*** Misc ***/
            //Composing();

            /*** Other stuff  ***/
            //OrderBy();
            //OrderByDescending();
            //Sum();
            //GroupBy();

            Console.WriteLine("Hit Enter...");
            Console.Read();
        }

        #region "Select Operators"

        /*[Category("Projection Operators")]
        [Title("Select - Simple 1")]
        [Description("This example uses Select to return all the rows from the Product table and display the product names.")]*/

        static void SelectSimple1()
        {
            // <SnippetSelectSimple1>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<DataRow> query =
                from product in products.AsEnumerable()
                select product;

            Console.WriteLine("Product Names:");
            foreach (DataRow p in query)
            {
                Console.WriteLine(p.Field<string>("Name"));
            }
            // </SnippetSelectSimple1>
        }

        /*[Category("Projection Operators")]
        [Title("Select - Simple 2")]
        [Description("This example uses Select to return a sequence of only product names.")]*/
        static void SelectSimple2()
        {
            // <SnippetSelectSimple2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<string> query =
                from product in products.AsEnumerable()
                select product.Field<string>("Name");

            Console.WriteLine("Product Names:");
            foreach (string productName in query)
            {
                Console.WriteLine(productName);
            }
            // </SnippetSelectSimple2>
        }

        /*[Category("Projection Operators")]
        [Title("Select - Anonymous Types ")]
        [Description("This example uses Select to project the Name, ProductNumber, and
          ListPrice properties to a sequence of anonymous types.  The ListPrice
          property is also renamed to Price in the resulting type.")]*/
        static void SelectAnonymousTypes_MQ()
        {
            // <SnippetSelectAnonymousTypes_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            var query = products.AsEnumerable().
                Select(product => new
                {
                    ProductName = product.Field<string>("Name"),
                    ProductNumber = product.Field<string>("ProductNumber"),
                    Price = product.Field<decimal>("ListPrice")
                });

            Console.WriteLine("Product Info:");
            foreach (var productInfo in query)
            {
                Console.WriteLine($"Product name: {productInfo.ProductName} Product number: {productInfo.ProductNumber} List price: ${productInfo.Price} ");
            }
            // </SnippetSelectAnonymousTypes_MQ>
        }

        /*[Category("Projection Operators")]
        [Title("SelectMany - Compound from")]
        [Description("This example uses a compound From clause to select all orders where " +
                     " TotalDue is less than 500.00.")]*/
        static void SelectManyCompoundFrom()
        {
            // <SnippetSelectManyCompoundFrom>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from contact in contacts.AsEnumerable()
                from order in orders.AsEnumerable()
                where contact.Field<int>("ContactID") == order.Field<int>("ContactID")
                    && order.Field<decimal>("TotalDue") < 500.00M
                select new
                {
                    ContactID = contact.Field<int>("ContactID"),
                    LastName = contact.Field<string>("LastName"),
                    FirstName = contact.Field<string>("FirstName"),
                    OrderID = order.Field<int>("SalesOrderID"),
                    Total = order.Field<decimal>("TotalDue")
                };

            foreach (var smallOrder in query)
            {
                Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ",
                    smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName,
                    smallOrder.OrderID, smallOrder.Total);
            }
            // </SnippetSelectManyCompoundFrom>
        }

        /*[Category("Projection Operators")]
        [Title("SelectMany - Compound from using method syntax")]
        [Description("This example uses SelectMany to select all orders where " +
                     " TotalDue is less than 500.00.")]*/
        static void SelectManyCompoundFrom_MQ()
        {
            // <SnippetSelectManyCompoundFrom_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            var contacts = ds.Tables["Contact"].AsEnumerable();
            var orders = ds.Tables["SalesOrderHeader"].AsEnumerable();

            var query =
                contacts.SelectMany(
                    contact => orders.Where(order =>
                        (contact.Field<Int32>("ContactID") == order.Field<Int32>("ContactID"))
                            && order.Field<decimal>("TotalDue") < 500.00M)
                        .Select(order => new
                        {
                            ContactID = contact.Field<int>("ContactID"),
                            LastName = contact.Field<string>("LastName"),
                            FirstName = contact.Field<string>("FirstName"),
                            OrderID = order.Field<int>("SalesOrderID"),
                            Total = order.Field<decimal>("TotalDue")
                        }));

            foreach (var smallOrder in query)
            {
                Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ",
                    smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName,
                    smallOrder.OrderID, smallOrder.Total);
            }
            // </SnippetSelectManyCompoundFrom_MQ>
        }

        /*[Category("Projection Operators")]
        [Title("SelectMany - Compound From 2")]
        [Description("This example uses a compound From clause to select all orders where the " +
                     "order was made on October 1, 2002 or later.")]*/
        static void SelectManyCompoundFrom2()
        {
            // <SnippetSelectManyCompoundFrom2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from contact in contacts.AsEnumerable()
                from order in orders.AsEnumerable()
                where contact.Field<int>("ContactID") == order.Field<int>("ContactID") &&
                    order.Field<DateTime>("OrderDate") >= new DateTime(2002, 10, 1)
                select new
                {
                    ContactID = contact.Field<int>("ContactID"),
                    LastName = contact.Field<string>("LastName"),
                    FirstName = contact.Field<string>("FirstName"),
                    OrderID = order.Field<int>("SalesOrderID"),
                    OrderDate = order.Field<DateTime>("OrderDate")
                };

            foreach (var order in query)
            {
                Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Order date: {4:d} ",
                    order.ContactID, order.LastName, order.FirstName,
                    order.OrderID, order.OrderDate);
            }
            // </SnippetSelectManyCompoundFrom2>
        }

        /*[Category("Projection Operators")]
        [Title("SelectMany - Compound from 2, method-based query syntax")]
        [Description("This example uses SelectMany to select all orders where the " +
                     "order was made on October 1, 2002 or later.")]*/
        static void SelectManyCompoundFrom2_MQ()
        {
            // <SnippetSelectManyCompoundFrom2_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            var contacts = ds.Tables["Contact"].AsEnumerable();
            var orders = ds.Tables["SalesOrderHeader"].AsEnumerable();

            var query =
                contacts.SelectMany(
                    contact => orders.Where(order =>
                        (contact.Field<Int32>("ContactID") == order.Field<Int32>("ContactID"))
                            && order.Field<DateTime>("OrderDate") >= new DateTime(2002, 10, 1))
                        .Select(order => new
                        {
                            ContactID = contact.Field<int>("ContactID"),
                            LastName = contact.Field<string>("LastName"),
                            FirstName = contact.Field<string>("FirstName"),
                            OrderID = order.Field<int>("SalesOrderID"),
                            OrderDate = order.Field<DateTime>("OrderDate")
                        }));

            foreach (var order in query)
            {
                Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Order date: {4:d} ",
                    order.ContactID, order.LastName, order.FirstName,
                    order.OrderID, order.OrderDate);
            }
            // </SnippetSelectManyCompoundFrom2_MQ>
        }

        /*[Category("Projection Operators")]
        [Title("SelectMany - from Assignment")]
        [Description("This example uses a compound From clause to select all orders where the " +
                     "order total is greater than 10000.00 and uses From assignment to avoid " +
                     "requesting the total twice.")]*/
        static void SelectManyFromAssignment()
        {
            // <SnippetSelectManyFromAssignment>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from contact in contacts.AsEnumerable()
                from order in orders.AsEnumerable()
                let total = order.Field<decimal>("TotalDue")
                where contact.Field<int>("ContactID") == order.Field<int>("ContactID") &&
                      total >= 10000.0M
                select new
                {
                    ContactID = contact.Field<int>("ContactID"),
                    LastName = contact.Field<string>("LastName"),
                    OrderID = order.Field<int>("SalesOrderID"),
                    total
                };
            foreach (var order in query)
            {
                Console.WriteLine($"Contact ID: {order.ContactID} Last name: {order.LastName} Order ID: {order.OrderID} Total: {order.total}");
            }

            // </SnippetSelectManyFromAssignment>
        }
        #endregion

        #region "Restriction Operators"

        /*[Category("Restriction Operators")]
        [Title("Where ")]
        [Description("This example returns all online orders.")]*/
        static void Where1()
        {
            //<SnippetWhere1>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from order in orders.AsEnumerable()
                where order.Field<bool>("OnlineOrderFlag") == true
                select new
                {
                    SalesOrderID = order.Field<int>("SalesOrderID"),
                    OrderDate = order.Field<DateTime>("OrderDate"),
                    SalesOrderNumber = order.Field<string>("SalesOrderNumber")
                };

            foreach (var onlineOrder in query)
            {
                Console.WriteLine($"Order ID: {onlineOrder.SalesOrderID} Order date: {onlineOrder.OrderDate:d} Order number: {onlineOrder.SalesOrderNumber}");
            }
            //</SnippetWhere1>
        }

        /*[Category("Restriction Operators")]
        [Title("Where ")]
        [Description("This example returns the orders where the order quantity is greater than 2 and less than 6.")]*/
        static void Where2()
        {
            //<SnippetWhere2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderDetail"];

            var query =
                from order in orders.AsEnumerable()
                where order.Field<Int16>("OrderQty") > 2 &&
                    order.Field<Int16>("OrderQty") < 6
                select new
                {
                    SalesOrderID = (int)order.Field<int>("SalesOrderID"),
                    OrderQty = order.Field<Int16>("OrderQty")
                };

            foreach (var order in query)
            {
                Console.WriteLine($"Order ID: {order.SalesOrderID} Order quantity: {order.OrderQty}");
            }
            //</SnippetWhere2>
        }

        /*[Category("Restriction Operators")]
        [Title("Where ")]
        [Description("This example returns all red colored products.")]*/
        static void Where3()
        {
            //<SnippetWhere3>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            var query =
                from product in products.AsEnumerable()
                where product.Field<string>("Color") == "Red"
                select new
                {
                    Name = product.Field<string>("Name"),
                    ProductNumber = product.Field<string>("ProductNumber"),
                    ListPrice = product.Field<Decimal>("ListPrice")
                };

            foreach (var product in query)
            {
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Product number: {product.ProductNumber}");
                Console.WriteLine($"List price: ${product.ListPrice}");
                Console.WriteLine("");
            }
            //</SnippetWhere3>
        }

        /*[Category("Restriction Operators")]
        [Title("Where ")]
        [Description("This example returns all red colored products.  This query does not used the generic Field
         method, but explicitly checks column values for null.")]*/
        static void WhereIsNull()
        {
            //<SnippetWhereIsNull>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            var query =
                from product in products.AsEnumerable()
                where !product.IsNull("Color") &&
                    (string)product["Color"] == "Red"
                select new
                {
                    Name = product["Name"],
                    ProductNumber = product["ProductNumber"],
                    ListPrice = product["ListPrice"]
                };

            foreach (var product in query)
            {
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Product number: {product.ProductNumber}");
                Console.WriteLine($"List price: ${product.ListPrice}");
                Console.WriteLine("");
            }
            //</SnippetWhereIsNull>
        }

        /*[Category("Restriction Operators")]
        [Title("Where - Drilldown")]
        [Description("This example uses Where to find orders that were made after December 1, 2002 " +
                     "and then uses the GetChildRows to get the details for each order.")]*/
        static void WhereDrilldown()
        {
            //<SnippetWhereDrilldown>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            IEnumerable<DataRow> query =
                from order in orders.AsEnumerable()
                where order.Field<DateTime>("OrderDate") >= new DateTime(2002, 12, 1)
                select order;

            Console.WriteLine("Orders that were made after 12/1/2002:");
            foreach (DataRow order in query)
            {
                Console.WriteLine($"OrderID {order.Field<int>("SalesOrderID")} Order date: {order.Field<DateTime>("OrderDate"):d} ");
                foreach (DataRow orderDetail in order.GetChildRows("SalesOrderHeaderDetail"))
                {
                    Console.WriteLine($"  Product ID: {orderDetail["ProductID"]} Unit Price {orderDetail["UnitPrice"]}");
                }
            }
            //</SnippetWhereDrilldown>
        }
        #endregion

        #region "Partitioning Operators"

        /*[Category("Partitioning Operators")]
        [Title("Take - Nested")]
        [Description("This example uses Take to get the first three addresses " +
                     "in Seattle.")]*/
        static void TakeNested()
        {
            //<SnippetTakeNested>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable addresses = ds.Tables["Address"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query = (
                from address in addresses.AsEnumerable()
                from order in orders.AsEnumerable()
                where address.Field<int>("AddressID") == order.Field<int>("BillToAddressID")
                     && address.Field<string>("City") == "Seattle"
                select new
                {
                    City = address.Field<string>("City"),
                    OrderID = order.Field<int>("SalesOrderID"),
                    OrderDate = order.Field<DateTime>("OrderDate")
                }).Take(3);

            Console.WriteLine("First 3 orders in Seattle:");
            foreach (var order in query)
            {
                Console.WriteLine($"City: {order.City} Order ID: {order.OrderID} Total Due: {order.OrderDate:d}");
            }
            //</SnippetTakeNested>
        }

        /*[Category("Partitioning Operators")]
        [Title("Skip - Nested")]
        [Description("This example uses Skip to get all but the first two addresses " +
                     "in Seattle.")]*/
        static void SkipNested()
        {
            //<SnippetSkipNested>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable addresses = ds.Tables["Address"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query = (
                from address in addresses.AsEnumerable()
                from order in orders.AsEnumerable()
                where address.Field<int>("AddressID") == order.Field<int>("BillToAddressID")
                     && address.Field<string>("City") == "Seattle"
                select new
                {
                    City = address.Field<string>("City"),
                    OrderID = order.Field<int>("SalesOrderID"),
                    OrderDate = order.Field<DateTime>("OrderDate")
                }).Skip(2);

            Console.WriteLine("All but first 2 orders in Seattle:");
            foreach (var order in query)
            {
                Console.WriteLine($"City: {order.City} Order ID: {order.OrderID} Total Due: {order.OrderDate:d}");
            }
            //</SnippetSkipNested>
        }

        /*[Category("Partitioning Operators")]
        [Title("Take - Simple")]
        [Description("This example uses Take to get only the first five contacts from the Contact table.")]*/
        static void TakeSimple()
        {
            //<SnippetTakeSimple>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            IEnumerable<DataRow> first5Contacts = contacts.AsEnumerable().Take(5);

            Console.WriteLine("First 5 contacts:");
            foreach (DataRow contact in first5Contacts)
            {
                Console.WriteLine($"Title = {contact.Field<string>("Title")} \t FirstName = {contact.Field<string>("FirstName")} \t Lastname = {contact.Field<string>("Lastname")}");
            }
            //</SnippetTakeSimple>
        }

        /*[Category("Partitioning Operators")]
        [Title("Skip - Simple")]
        [Description("This example uses Skip to get all but the first five contacts of the Contact table.")]*/
        static void SkipSimple()
        {
            //<SnippetSkipSimple>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            IEnumerable<DataRow> allButFirst5Contacts = contacts.AsEnumerable().Skip(5);

            Console.WriteLine("All but first 5 contacts:");
            foreach (DataRow contact in allButFirst5Contacts)
            {
                Console.WriteLine($"FirstName = {contact.Field<string>("FirstName")} \tLastname = {contact.Field<string>("Lastname")}");
            }
            //</SnippetSkipSimple>
        }

        /*[Category("Partitioning Operators")]
        [Title("TakeWhile - Simple")]
        [Description("This example uses OrderBy and TakeWhile to return products from the Product table with a list price less than 300.00.")]*/
        static void TakeWhileSimple_MQ()
        {
            //<SnippetTakeWhileSimple_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<DataRow> takeWhileListPriceLessThan300 =
                products.AsEnumerable()
                    .OrderBy(listprice => listprice.Field<decimal>("ListPrice"))
                    .TakeWhile(product => product.Field<decimal>("ListPrice") < 300.00M);

            Console.WriteLine("First ListPrice less than 300:");
            foreach (DataRow product in takeWhileListPriceLessThan300)
            {
                Console.WriteLine(product.Field<decimal>("ListPrice"));
            }
            //</SnippetTakeWhileSimple_MQ>
        }

        /*[Category("Partitioning Operators")]
        [Title("SkipWhile - Simple")]
        [Description("This example uses OrderBy and SkipWhile to return products from the Product table with a list price greater than 300.00.")]*/

        static void SkipWhileSimple_MQ()
        {
            //<SnippetSkipWhileSimple_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<DataRow> skipWhilePriceLessThan300 =
                products.AsEnumerable()
                    .OrderBy(listprice => listprice.Field<decimal>("ListPrice"))
                    .SkipWhile(product => product.Field<decimal>("ListPrice") < 300.00M);

            Console.WriteLine("Skip while ListPrice is less than 300.00:");
            foreach (DataRow product in skipWhilePriceLessThan300)
            {
                Console.WriteLine(product.Field<decimal>("ListPrice"));
            }
            //</SnippetSkipWhileSimple_MQ>
        }
        #endregion

        #region "Ordering Operators"

        /*[Category("Ordering Operators")]
        [Title("OrderBy - Simple 1")]
        [Description("This example uses OrderBy to return a list of contacts ordered by last name.")]*/
        static void OrderBySimple1()
        {
            //<SnippetOrderBySimple1>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            IEnumerable<DataRow> query =
                from contact in contacts.AsEnumerable()
                orderby contact.Field<string>("LastName")
                select contact;

            Console.WriteLine("The sorted list of last names:");
            foreach (DataRow contact in query)
            {
                Console.WriteLine(contact.Field<string>("LastName"));
            }
            //</SnippetOrderBySimple1>
        }

        /*[Category("Ordering Operators")]
        [Title("OrderBy - Simple 2")]
        [Description("This example uses OrderBy to sort a list of contacts by length of last name.")]*/
        static void OrderBySimple2()
        {
            //<SnippetOrderBySimple2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            IEnumerable<DataRow> query =
                from contact in contacts.AsEnumerable()
                orderby contact.Field<string>("LastName").Length
                select contact;

            Console.WriteLine("The sorted list of last names (by length):");
            foreach (DataRow contact in query)
            {
                Console.WriteLine(contact.Field<string>("LastName"));
            }
            //</SnippetOrderBySimple2>
        }

        /*[Category("Ordering Operators")]
        [Title("OrderBy - Comparer")]
        [Description("This example uses an OrderBy clause with a custom comparer to " +
                     "do a case-insensitive sort of last names.")]
        [LinkedClass("CaseInsensitiveComparer")]*/

        //<SnippetCustomComparer>
        private class CaseInsensitiveComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(x, y, true, CultureInfo.InvariantCulture);
            }
        }
        //</SnippetCustomComparer>
        static void OrderByComparer_MQ()
        {
            //<SnippetOrderByComparer_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            IEnumerable<DataRow> query =
                contacts.AsEnumerable().OrderBy(contact => contact.Field<string>("LastName"),
                                                new CaseInsensitiveComparer());

            foreach (DataRow contact in query)
            {
                Console.WriteLine(contact.Field<string>("LastName"));
            }
            //</SnippetOrderByComparer_MQ>
        }

        /*[Category("Ordering Operators")]
        [Title("OrderByDescending - Simple 1")]
        [Description("This example uses OrderBy and Descending to sort the price list " +
                     "from highest to lowest.")]*/
        static void OrderByDescendingSimple1()
        {
            //<SnippetOrderByDescendingSimple1>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<Decimal> query =
                from product in products.AsEnumerable()
                orderby product.Field<Decimal>("ListPrice") descending
                select product.Field<Decimal>("ListPrice");

            Console.WriteLine("The list price from highest to lowest:");
            foreach (Decimal product in query)
            {
                Console.WriteLine(product);
            }
            //</SnippetOrderByDescendingSimple1>
        }

        /*[Category("Ordering Operators")]
        [Title("ThenByDescending - Simple")]
        [Description("This example uses a compound OrderBy to sort a list of products, " +
                     "first by name and then by list price, from highest to lowest.")]*/
        static void ThenByDescendingSimple()
        {
            //<SnippetThenByDescendingSimple>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<DataRow> query =
                from product in products.AsEnumerable()
                orderby product.Field<string>("Name"),
                    product.Field<Decimal>("ListPrice") descending
                select product;

            foreach (DataRow product in query)
            {
                Console.WriteLine($"Product ID: {product.Field<int>("ProductID")} Product Name: {product.Field<string>("Name")} List Price {product.Field<Decimal>("ListPrice")}");
            }
            //</SnippetThenByDescendingSimple>
        }

        /*[Category("Ordering Operators")]
        [Title("ThenByDescending - Comparer")]
        [Description("This example uses OrderBy and ThenBy with a custom comparer to " +
                     "first sort by list price, and then perform a case-insensitive descending sort " +
                     "of the product names.")]
        [LinkedClass("CaseInsensitiveComparer")]*/
        static void ThenByDescendingComparer_MQ()
        {
            //<SnippetThenByDescendingComparer_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<DataRow> query =
                products.AsEnumerable().OrderBy(product => product.Field<Decimal>("ListPrice"))
                .ThenBy(product => product.Field<string>("Name"),
                        new CaseInsensitiveComparer());

            foreach (DataRow product in query)
            {
                Console.WriteLine($"Product ID: {product.Field<int>("ProductID")} Product Name: {product.Field<string>("Name")} List Price {product.Field<Decimal>("ListPrice")}");
            }
            //</SnippetThenByDescendingComparer_MQ>
        }
        /*
        [Category("Ordering Operators")]
        [Title("Reverse")]
        [Description("This example uses Reverse to create a list of orders where OrderDate is earlier than Feb 20, 2002.")]*/
        static void Reverse()
        {
            //<SnippetReverse>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            IEnumerable<DataRow> query = (
                from order in orders.AsEnumerable()
                where order.Field<DateTime>("OrderDate") < new DateTime(2002, 02, 20)
                select order).Reverse();

            Console.WriteLine("A backwards list of orders where OrderDate < Feb 20, 2002");
            foreach (DataRow order in query)
            {
                Console.WriteLine(order.Field<DateTime>("OrderDate"));
            }
            //</SnippetReverse>
        }

        #endregion

        #region "Grouping Operators"

        /*[Category("Grouping Operators")]
        [Title("GroupBy - Simple 2")]
        [Description("This example uses GroupBy to partition a list of contacts by the first letter of their last name.")]*/
        static void GroupBySimple2()
        {
            //<SnippetGroupBySimple2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            var query = (
                from contact in contacts.AsEnumerable()
                group contact by contact.Field<string>("LastName")[0] into g
                select new { FirstLetter = g.Key, Names = g }).
                    OrderBy(letter => letter.FirstLetter);

            foreach (var contact in query)
            {
                Console.WriteLine($"Last names that start with the letter '{contact.FirstLetter}':");
                foreach (var name in contact.Names)
                {
                    Console.WriteLine(name.Field<string>("LastName"));
                }
            }
            //</SnippetGroupBySimple2>
        }

        /*[Category("Grouping Operators")]
        [Title("GroupBy - Simple 3")]
        [Description("This example uses GroupBy to partition a list of addresses by postal code.")]*/
        static void GroupBySimple3()
        {
            //<SnippetGroupBySimple3>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable addresses = ds.Tables["Address"];

            var query =
                from address in addresses.AsEnumerable()
                group address by address.Field<string>("PostalCode") into g
                select new { PostalCode = g.Key, AddressLine = g };

            foreach (var addressGroup in query)
            {
                Console.WriteLine($"Postal Code: {addressGroup.PostalCode}");
                foreach (var address in addressGroup.AddressLine)
                {
                    Console.WriteLine("\t" + address.Field<string>("AddressLine1") +
                        address.Field<string>("AddressLine2"));
                }
            }
            //</SnippetGroupBySimple3>
        }

        /*[Category("Grouping Operators")]
        [Title("GroupBy - Nested")]
        [Description("This example uses GroupBy to partition a list of each contact's orders, " +
                     "first by year, and then by month.")]*/
        static void GroupByNested()
        {
            //<SnippetGroupByNested>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            var query =
                from contact in contacts.AsEnumerable()
                select
                    new
                    {
                        ContactID = contact.Field<int>("ContactID"),
                        YearGroups =
                            from order in contact.GetChildRows("SalesOrderContact")
                            group order by order.Field<DateTime>("OrderDate").Year into yg
                            select
                                new
                                {
                                    Year = yg.Key,
                                    MonthGroups =
                                        from order in yg
                                        group order by order.Field<DateTime>("OrderDate").
                                            Month into mg
                                        select new { Month = mg.Key, Orders = mg }
                                }
                    };

            foreach (var contactGroup in query)
            {
                Console.WriteLine($"ContactID = {contactGroup.ContactID}");
                foreach (var yearGroup in contactGroup.YearGroups)
                {
                    Console.WriteLine($"\t Year= {yearGroup.Year}");
                    foreach (var monthGroup in yearGroup.MonthGroups)
                    {
                        Console.WriteLine($"\t\t Month= {monthGroup.Month}");
                        foreach (var order in monthGroup.Orders)
                        {
                            Console.WriteLine($"\t\t\t OrderID= {order.Field<int>("SalesOrderID")} ");
                            Console.WriteLine($"\t\t\t OrderDate= {order.Field<DateTime>("OrderDate")} ");
                        }
                    }
                }
            }
            //</SnippetGroupByNested>
        }
        #endregion

        #region "Set Operators"
        /*[Category("Set Operators")]
        [Title("DistinctRows")]
        [Description("This example uses Distinct to remove duplicate elements in a sequence.")]*/

        static void DistinctRows()
        {
            //<SnippetDistinctRows>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            List<DataRow> rows = new List<DataRow>();

            DataTable contact = ds.Tables["Contact"];

            // Get 100 rows from the Contact table.
            IEnumerable<DataRow> query = (from c in contact.AsEnumerable()
                                          select c).Take(100);

            DataTable contactsTableWith100Rows = query.CopyToDataTable();

            // Add 100 rows to the list.
            foreach (DataRow row in contactsTableWith100Rows.Rows)
                rows.Add(row);

            // Create duplicate rows by adding the same 100 rows to the list.
            foreach (DataRow row in contactsTableWith100Rows.Rows)
                rows.Add(row);

            DataTable table =
                System.Data.DataTableExtensions.CopyToDataTable<DataRow>(rows);

            // Find the unique contacts in the table.
            IEnumerable<DataRow> uniqueContacts =
                table.AsEnumerable().Distinct(DataRowComparer.Default);

            Console.WriteLine("Unique contacts:");
            foreach (DataRow uniqueContact in uniqueContacts)
            {
                Console.WriteLine(uniqueContact.Field<Int32>("ContactID"));
            }
            //</SnippetDistinctRows>
        }

        /*[Category("Set Operators")]
        [Title("Distinct - 2")]
        [Description("This example uses Distinct to remove duplicate contacts.")]*/
        static void Distinct2()
        {
            //<SnippetDistinct2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts1 = ds.Tables["Contact"];

            IEnumerable<DataRow> query = from contact in contacts1.AsEnumerable()
                                         where contact.Field<string>("Title") == "Ms."
                                         select contact;

            DataTable contacts2 = query.CopyToDataTable();

            IEnumerable<DataRow> distinctContacts =
                contacts2.AsEnumerable().Distinct(DataRowComparer.Default);

            foreach (DataRow row in distinctContacts)
            {
                Console.WriteLine($"Id: {row["ContactID"]} {row["Title"]} {row["FirstName"]} {row["LastName"]}");
            }
            //</SnippetDistinct2>
        }

        /*[Category("Set Operators")]
        [Title("Union - 2")]
        [Description("This example uses Union to return unique contacts from either of the two tables.")]*/
        static void Union2()
        {
            //<SnippetUnion2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            // Create two tables.
            DataTable contactTable = ds.Tables["Contact"];
            IEnumerable<DataRow> query1 = from contact in contactTable.AsEnumerable()
                                          where contact.Field<string>("Title") == "Ms."
                                          select contact;

            IEnumerable<DataRow> query2 = from contact in contactTable.AsEnumerable()
                                          where contact.Field<string>("FirstName") == "Sandra"
                                          select contact;

            DataTable contacts1 = query1.CopyToDataTable();
            DataTable contacts2 = query2.CopyToDataTable();

            // Find the union of the two tables.
            var contacts = contacts1.AsEnumerable().Union(contacts2.AsEnumerable(),
                                                            DataRowComparer.Default);

            Console.WriteLine("Union of contacts tables:");
            foreach (DataRow row in contacts)
            {
                Console.WriteLine($"Id: {row["ContactID"]} {row["Title"]} {row["FirstName"]} {row["LastName"]}");
            }
            //</SnippetUnion2>
        }

        /*[Category("Set Operators")]
        [Title("Intersect - 2")]
        [Description("This example uses Intersect to return contacts that appear in both tables.")]*/
        static void Intersect2()
        {
            //<SnippetIntersect2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contactTable = ds.Tables["Contact"];

            // Create two tables.
            IEnumerable<DataRow> query1 = from contact in contactTable.AsEnumerable()
                                          where contact.Field<string>("Title") == "Ms."
                                          select contact;

            IEnumerable<DataRow> query2 = from contact in contactTable.AsEnumerable()
                                          where contact.Field<string>("FirstName") == "Sandra"
                                          select contact;

            DataTable contacts1 = query1.CopyToDataTable();
            DataTable contacts2 = query2.CopyToDataTable();

            // Find the intersection of the two tables.
            var contacts = contacts1.AsEnumerable().Intersect(contacts2.AsEnumerable(),
                                                                DataRowComparer.Default);

            Console.WriteLine("Intersection of contacts tables");
            foreach (DataRow row in contacts)
            {
                Console.WriteLine($"Id: {row["ContactID"]} {row["Title"]} {row["FirstName"]} {row["LastName"]}");
            }
            //</SnippetIntersect2>
        }

        /*[Category("Set Operators")]
        [Title("Except - 2")]
        [Description("This example uses Except to return contacts that appear in the first table but not in the second.")]*/
        static void Except2()
        {
            //<SnippetExcept2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contactTable = ds.Tables["Contact"];

            // Create two tables.
            IEnumerable<DataRow> query1 = from contact in contactTable.AsEnumerable()
                                          where contact.Field<string>("Title") == "Ms."
                                          select contact;

            IEnumerable<DataRow> query2 = from contact in contactTable.AsEnumerable()
                                          where contact.Field<string>("FirstName") == "Sandra"
                                          select contact;

            DataTable contacts1 = query1.CopyToDataTable();
            DataTable contacts2 = query2.CopyToDataTable();

            // Find the contacts that are in the first
            // table but not the second.
            var contacts = contacts1.AsEnumerable().Except(contacts2.AsEnumerable(),
                                                           DataRowComparer.Default);

            Console.WriteLine("Except of employees tables");
            foreach (DataRow row in contacts)
            {
                Console.WriteLine($"Id: {row["ContactID"]} {row["Title"]} {row["FirstName"]} {row["LastName"]}");
            }
            //</SnippetExcept2>
        }

        #endregion

        #region "Conversion Operators"
        /*[Category("Conversion Operators")]
        [Title("ToArray")]
        [Description("This example uses ToArray to immediately evaluate a sequence into an array.")]*/
        static void ToArray()
        {
            //<SnippetToArray>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<DataRow> productsArray = products.AsEnumerable().ToArray();

            IEnumerable<DataRow> query =
                from product in productsArray
                orderby product.Field<Decimal>("ListPrice") descending
                select product;

            Console.WriteLine("Every price from highest to lowest:");
            foreach (DataRow product in query)
            {
                Console.WriteLine(product.Field<Decimal>("ListPrice"));
            }
            //</SnippetToArray>
        }

        /*[Category("Conversion Operators")]
        [Title("ToArray2")]
        [Description("This example uses ToArray to immediately evaluate a sequence into an array.")]*/
        static void ToArray2()
        {
            //<SnippetToArray2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<DataRow> query =
                from product in products.AsEnumerable()
                orderby product.Field<Decimal>("ListPrice") descending
                select product;

            // Force immediate execution of the query.
            IEnumerable<DataRow> productsArray = query.ToArray();

            Console.WriteLine("Every price from highest to lowest:");
            foreach (DataRow prod in productsArray)
            {
                Console.WriteLine(prod.Field<Decimal>("ListPrice"));
            }
            //</SnippetToArray2>
        }

        /*[Category("Conversion Operators")]
        [Title("ToList")]
        [Description("This example uses ToList to immediately evaluate a sequence into a List<T>, where T is of type DataRow.")]*/
        static void ToList()
        {
            //<SnippetToList>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<DataRow> productList = products.AsEnumerable().ToList();

            IEnumerable<DataRow> query =
                from product in productList
                orderby product.Field<string>("Name")
                select product;

            Console.WriteLine("The product list, ordered by product name:");
            foreach (DataRow product in query)
            {
                Console.WriteLine(product.Field<string>("Name").ToLower(CultureInfo.InvariantCulture));
            }
            //</SnippetToList>
        }

        /*[Category("Conversion Operators")]
        [Title("ToDictionary")]
        [Description("This example uses ToDictionary to immediately evaluate a sequence and a " +
                    "related key expression into a dictionary.")]*/
        static void ToDictionary()
        {
            //<SnippetToDictionary>
            // Fill the DataSet.
            DataSet ds = new DataSet
            {
                Locale = CultureInfo.InvariantCulture
            };
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            var scoreRecordsDict =
                products.AsEnumerable()
                    .Where(rec=>rec.Field<string>("Name") !=null)
                    .ToDictionary(record => record.Field<string>("Name"));
            Console.WriteLine($"Top Tube's ProductID: {scoreRecordsDict["Top Tube"]["ProductID"]}");
            //</SnippetToDictionary>
        }

        #endregion

        #region "Element Operators"
        /*[Category("Element Operators")]
        [Title("First - Simple")]
        [Description("This example uses First to return the first contact whose first name is 'Brooke'.")]*/
        static void FirstSimple()
        {
            //<SnippetFirstSimple>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            DataRow query = (
                from contact in contacts.AsEnumerable()
                where (string)contact["FirstName"] == "Brooke"
                select contact)
                .First();

            Console.WriteLine("ContactID: " + query.Field<int>("ContactID"));
            Console.WriteLine("FirstName: " + query.Field<string>("FirstName"));
            Console.WriteLine("LastName: " + query.Field<string>("LastName"));
            //</SnippetFirstSimple>
        }

        /*[Category("Element Operators")]
        [Title("First - Condition")]
        [Description("This example uses First to find the first email address that starts with 'caroline'.")]*/
        static void FirstCondition_MQ()
        {
            //<SnippetFirstCondition_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            DataRow startsWith = contacts.AsEnumerable().
                First(contact => contact.Field<string>("EmailAddress").StartsWith("caroline"));

            Console.WriteLine($"An email address starting with 'caroline': {startsWith.Field<string>("EmailAddress")}");
            //</SnippetFirstCondition_MQ>
        }

        /*[Category("Element Operators")]
        [Title("ElementAt")]
        [Description("This example uses ElementAt to retrieve the fifth address where PostalCode == "M4B 1V7" .")]*/
        static void ElementAt()
        {
            //<SnippetElementAt>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable addresses = ds.Tables["Address"];

            var fifthAddress = (
                from address in addresses.AsEnumerable()
                where address.Field<string>("PostalCode") == "M4B 1V7"
                select address.Field<string>("AddressLine1"))
            .ElementAt(5);

            Console.WriteLine($"Fifth address where PostalCode = 'M4B 1V7': {fifthAddress}");
            //</SnippetElementAt>
        }

        #endregion

        #region "Quantifiers"
        /*[Category("Quantifiers")]
        [Title("Any - Grouped")]
        [Description("This example uses Any to return a price grouped by color, where list price is 0.")]*/
        static void AnyGrouped_MQ()
        {
            //<SnippetAnyGrouped_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            var query =
                from product in products.AsEnumerable()
                group product by product.Field<string>("Color") into g
                where g.Any(product => product.Field<decimal>("ListPrice") == 0)
                select new { Color = g.Key, Products = g };

            foreach (var productGroup in query)
            {
                Console.WriteLine(productGroup.Color);
                foreach (var product in productGroup.Products)
                {
                    Console.WriteLine("\t {0}, {1}",
                        product.Field<string>("Name"),
                        product.Field<decimal>("ListPrice"));
                }
            }
            //</SnippetAnyGrouped_MQ>
        }

        /*[Category("Quantifiers")]
        [Title("All - Grouped")]
        [Description("This example uses All to return all products where list price is greater than 0, grouped by color.")]*/
        static void AllGrouped_MQ()
        {
            //<SnippetAllGrouped_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            var query =
                from product in products.AsEnumerable()
                group product by product.Field<string>("Color") into g
                where g.All(product => product.Field<decimal>("ListPrice") > 0)
                select new { Color = g.Key, Products = g };

            foreach (var productGroup in query)
            {
                Console.WriteLine(productGroup.Color);
                foreach (var product in productGroup.Products)
                {
                    Console.WriteLine("\t {0}, {1}",
                        product.Field<string>("Name"),
                        product.Field<decimal>("ListPrice"));
                }
            }
            //</SnippetAllGrouped_MQ>
        }
        #endregion

        #region "Aggregate Operators"

        /*[Category("Aggregate Operators")]
        [Title("Aggregate")]
        [Description("This example gets the first 5 contacts from the Contact table and builds a comma-delimited list of the last names.")]*/
        static void Aggregate_MQ()
        {
            //<SnippetAggregate_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            IEnumerable<DataRow> contacts = ds.Tables["Contact"].AsEnumerable();

            string nameList =
                contacts.Take(5).Select(contact => contact.Field<string>("LastName")).Aggregate((workingList, next) => workingList + "," + next);

            Console.WriteLine(nameList);
            //</SnippetAggregate_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Average")]
        [Description("This example uses Average to find the average list price of the products.")]*/
        static void Average_MQ()
        {
            //<SnippetAverage_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            var products = ds.Tables["Product"].AsEnumerable();

            Decimal averageListPrice =
                products.Average(product => product.Field<Decimal>("ListPrice"));

            Console.WriteLine($"The average list price of all the products is ${averageListPrice}");
            //</SnippetAverage_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Average2")]
        [Description("This example uses Average to find the average list price of the products of each style.")]*/
        static void Average2_MQ()
        {
            //<SnippetAverage2_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            var products = ds.Tables["Product"].AsEnumerable();

            var query = from product in products
                        group product by product.Field<string>("Style") into g
                        select new
                        {
                            Style = g.Key,
                            AverageListPrice =
                                g.Average(product => product.Field<Decimal>("ListPrice"))
                        };

            foreach (var product in query)
            {
                Console.WriteLine($"Product style: {product.Style} Average list price: {product.AverageListPrice}");
            }
            //</SnippetAverage2_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Count")]
        [Description("This example uses Count to return the number of products in the Product table.")]*/
        static void Count()
        {
            //<SnippetCount>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            var products = ds.Tables["Product"].AsEnumerable();

            int numProducts = products.Count();

            Console.WriteLine($"There are {numProducts} products.");
            //</SnippetCount>
        }

        /*[Category("Aggregate Operators")]
        [Title("Count - Nested")]
        [Description("This example uses Count to return a list of contact IDs and how many orders " +
                     "each has.")]*/
        static void CountNested()
        {
            //<SnippetCountNested>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            var query = from contact in contacts.AsEnumerable()
                        select new
                        {
                            CustomerID = contact.Field<int>("ContactID"),
                            OrderCount =
                                contact.GetChildRows("SalesOrderContact").Count()
                        };

            foreach (var contact in query)
            {
                Console.WriteLine($"CustomerID = {contact.CustomerID} \t OrderCount = {contact.OrderCount}");
            }
            //</SnippetCountNested>
        }

        /*[Category("Aggregate Operators")]
        [Title("Count - Grouped")]
        [Description("This example groups products by color and uses Count to return the number of products " +
                     "in each color group.")]*/
        static void CountGrouped()
        {
            //<SnippetCountGrouped>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            var query =
                from product in products.AsEnumerable()
                group product by product.Field<string>("Color") into g
                select new { Color = g.Key, ProductCount = g.Count() };

            foreach (var product in query)
            {
                Console.WriteLine($"Color = {product.Color} \t ProductCount = {product.ProductCount}");
            }
            //</SnippetCountGrouped>
        }

        /*[Category("Aggregate Operators")]
        [Title("Long Count Simple")]
        [Description("Gets the contact count as a long integer.")]*/
        static void LongCountSimple()
        {
            //<SnippetLongCountSimple>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];

            long numberOfContacts = contacts.AsEnumerable().LongCount();
            Console.WriteLine($"There are {numberOfContacts} Contacts");
            //</SnippetLongCountSimple>
        }

        /*[Category("Aggregate Operators")]
        [Title("Sum - Projection")]
        [Description("This example uses Sum to get the total number of order quantities in the SalesOrderDetail table.")]*/
        static void SumProjection_MQ()
        {
            //<SnippetSumProjection_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderDetail"];

            double totalOrderQty = orders.AsEnumerable().
                Sum(o => o.Field<Int16>("OrderQty"));
            Console.WriteLine($"There are a total of {totalOrderQty} OrderQty.");
            //</SnippetSumProjection_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Sum - Grouped")]
        [Description("This example uses Sum to get the total due for each contact ID.")]*/
        static void SumGrouped_MQ()
        {
            //<SnippetSumGrouped_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from order in orders.AsEnumerable()
                group order by order.Field<Int32>("ContactID") into g
                select new
                {
                    Category = g.Key,
                    TotalDue = g.Sum(order => order.Field<decimal>("TotalDue")),
                };
            foreach (var order in query)
            {
                Console.WriteLine($"ContactID = {order.Category} \t TotalDue sum = {order.TotalDue}");
            }
            //</SnippetSumGrouped_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Min - Projection")]
        [Description("This example uses Min to get the smallest total due.")]*/
        static void MinProjection_MQ()
        {
            //<SnippetMinProjection_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            Decimal smallestTotalDue = orders.AsEnumerable().
                Min(totalDue => totalDue.Field<decimal>("TotalDue"));
            Console.WriteLine($"The smallest TotalDue is {smallestTotalDue}.");
            //</SnippetMinProjection_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Min - Grouped")]
        [Description("This example uses Min to get the smallest total due for each contact ID.")]*/
        static void MinGrouped_MQ()
        {
            //<SnippetMinGrouped_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from order in orders.AsEnumerable()
                group order by order.Field<Int32>("ContactID") into g
                select new
                {
                    Category = g.Key,
                    smallestTotalDue =
                        g.Min(order => order.Field<decimal>("TotalDue"))
                };

            foreach (var order in query)
            {
                Console.WriteLine($"ContactID = {order.Category} \t Minimum TotalDue = {order.smallestTotalDue}");
            }
            //</SnippetMinGrouped_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Min - Elements")]
        [Description("This example uses Min to get the orders with the smallest total due for each contact.")]*/
        static void MinElements_MQ()
        {
            //<SnippetMinElements_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from order in orders.AsEnumerable()
                group order by order.Field<Int32>("ContactID") into g
                let minTotalDue = g.Min(order => order.Field<decimal>("TotalDue"))
                select new
                {
                    Category = g.Key,
                    smallestTotalDue =
                        g.Where(order => order.Field<decimal>("TotalDue") ==
                                    minTotalDue)
                };

            foreach (var orderGroup in query)
            {
                Console.WriteLine($"ContactID: {orderGroup.Category}");
                foreach (var order in orderGroup.smallestTotalDue)
                {
                    Console.WriteLine($"Minimum TotalDue {order.Field<decimal>("TotalDue")} for SalesOrderID {order.Field<Int32>("SalesOrderID")}: ");
                }
                Console.WriteLine("");
            }
            //</SnippetMinElements_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Average - Projection")]
        [Description("This example uses Average to find the average total due.")]*/
        static void AverageProjection_MQ()
        {
            //<SnippetAverageProjection_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            Decimal averageTotalDue = orders.AsEnumerable().
                Average(order => order.Field<decimal>("TotalDue"));
            Console.WriteLine($"The average TotalDue is {averageTotalDue}.");
            //</SnippetAverageProjection_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Average - Grouped")]
        [Description("This example uses Average to get the average total due for each contact ID.")]*/
        static void AverageGrouped_MQ()
        {
            //<SnippetAverageGrouped_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from order in orders.AsEnumerable()
                group order by order.Field<Int32>("ContactID") into g
                select new
                {
                    Category = g.Key,
                    averageTotalDue =
                        g.Average(order => order.Field<decimal>("TotalDue"))
                };

            foreach (var order in query)
            {
                Console.WriteLine($"ContactID = {order.Category} \t Average TotalDue = {order.averageTotalDue}");
            }
            //</SnippetAverageGrouped_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Average - Elements")]
        [Description("This example uses Average to get the orders with the average TotalDue for each contact.")]*/
        static void AverageElements_MQ()
        {
            //<SnippetAverageElements_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from order in orders.AsEnumerable()
                group order by order.Field<Int32>("ContactID") into g
                let averageTotalDue = g.Average(order => order.Field<decimal>("TotalDue"))
                select new
                {
                    Category = g.Key,
                    CheapestProducts =
                        g.Where(order => order.Field<decimal>("TotalDue") ==
                                    averageTotalDue)
                };

            foreach (var orderGroup in query)
            {
                Console.WriteLine($"ContactID: {orderGroup.Category}");
                foreach (var order in orderGroup.CheapestProducts)
                {
                    Console.WriteLine($"Average total due for SalesOrderID {order.Field<Int32>("SalesOrderID")} is: {order.Field<decimal>("TotalDue")}");
                }
                Console.WriteLine("");
            }
            //</SnippetAverageElements_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Max - Projection")]
        [Description("This example uses Max to get the largest total due.")]*/
        static void MaxProjection_MQ()
        {
            //<SnippetMaxProjection_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            Decimal maxTotalDue = orders.AsEnumerable().
                Max(w => w.Field<decimal>("TotalDue"));
            Console.WriteLine($"The maximum TotalDue is {maxTotalDue}.");
            //</SnippetMaxProjection_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Max - Grouped")]
        [Description("This example uses Max to get the largest total due for each contact ID.")]*/
        static void MaxGrouped_MQ()
        {
            //<SnippetMaxGrouped_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from order in orders.AsEnumerable()
                group order by order.Field<Int32>("ContactID") into g
                select new
                {
                    Category = g.Key,
                    maxTotalDue =
                        g.Max(order => order.Field<decimal>("TotalDue"))
                };

            foreach (var order in query)
            {
                Console.WriteLine($"ContactID = {order.Category} \t Maximum TotalDue = {order.maxTotalDue}");
            }
            //</SnippetMaxGrouped_MQ>
        }

        /*[Category("Aggregate Operators")]
        [Title("Max - Elements")]
        [Description("This example uses Max to get the orders with the largest TotalDue for each contact ID.")]*/
        static void MaxElements_MQ()
        {
            //<SnippetMaxElements_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from order in orders.AsEnumerable()
                group order by order.Field<Int32>("ContactID") into g
                let maxTotalDue = g.Max(order => order.Field<decimal>("TotalDue"))
                select new
                {
                    Category = g.Key,
                    CheapestProducts =
                        g.Where(order => order.Field<decimal>("TotalDue") ==
                                    maxTotalDue)
                };

            foreach (var orderGroup in query)
            {
                Console.WriteLine($"ContactID: {orderGroup.Category}");
                foreach (var order in orderGroup.CheapestProducts)
                {
                    Console.WriteLine($"MaxTotalDue {order.Field<decimal>("TotalDue")} for SalesOrderID {order.Field<Int32>("SalesOrderID")}: ");
                }
            }
            //</SnippetMaxElements_MQ>
        }
        #endregion

        #region "Join Operators"

        /*[Category("Join Operators")]
        [Title("Join ")]
        [Description("This example performs a join over the SalesOrderHeader and SalesOrderDetail tables to get online orders from the month of August.")]*/
        static void Join()
        {
            //<SnippetJoin>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];
            DataTable details = ds.Tables["SalesOrderDetail"];

            var query =
                from order in orders.AsEnumerable()
                join detail in details.AsEnumerable()
                on order.Field<int>("SalesOrderID") equals
                    detail.Field<int>("SalesOrderID")
                where order.Field<bool>("OnlineOrderFlag") == true
                && order.Field<DateTime>("OrderDate").Month == 8
                select new
                {
                    SalesOrderID =
                        order.Field<int>("SalesOrderID"),
                    SalesOrderDetailID =
                        detail.Field<int>("SalesOrderDetailID"),
                    OrderDate =
                        order.Field<DateTime>("OrderDate"),
                    ProductID =
                        detail.Field<int>("ProductID")
                };

            foreach (var order in query)
            {
                Console.WriteLine($"{order.SalesOrderID}\t{order.SalesOrderDetailID}\t{order.OrderDate:d}\t{order.ProductID}");
            }
            //</SnippetJoin>
        }

        /*[Category("Join Operators")]
        [Title("Join - simple")]
        [Description("This example performs a join over the Contact and SalesOrderHeader tables.")]*/
        static void JoinSimple_MQ()
        {
            //<SnippetJoinSimple_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                contacts.AsEnumerable().Join(orders.AsEnumerable(),
                order => order.Field<Int32>("ContactID"),
                contact => contact.Field<Int32>("ContactID"),
                (contact, order) => new
                {
                    ContactID = contact.Field<Int32>("ContactID"),
                    SalesOrderID = order.Field<Int32>("SalesOrderID"),
                    FirstName = contact.Field<string>("FirstName"),
                    Lastname = contact.Field<string>("Lastname"),
                    TotalDue = order.Field<decimal>("TotalDue")
                });

            foreach (var contact_order in query)
            {
                Console.WriteLine($"ContactID: {contact_order.ContactID} "
                                + "SalesOrderID: {contact_order.SalesOrderID} "
                                + "FirstName: {contact_order.FirstName} "
                                + "Lastname: {contact_order.Lastname} "
                                + "TotalDue: {contact_order.TotalDue}");
            }
            //</SnippetJoinSimple_MQ>
        }

        /*[Category("Join Operators")]
        [Title("Join with grouped results")]
        [Description("This example performs a join over the Contact and SalesOrderHeader tables, grouping the results by contact ID.")]*/
        static void JoinWithGroupedResults_MQ()
        {
            //<SnippetJoinWithGroupedResults_MQ>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query = contacts.AsEnumerable().Join(orders.AsEnumerable(),
                order => order.Field<Int32>("ContactID"),
                contact => contact.Field<Int32>("ContactID"),
                (contact, order) => new
                {
                    ContactID = contact.Field<Int32>("ContactID"),
                    SalesOrderID = order.Field<Int32>("SalesOrderID"),
                    FirstName = contact.Field<string>("FirstName"),
                    Lastname = contact.Field<string>("Lastname"),
                    TotalDue = order.Field<decimal>("TotalDue")
                })
                    .GroupBy(record => record.ContactID);

            foreach (var group in query)
            {
                foreach (var contact_order in group)
                {
                    Console.WriteLine($"ContactID: {contact_order.ContactID} "
                                    + "SalesOrderID: {contact_order.SalesOrderID} "
                                    + "FirstName: {contact_order.FirstName} "
                                    + "Lastname: {contact_order.Lastname} "
                                    + "TotalDue: {contact_order.TotalDue}");
                }
            }
            //</SnippetJoinWithGroupedResults_MQ>
        }

        /*[Category("Join Operators")]
        [Title("GroupJoin2")]
        [Description("This example performs a GroupJoin over the SalesOrderHeader and SalesOrderDetail tables to find the number of orders per customer. " +
          "A group join is the equivalent of a left outer join, which returns each element of the first (left) data source, " +
          "even if no correlated elements are in the other data source.")]*/
        static void GroupJoin2()
        {
            //<SnippetGroupJoin2>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            var orders = ds.Tables["SalesOrderHeader"].AsEnumerable();
            var details = ds.Tables["SalesOrderDetail"].AsEnumerable();

            var query =
                from order in orders
                join detail in details
                on order.Field<int>("SalesOrderID")
                equals detail.Field<int>("SalesOrderID") into ords
                select new
                {
                    CustomerID =
                        order.Field<int>("SalesOrderID"),
                    ords = ords.Count()
                };

            foreach (var order in query)
            {
                Console.WriteLine($"CustomerID: {order.CustomerID}  Orders Count: {order.ords}");
            }
            //</SnippetGroupJoin2>
        }
        /*[Category("Join Operators")]
        [Title("GroupJoin")]
        [Description("This example performs a group join over the Contact and SalesOrderHeader tables. " +
         "A group join is the equivalent of a left outer join, which returns each element of the first (left) data source, " +
          "even if no correlated elements are in the other data source.")]*/
        static void GroupJoin()
        {
            //<SnippetGroupJoin>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from contact in contacts.AsEnumerable()
                join order in orders.AsEnumerable()
                on contact.Field<Int32>("ContactID") equals
                order.Field<Int32>("ContactID")
                select new
                {
                    ContactID = contact.Field<Int32>("ContactID"),
                    SalesOrderID = order.Field<Int32>("SalesOrderID"),
                    FirstName = contact.Field<string>("FirstName"),
                    Lastname = contact.Field<string>("Lastname"),
                    TotalDue = order.Field<decimal>("TotalDue")
                };

            foreach (var contact_order in query)
            {
                Console.WriteLine($"ContactID: {contact_order.ContactID} "
                                + "SalesOrderID: {contact_order.SalesOrderID} "
                                + "FirstName: {contact_order.FirstName} "
                                + "Lastname: {contact_order.Lastname} "
                                + "TotalDue: {contact_order.TotalDue}");
            }
            //</SnippetGroupJoin>
        }
        #endregion

        #region "DataSet Loading examples"
        /*[Category("DataSet Loading examples")]
        [Title("Loading query results into a DataTable")]
        [Description("This example creates and loads a DataTable from a sequence. A new table is created and filled manually, " +
          "instead of using the CopyToDataTable() method, because of the projection in the query.")]*/
        static void LoadingQueryResultsIntoDataTable()
        {
            //<SnippetLoadingQueryResultsIntoDataTable>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts = ds.Tables["Contact"];
            DataTable orders = ds.Tables["SalesOrderHeader"];

            var query =
                from contact in contacts.AsEnumerable()
                from order in orders.AsEnumerable()
                where contact.Field<Int32>("ContactID") == order.Field<Int32>("ContactID") &&
                    order.Field<bool>("OnlineOrderFlag") == true
                select new
                {
                    FirstName = (string)contact["FirstName"],
                    LastName = (string)contact["LastName"],
                    OrderDate = (DateTime)order["OrderDate"],
                    TotalDue = (decimal)order["TotalDue"]
                };

            DataTable OnlineOrders = new DataTable();
            OnlineOrders.Locale = CultureInfo.InvariantCulture;
            OnlineOrders.Columns.Add("FirstName", typeof(string));
            OnlineOrders.Columns.Add("LastName", typeof(string));
            OnlineOrders.Columns.Add("OrderDate", typeof(DateTime));
            OnlineOrders.Columns.Add("TotalDue", typeof(decimal));

            foreach (var result in query.Take(10))
            {
                OnlineOrders.Rows.Add(new object[] {
                                      result.FirstName,
                                      result.LastName,
                                      result.OrderDate,
                                      result.TotalDue });
            }

            foreach (DataRow row in OnlineOrders.Rows)
            {
                Console.WriteLine($"First Name: {row["FirstName"]}");
                Console.WriteLine($"Last Name:  {row["LastName"]}");
                Console.WriteLine($"Order Date: {row["OrderDate"]}");
                Console.WriteLine($"Total Due:  ${row["TotalDue"]}");
                Console.WriteLine("");
            }
            //</SnippetLoadingQueryResultsIntoDataTable>
        }

        /*[Category("DataSet Loading examples")]
        [Title("Using CopyToDataTable")]
        [Description("This example loads a DataTable with query results by using the CopyToDataTable() method.")]*/
        static void LoadDataTableWithQueryResults()
        {
            //<SnippetLoadDataTableWithQueryResults>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable contacts1 = ds.Tables["Contact"];

            IEnumerable<DataRow> query =
                from contact in contacts1.AsEnumerable()
                where contact.Field<string>("Title") == "Ms."
                    && contact.Field<string>("FirstName") == "Carla"
                select contact;

            DataTable contacts2 = query.CopyToDataTable();

            foreach (DataRow contact in contacts2.AsEnumerable())
            {
                Console.WriteLine("ID:{0} Name: {1}, {2}",
                    contact.Field<Int32>("ContactID"),
                    contact.Field<string>("LastName"),
                    contact.Field<string>("FirstName"));
            }
            //</SnippetLoadDataTableWithQueryResults>
        }

        static void CopyToDataTable1()
        {
            DataGridView dataGridView = new DataGridView();
            BindingSource bindingSource = new BindingSource();

            //<SnippetCopyToDataTable1>
            // Bind the System.Windows.Forms.DataGridView object
            // to the System.Windows.Forms.BindingSource object.
            dataGridView.DataSource = bindingSource;

            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];

            // Query the SalesOrderHeader table for orders placed
            // after August 8, 2001.
            IEnumerable<DataRow> query =
                from order in orders.AsEnumerable()
                where order.Field<DateTime>("OrderDate") > new DateTime(2001, 8, 1)
                select order;

            // Create a table from the query.
            DataTable boundTable = query.CopyToDataTable<DataRow>();

            // Bind the table to a System.Windows.Forms.BindingSource object,
            // which acts as a proxy for a System.Windows.Forms.DataGridView object.
            bindingSource.DataSource = boundTable;
            //</SnippetCopyToDataTable1>

            foreach (DataRow row in boundTable.Rows)
            {
                Console.WriteLine(row["SalesOrderNumber"] + " " + row["OrderDate"]);
            }
        }
        #endregion

        #region "DataRowComparer examples"
        /*[Category("DataRowComparer examples")]
        [Title("Compare different data rows")]
        [Description("This example compares two different data rows.")]*/

        static void CompareDifferentDataRows()
        {
            // <SnippetCompareDifferentDataRows>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            // Get two rows from the SalesOrderHeader table.
            DataTable table = ds.Tables["SalesOrderHeader"];
            DataRow left = (DataRow)table.Rows[0];
            DataRow right = (DataRow)table.Rows[1];

            // Compare the two different rows.
            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;

            bool bEqual = comparer.Equals(left, right);
            if (bEqual)
                Console.WriteLine("The two rows are equal");
            else
                Console.WriteLine("The two rows are not equal");

            // Get the hash codes of the two rows.
            Console.WriteLine("The hashcodes for the two rows are {0}, {1}",
                comparer.GetHashCode(left),
                comparer.GetHashCode(right));
            // </SnippetCompareDifferentDataRows>
        }

        /*[Category("DataRowComparer examples")]
        [Title("Compare equal data rows")]
        [Description("This example compares two equal data rows.")]*/
        static void CompareEqualDataRows()
        {
            // <SnippetCompareEqualDataRows>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            // Get a row from the SalesOrderHeader table.
            DataTable table = ds.Tables["SalesOrderHeader"];
            DataRow left = (DataRow)table.Rows[0];
            DataRow right = (DataRow)table.Rows[0];

            // Compare two equal rows.
            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;

            bool bEqual = comparer.Equals(left, right);
            if (bEqual)
                Console.WriteLine("The two rows are equal");
            else
                Console.WriteLine("The two rows are not equal");

            // Get the hash codes of the two rows.
            Console.WriteLine("The hashcodes for the two rows are {0}, {1}",
                comparer.GetHashCode(left),
                comparer.GetHashCode(right));
            // </SnippetCompareEqualDataRows>
        }

        /*[Category("DataRowComparer examples")]
        [Title("Compare null data row")]
        [Description("This example compares a data row with a null value.")]*/
        static void CompareNullDataRows()
        {
            // <SnippetCompareNullDataRows>
            // Compare with null.
            DataTable table = new DataTable();
            table.Locale = CultureInfo.InvariantCulture;
            DataRow dr = table.NewRow();

            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;

            try
            {
                comparer.Equals(null, dr);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException is thrown if parameter is null");
            }
            // </SnippetCompareNullDataRows>
        }
        #endregion

        #region Misc

        static void Composing()
        {
            //<SnippetComposing>
            // Fill the DataSet.
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable products = ds.Tables["Product"];

            IEnumerable<DataRow> productsQuery =
                from product in products.AsEnumerable()
                select product;

            IEnumerable<DataRow> largeProducts =
                productsQuery.Where(p => p.Field<string>("Size") == "L");

            Console.WriteLine("Products of size 'L':");
            foreach (DataRow product in largeProducts)
            {
                Console.WriteLine(product.Field<string>("Name"));
            }

            //</SnippetComposing>
        }

        #endregion

        // Leftovers...

        static void OrderBy(DataSet ds)
        {
            // <SnippetOrderBy>
            DataTable orders = ds.Tables["SalesOrderDetail"];

            // Order by unit price.
            var query =
                from order in orders.AsEnumerable()
                where order.Field<Int16>("OrderQty") > 2 &&
                    order.Field<Int16>("OrderQty") < 6
                orderby order.Field<Decimal>("UnitPrice")
                select new
                {
                    SalesOrderID = (int)order.Field<int>("SalesOrderID"),
                    OrderQty = order.Field<Int16>("OrderQty"),
                    UnitPrice = order.Field<Decimal>("UnitPrice")
                };

            foreach (var order in query)
            {
                Console.WriteLine($"{order.SalesOrderID}\t{order.OrderQty}\t{order.UnitPrice}");
            }
            // </SnippetOrderBy>
        }

        static void OrderByDescending(DataSet ds)
        {
            // <SnippetOrderByDescending>
            DataTable orders = ds.Tables["SalesOrderDetail"];

            // Order by unit price.
            var query =
                from order in orders.AsEnumerable()
                where order.Field<Int16>("OrderQty") > 2 &&
                    order.Field<Int16>("OrderQty") < 6
                orderby order.Field<Decimal>("UnitPrice") descending
                select new
                {
                    SalesOrderID = (int)order.Field<int>("SalesOrderID"),
                    OrderQty = order.Field<Int16>("OrderQty"),
                    UnitPrice = order.Field<Decimal>("UnitPrice")
                };

            foreach (var order in query)
            {
                Console.WriteLine($"{order.SalesOrderID}\t{order.OrderQty}\t{order.UnitPrice}");
            }
            // </SnippetOrderByDescending>
        }

        static void GroupBy(DataSet ds)
        {
            DataTable products = ds.Tables["Product"];

            // Group by size.
            var query =
                from product in products.AsEnumerable()
                group product by product.Field<string>("Size") into g
                select new
                {
                    Category = g.Key,
                    Products = g
                };

            foreach (var productGroup in query)
            {
                Console.WriteLine($"{productGroup.Category}:");
                foreach (var product in productGroup.Products)
                {
                    Console.WriteLine($"  Name: {product.Field<string>("Name")} Color: {product.Field<string>("Color")}");
                    Console.WriteLine($"  List price: {product.Field<Decimal>("ListPrice")} Size: {product.Field<string>("Size")}");
                }
            }
        }

        static void Sum(DataSet ds)
        {
            var orders = ds.Tables["SalesOrderHeader"].AsEnumerable();

            Decimal totalDue = orders.Sum(o => o.Field<Decimal>("TotalDue"));

            Console.WriteLine($"Sum of order amounts: ${totalDue}");
        }

        static void Sum2(DataSet ds)
        {
            var employees = ds.Tables["Employee"].AsEnumerable();

            var empSickLeaveHours =
                from e in employees
                group e by e.Field<string>("Title") into g
                select new
                {
                    Category = g.Key,
                    TotalSickLeaveHours =
                        g.Sum(p => p.Field<Int16>("SickLeaveHours"))
                };

            foreach (var emp in empSickLeaveHours)
            {
                Console.WriteLine($"Category: {emp.Category} Units sold: {emp.TotalSickLeaveHours}");
            }
        }

        // Display DataSet info. This will not be used in the docs.
        static void DSInfo(DataSet ds)
        {
            Console.WriteLine("DataSet info:");
            foreach (DataTable t in ds.Tables)
            {
                Console.WriteLine($"Table name: {t.TableName}");
                Console.WriteLine($"Number of rows: {t.Rows.Count}");

                foreach (DataColumn c in t.Columns)
                {
                    Console.WriteLine("Column name: {0}, Type {1}",
                        c.ColumnName, c.DataType);
                }

                Console.WriteLine("");
            }
        }

        static void FillDataSet(DataSet ds)
        {
            try
            {
                // Create a new adapter and give it a query to fetch sales order, contact,
                // address, and product information for sales in the year 2002.
                string connectionString = "some secure connection string";

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT SalesOrderID, ContactID, OrderDate, OnlineOrderFlag, " +
                    "TotalDue, SalesOrderNumber, Status, ShipToAddressID, BillToAddressID " +
                    "FROM Sales.SalesOrderHeader " +
                    "WHERE DATEPART(YEAR, OrderDate) = @year; " +

                    "SELECT d.SalesOrderID, d.SalesOrderDetailID, d.OrderQty, " +
                    "d.ProductID, d.UnitPrice " +
                    "FROM Sales.SalesOrderDetail d " +
                    "INNER JOIN Sales.SalesOrderHeader h " +
                    "ON d.SalesOrderID = h.SalesOrderID  " +
                    "WHERE DATEPART(YEAR, OrderDate) = @year; " +

                    "SELECT p.ProductID, p.Name, p.ProductNumber, p.MakeFlag, " +
                    "p.Color, p.ListPrice, p.Size, p.Class, p.Style, p.Weight  " +
                    "FROM Production.Product p; " +

                    "SELECT DISTINCT a.AddressID, a.AddressLine1, a.AddressLine2, " +
                    "a.City, a.StateProvinceID, a.PostalCode " +
                    "FROM Person.Address a " +
                    "INNER JOIN Sales.SalesOrderHeader h " +
                    "ON  a.AddressID = h.ShipToAddressID OR a.AddressID = h.BillToAddressID " +
                    "WHERE DATEPART(YEAR, OrderDate) = @year; " +

                    "SELECT DISTINCT c.ContactID, c.Title, c.FirstName, " +
                    "c.LastName, c.EmailAddress, c.Phone " +
                    "FROM Person.Contact c " +
                    "INNER JOIN Sales.SalesOrderHeader h " +
                    "ON c.ContactID = h.ContactID " +
                    "WHERE DATEPART(YEAR, OrderDate) = @year;",
                connectionString);

                // Add table mappings.
                da.SelectCommand.Parameters.AddWithValue("@year", 2002);
                da.TableMappings.Add("Table", "SalesOrderHeader");
                da.TableMappings.Add("Table1", "SalesOrderDetail");
                da.TableMappings.Add("Table2", "Product");
                da.TableMappings.Add("Table3", "Address");
                da.TableMappings.Add("Table4", "Contact");

                // Fill the DataSet.
                da.Fill(ds);

                // Add data relations.
                DataTable orderHeader = ds.Tables["SalesOrderHeader"];
                DataTable orderDetail = ds.Tables["SalesOrderDetail"];
                DataRelation order = new DataRelation("SalesOrderHeaderDetail",
                                         orderHeader.Columns["SalesOrderID"],
                                         orderDetail.Columns["SalesOrderID"], true);
                ds.Relations.Add(order);

                DataTable contact = ds.Tables["Contact"];
                DataTable orderHeader2 = ds.Tables["SalesOrderHeader"];
                DataRelation orderContact = new DataRelation("SalesOrderContact",
                                                contact.Columns["ContactID"],
                                                orderHeader2.Columns["ContactID"], true);
                ds.Relations.Add(orderContact);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL exception occurred: " + ex.Message);
            }
        }

        static void WriteSchemaToXSD(DataSet ds)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter("ProductSalesSchema.xsd");
            ds.WriteXmlSchema(writer);
            writer.Close();
            Console.WriteLine("Schema written.");
        }
    }
}
