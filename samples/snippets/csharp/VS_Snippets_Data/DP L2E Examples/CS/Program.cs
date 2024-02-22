// <SnippetImportsUsing>
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;
// </SnippetImportsUsing>

namespace L2E_ExamplesCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //*** Projection Operators ***//
            LINQEntityTypeCollection();
            //SelectSimple1();
            // SelectSimple2();
            // SelectSimple2_MQ();
            //SelectAnonymousTypes();
            // SelectAnonymousTypes_MQ();
            // SelectManyCompoundFrom(); // Needs work.  Nav prop used correctly?
            // SelectManyCompoundFrom_MQ();
            // SelectManyCompoundFrom2();
            //SelectManyCompoundFrom2_MQ();
            //SelectManyFromAssignment();

            //CompoundFrom1_MQ(); // Needs work  //ML - Not sure which one this is supposed to be?

            //*** Restriction operators ***//
            // Where1();
            // Where1_MQ();
            // Where2();
            // Where2_MQ();
            // Where3();
            // Where3_MQ();
            // WhereNavProperty();
            // WhereNavProperty_MQ();
            // WhereDrilldown();

            /*** Partitioning Operators ***/
            //TakeSimple();
            //SkipSimple();
            //TakeNested();
            //SkipNested();
            //TakeWhileSimple_MQ();  // TakeWhile not supported in L2E
            //SkipWhileSimple_MQ();    // SkipWhile not supported in L2E

            //*** Ordering Operators ***//
            //OrderBySimple1();
            //OrderBySimple1_MQ();
            //OrderByThenBy();
            //OrderByThenBy_MQ();
            //OrderBySimple2();
            //OrderByDescendingSimple1();
            //OrderByDescendingSimple1_MQ();
            //ThenByDescendingSimple();
            //ThenByDescending_MQ();
            //Reverse();  // Reverse not supported in L2E

            /*** Grouping Operators ***/
            //GroupBySimple2();
            //GroupBySimple2_MQ();
            //GroupBySimple3();
            //GroupBySimple3_MQ();
            //GroupByCount();
           // GroupByCount_MQ();
            //GroupByNested(); //Needs work. Don't know how to mimic SalesOrderContact DataRelation object.

            //*** Set Operators ***//
            // Except1();   // Not working... //Kludged Enumerable static method. //Same as Except2 in L2DS.
            // Except1_MQ();  // Not working...
            //Union2();
            //Union1();    // Not working... //ditto - kludged  //Same as Union2 in L2DS samples
            //Union1_MQ();  // Not working...
            // Intersect1(); // Not working... //ditto - kludged  //Same as Interset2 in L2DS samples
            // Intersect1_MQ();// Not working...
            //DistinctRows(); //Fails at runtime!

            /*** Conversion Operators ***/
            //ToArray();  //Streamlined code
            //ToList();   //Streamlined code
            //ToDictionary();

            /*** Element Operators ***/
            //FirstSimple();
            //FirstCondition_MQ();
            //ElementAt();  // ElementAt not supported by L2E.

            /*** Quantifier Operators ***/
            //AnyGrouped_MQ();
            //AllGrouped_MQ();

            /*** Aggregate Operators ***/
            //Aggregate_MQ();  //Aggregate not supported in L2E?
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
            //MaxElements_MQ();

            /*** Join Operators ***/
            //Join();
            //JoinSimple_MQ();
            //JoinWithGroupedResults_MQ();  //Times out.
            // GroupJoin();
            //GroupJoin_MQ();
            //GroupJoin2();
            //GroupJoin2_MQ();

            /*** Relationship Navigation***/
            //SelectEachContactsOrders_MQ();
            //SelectEachContactsOrders2();
            //SelectEachContactsOrders2_MQ();
            //SelectEachContactsOrders3();
            //SelectEachContactsOrders3_MQ();
            //GetOrderInfoThruRelationships();
            //GetOrderInfoThruRelationships_MQ();

            //Hit enter...
            Console.WriteLine("hit enter...");
            Console.Read();
        }

        # region Projection Operators
        static void SelectSimple1()
        {
            // <SnippetSelectSimple1>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Product> productsQuery = from product in context.Products
                                                    select product;

                Console.WriteLine("Product Names:");
                foreach (var prod in productsQuery)
                {
                    Console.WriteLine(prod.Name);
                }
            }
            // </SnippetSelectSimple1>
        }

        static void SelectSimple2()
        {
            // <SnippetSelectSimple2>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<string> productNames =
                    from p in context.Products
                    select p.Name;

                Console.WriteLine("Product Names:");
                foreach (String productName in productNames)
                {
                    Console.WriteLine(productName);
                }
            }
            // </SnippetSelectSimple2>
        }

        static void SelectSimple2_MQ()
        {
            // <SnippetSelectSimple2_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<string> productNames = context.Products
                    .Select(p => p.Name);

                Console.WriteLine("Product Names:");
                foreach (String productName in productNames)
                {
                    Console.WriteLine(productName);
                }
            }
            // </SnippetSelectSimple2_MQ>
        }

        static void SelectAnonymousTypes()
        {
            // <SnippetSelectAnonymousTypes>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query =
                    from product in context.Products
                    select new
                    {
                        ProductId = product.ProductID,
                        ProductName = product.Name
                    };

                Console.WriteLine("Product Info:");
                foreach (var productInfo in query)
                {
                    Console.WriteLine("Product Id: {0} Product name: {1} ",
                        productInfo.ProductId, productInfo.ProductName);
                }
            }
            // </SnippetSelectAnonymousTypes>
        }

        static void SelectAnonymousTypes_MQ()
        {
            // <SnippetSelectAnonymousTypes_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = context.Products
                    .Select(product => new
                    {
                        ProductId = product.ProductID,
                        ProductName = product.Name
                    });

                Console.WriteLine("Product Info:");
                foreach (var productInfo in query)
                {
                    Console.WriteLine("Product Id: {0} Product name: {1} ",
                        productInfo.ProductId, productInfo.ProductName);
                }
            }
            // </SnippetSelectAnonymousTypes_MQ>
        }

        static void SelectManyCompoundFrom()
        {
            // <SnippetSelectManyCompoundFrom>
            decimal totalDue = 500.00M;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from contact in contacts
                    from order in orders
                    where contact.ContactID == order.Contact.ContactID
                        && order.TotalDue < totalDue
                    select new
                    {
                        ContactID = contact.ContactID,
                        LastName = contact.LastName,
                        FirstName = contact.FirstName,
                        OrderID = order.SalesOrderID,
                        Total = order.TotalDue
                    };

                foreach (var smallOrder in query)
                {
                    Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ",
                        smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName,
                        smallOrder.OrderID, smallOrder.Total);
                }
            }
            // </SnippetSelectManyCompoundFrom>
        }

        static void SelectManyCompoundFrom_MQ()
        {
            // <SnippetSelectManyCompoundFrom_MQ>
            decimal totalDue = 500.00M;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                contacts.SelectMany(
                    contact => orders.Where(order =>
                        (contact.ContactID == order.Contact.ContactID)
                            && order.TotalDue < totalDue)
                        .Select(order => new
                        {
                            ContactID = contact.ContactID,
                            LastName = contact.LastName,
                            FirstName = contact.FirstName,
                            OrderID = order.SalesOrderID,
                            Total = order.TotalDue
                        }));

                foreach (var smallOrder in query)
                {
                    Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ",
                        smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName,
                        smallOrder.OrderID, smallOrder.Total);
                }
            }
            // </SnippetSelectManyCompoundFrom_MQ>
        }

        static void SelectManyCompoundFrom2()
        {
            // <SnippetSelectManyCompoundFrom2>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from contact in contacts
                    from order in orders
                    where contact.ContactID == order.Contact.ContactID
                        && order.OrderDate >= new DateTime(2002, 10, 1)
                    select new
                    {
                        ContactID = contact.ContactID,
                        LastName = contact.LastName,
                        FirstName = contact.FirstName,
                        OrderID = order.SalesOrderID,
                        OrderDate = order.OrderDate
                    };

                foreach (var order in query)
                {
                    Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Order date: {4:d} ",
                        order.ContactID, order.LastName, order.FirstName,
                        order.OrderID, order.OrderDate);
                }
            }
            // </SnippetSelectManyCompoundFrom2>
        }

        static void SelectManyCompoundFrom2_MQ()
        {
            // <SnippetSelectManyCompoundFrom2_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                contacts.SelectMany(
                    contact => orders.Where(order =>
                        (contact.ContactID == order.Contact.ContactID)
                            && order.OrderDate >= new DateTime(2002, 10, 1))
                        .Select(order => new
                        {
                            ContactID = contact.ContactID,
                            LastName = contact.LastName,
                            FirstName = contact.FirstName,
                            OrderID = order.SalesOrderID,
                            OrderDate = order.OrderDate
                        }));

                foreach (var order in query)
                {
                    Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Order date: {4:d} ",
                        order.ContactID, order.LastName, order.FirstName,
                        order.OrderID, order.OrderDate);
                }
            }
            // </SnippetSelectManyCompoundFrom2_MQ>
        }

        static void SelectManyFromAssignment()
        {
            // <SnippetSelectManyFromAssignment>
            decimal totalDue = 10000.0M;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from contact in contacts
                    from order in orders
                    let total = order.TotalDue
                    where contact.ContactID == order.Contact.ContactID
                        && total >= totalDue
                    select new
                    {
                        ContactID = contact.ContactID,
                        LastName = contact.LastName,
                        OrderID = order.SalesOrderID,
                        total
                    };

                foreach (var order in query)
                {
                    Console.WriteLine("Contact ID: {0} Last name: {1} Order ID: {2} Total: {3}",
                        order.ContactID, order.LastName, order.OrderID, order.total);
                }
            }
            // </SnippetSelectManyFromAssignment>
        }

        static void CompoundFrom1_MQ()
        {
            // <SnippetSelectMany1_MQ>
            /* using (AdventureWorksEntities context = new AdventureWorksEntities())
             {
                 var smallOrders = context.SalesOrderHeaders.Where(order => order.TotalDue < 100.00M)
                     .SelectMany(order => order.SalesOrderID);

                 foreach (var smallOrder in smallOrders)
                 {
                     Console.WriteLine("SalesOrderID: " + smallOrder);
                 }

             }*/
            // </SnippetSelectMany1_MQ>
        }
        # endregion

        # region Restriction Operators
        static void LINQEntityTypeCollection()
        {
            //<snippetQueryEntityTypeCollection>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                string LastName = "Zhou";
                var query = from contact in context.Contacts where
                                contact.LastName == LastName select contact;

                // Iterate through the collection of Contact items.
                foreach( var result in query)
                {
                    Console.WriteLine("Contact First Name: {0}; Last Name: {1}",
                            result.FirstName, result.LastName);
                }
            }
            // </snippetQueryEntityTypeCollection>
        }

        static void Where1()
        {
            // <SnippetWhere1>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var onlineOrders =
                    from order in context.SalesOrderHeaders
                    where order.OnlineOrderFlag == true
                    select new
                    {
                        SalesOrderID = order.SalesOrderID,
                        OrderDate = order.OrderDate,
                        SalesOrderNumber = order.SalesOrderNumber
                    };

                foreach (var onlineOrder in onlineOrders)
                {
                    Console.WriteLine("Order ID: {0} Order date: {1:d} Order number: {2}",
                        onlineOrder.SalesOrderID,
                        onlineOrder.OrderDate,
                        onlineOrder.SalesOrderNumber);
                }
            }
            // </SnippetWhere1>
        }

        static void Where1_MQ()
        {
            // <SnippetWhere1_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var onlineOrders = context.SalesOrderHeaders
                    .Where(order => order.OnlineOrderFlag == true)
                    .Select(s => new { s.SalesOrderID, s.OrderDate, s.SalesOrderNumber });

                foreach (var onlineOrder in onlineOrders)
                {
                    Console.WriteLine("Order ID: {0} Order date: {1:d} Order number: {2}",
                        onlineOrder.SalesOrderID,
                        onlineOrder.OrderDate,
                        onlineOrder.SalesOrderNumber);
                }
            }
            // </SnippetWhere1_MQ>
        }

        static void Where2()
        {
            // <SnippetWhere2>
            int orderQtyMin = 2;
            int orderQtyMax = 6;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query =
                    from order in context.SalesOrderDetails
                    where order.OrderQty > orderQtyMin && order.OrderQty < orderQtyMax
                    select new
                    {
                        SalesOrderID = order.SalesOrderID,
                        OrderQty = order.OrderQty
                    };

                foreach (var order in query)
                {
                    Console.WriteLine("Order ID: {0} Order quantity: {1}",
                        order.SalesOrderID, order.OrderQty);
                }
            }
            // </SnippetWhere2>
        }

        static void Where2_MQ()
        {
            // <SnippetWhere2_MQ>
            int orderQtyMin = 2;
            int orderQtyMax = 6;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = context.SalesOrderDetails
                    .Where(order => order.OrderQty > orderQtyMin && order.OrderQty < orderQtyMax)
                    .Select(s => new { s.SalesOrderID, s.OrderQty });

                foreach (var order in query)
                {
                    Console.WriteLine("Order ID: {0} Order quantity: {1}",
                        order.SalesOrderID, order.OrderQty);
                }
            }
            // </SnippetWhere2_MQ>
        }

        static void Where3()
        {
            // <SnippetWhere3>
            String color = "Red";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query =
                    from product in context.Products
                    where product.Color == color
                    select new
                    {
                        Name = product.Name,
                        ProductNumber = product.ProductNumber,
                        ListPrice = product.ListPrice
                    };

                foreach (var product in query)
                {
                    Console.WriteLine("Name: {0}", product.Name);
                    Console.WriteLine("Product number: {0}", product.ProductNumber);
                    Console.WriteLine("List price: ${0}", product.ListPrice);
                    Console.WriteLine("");
                }
            }
            //</SnippetWhere3>
        }

        static void Where3_MQ()
        {
            // <SnippetWhere3_MQ>
            String color = "Red";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = context.Products
                    .Where(product => product.Color == color)
                    .Select(p => new { p.Name, p.ProductNumber, p.ListPrice });

                foreach (var product in query)
                {
                    Console.WriteLine("Name: {0}", product.Name);
                    Console.WriteLine("Product number: {0}", product.ProductNumber);
                    Console.WriteLine("List price: ${0}", product.ListPrice);
                    Console.WriteLine("");
                }
            }
            //</SnippetWhere3_MQ>
        }

        static void WhereDrilldown()
        {
            // <SnippetWhereDrilldown>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query =
                    from order in context.SalesOrderHeaders
                    where order.OrderDate >= new DateTime(2002, 12, 1)
                    select order;

                Console.WriteLine("Orders that were made after 12/1/2002:");
                foreach (SalesOrderHeader order in query)
                {
                    Console.WriteLine("OrderID {0} Order date: {1:d} ",
                        order.SalesOrderID, order.OrderDate);
                    foreach (SalesOrderDetail orderDetail in order.SalesOrderDetails)
                    {
                        Console.WriteLine("  Product ID: {0} Unit Price {1}",
                            orderDetail.ProductID, orderDetail.UnitPrice);
                    }
                }
            }
            // </SnippetWhereDrilldown>
        }

        static void WhereNavProperty()
        {
            //<SnippetWhereNavProperty>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<SalesOrderHeader> query =
                    from order in context.SalesOrderHeaders
                    where order.OrderDate >= new DateTime(2003, 12, 1)
                    select order;

                Console.WriteLine("Orders that were made after December 1, 2003:");
                foreach (SalesOrderHeader order in query)
                {
                    Console.WriteLine("OrderID {0} Order date: {1:d} ",
                        order.SalesOrderID, order.OrderDate);
                    foreach (SalesOrderDetail orderDetail in order.SalesOrderDetails)
                    {
                        Console.WriteLine("  Product ID: {0} Unit Price {1}",
                            orderDetail.ProductID, orderDetail.UnitPrice);
                    }
                }
            }
            //</SnippetWhereNavProperty>
        }

        static void WhereNavProperty_MQ()
        {
            //<SnippetWhereNavProperty_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<SalesOrderHeader> query = context.SalesOrderHeaders
                    .Where(order => order.OrderDate >= new DateTime(2003, 12, 1));

                Console.WriteLine("Orders that were made after December 1, 2003:");
                foreach (SalesOrderHeader order in query)
                {
                    Console.WriteLine("OrderID {0} Order date: {1:d} ",
                        order.SalesOrderID, order.OrderDate);
                    foreach (SalesOrderDetail orderDetail in order.SalesOrderDetails)
                    {
                        Console.WriteLine("  Product ID: {0} Unit Price {1}",
                            orderDetail.ProductID, orderDetail.UnitPrice);
                    }
                }
            }
            //</SnippetWhereNavProperty_MQ>
        }
        # endregion

        #region "Partitioning Operators"

        static void TakeSimple()
        {
            //<SnippetTakeSimple>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> first5Contacts = context.Contacts.Take(5);

                Console.WriteLine("First 5 contacts:");
                foreach (Contact contact in first5Contacts)
                {
                    Console.WriteLine("Title = {0} \t FirstName = {1} \t Lastname = {2}",
                        contact.Title,
                        contact.FirstName,
                        contact.LastName);
                }
            }
            //</SnippetTakeSimple>
        }

        static void SkipSimple()
        {
            //<SnippetSkipSimple>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // LINQ to Entities only supports Skip on ordered collections.
                IOrderedQueryable<Product> products = context.Products
                        .OrderBy(p => p.ListPrice);

                IQueryable<Product> allButFirst3Products = products.Skip(3);

                Console.WriteLine("All but first 3 products:");
                foreach (Product product in allButFirst3Products)
                {
                    Console.WriteLine("Name: {0} \t ID: {1}",
                        product.Name,
                        product.ProductID);
                }
            }
            //</SnippetSkipSimple>
        }

        static void TakeNested()
        {
            //<SnippetTakeNested>
            String city = "Seattle";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Address> addresses = context.Addresses;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query = (
                    from address in addresses
                    from order in orders
                    where address.AddressID == order.Address.AddressID
                         && address.City == city
                    select new
                    {
                        City = address.City,
                        OrderID = order.SalesOrderID,
                        OrderDate = order.OrderDate
                    }).Take(3);
                Console.WriteLine("First 3 orders in Seattle:");
                foreach (var order in query)
                {
                    Console.WriteLine("City: {0} Order ID: {1} Total Due: {2:d}",
                        order.City, order.OrderID, order.OrderDate);
                }
            }
            //</SnippetTakeNested>
        }

        static void SkipNested()
        {
            //<SnippetSkipNested>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Address> addresses = context.Addresses;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                //LINQ to Entities only supports Skip on ordered collections.
                var query = (
                    from address in addresses
                    from order in orders
                    where address.AddressID == order.Address.AddressID
                         && address.City == "Seattle"
                    orderby order.SalesOrderID
                    select new
                    {
                        City = address.City,
                        OrderID = order.SalesOrderID,
                        OrderDate = order.OrderDate
                    }).Skip(2);

                Console.WriteLine("All but first 2 orders in Seattle:");
                foreach (var order in query)
                {
                    Console.WriteLine("City: {0} Order ID: {1} Total Due: {2:d}",
                        order.City, order.OrderID, order.OrderDate);
                }
                //</SnippetSkipNested>
            }
        }

        static void TakeWhileSimple_MQ()
        {
            // TakeWhile not supported in L2E
            /*using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                var takeWhileListPriceLessThan300 = products
                    .OrderBy(listprice => listprice.ListPrice)
                    .TakeWhile(product => product.ListPrice < 300.00M);

                Console.WriteLine("First ListPrice less than 300:");
                foreach (Product product in takeWhileListPriceLessThan300)
                {
                    Console.WriteLine(product.ListPrice);
                }
            }
            */
        }

        static void SkipWhileSimple_MQ()
        {
            // SkipWhile not supported in L2E.
            /* using (AdventureWorksEntities context = new AdventureWorksEntities())
             {
                 ObjectSet<Product> products = context.Products;

                 var skipWhilePriceLessThan300 = products
                     .OrderBy(listprice => listprice.ListPrice)
                     .SkipWhile(product => product.ListPrice < 300.00M);

                 Console.WriteLine("Skip while ListPrice is less than 300.00:");
                 foreach (Product product in skipWhilePriceLessThan300)
                 {
                     Console.WriteLine(product.ListPrice);
                 }
             }
             */
        }

        # endregion  //"Partitioning Operators"

        # region Ordering Operators

        static void OrderBySimple1()
        {
            // <SnippetOrderBySimple1>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> sortedNames =
                    from n in context.Contacts
                    orderby n.LastName
                    select n;

                Console.WriteLine("The sorted list of last names:");
                foreach (Contact n in sortedNames)
                {
                    Console.WriteLine(n.LastName);
                }
            }
            // </SnippetOrderBySimple1>
        }

        static void OrderBySimple1_MQ()
        {
            // <SnippetOrderBySimple1_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> sortedNames = context.Contacts
                    .OrderBy(n => n.LastName);

                Console.WriteLine("The sorted list of last names:");
                foreach (Contact n in sortedNames)
                {
                    Console.WriteLine(n.LastName);
                }
            }
            // </SnippetOrderBySimple1_MQ>
        }

        static void OrderBySimple2()
        {
            // <SnippetOrderBySimple2>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> sortedNames =
                    from n in context.Contacts
                    orderby n.LastName.Length
                    select n;

                Console.WriteLine("The sorted list of last names (by length):");
                foreach (Contact n in sortedNames)
                {
                    Console.WriteLine(n.LastName);
                }
            }
            // </SnippetOrderBySimple2>
        }

        static void OrderByThenBy()
        {
            // <SnippetOrderByThenBy>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> sortedContacts =
                    from contact in context.Contacts
                    orderby contact.LastName, contact.FirstName
                    select contact;

                Console.WriteLine("The list of contacts sorted by last name then by first name:");
                foreach (Contact sortedContact in sortedContacts)
                {
                    Console.WriteLine(sortedContact.LastName + ", " + sortedContact.FirstName);
                }
            }
            // </SnippetOrderByThenBy>
        }

        static void OrderByThenBy_MQ()
        {
            // <SnippetOrderByThenBy_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> sortedContacts = context.Contacts
                    .OrderBy(c => c.LastName)
                    .ThenBy(c => c.FirstName);

                Console.WriteLine("The list of contacts sorted by last name then by first name:");
                foreach (Contact sortedContact in sortedContacts)
                {
                    Console.WriteLine(sortedContact.LastName + ", " + sortedContact.FirstName);
                }
            }
            // </SnippetOrderByThenBy_MQ>
        }

        //<SnippetCustomComparer>
        private class CaseInsensitiveComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(x, y, true, CultureInfo.InvariantCulture);
            }
        }
        //</SnippetCustomComparer>

        static void OrderByDescendingSimple1()
        {
            // <SnippetOrderByDescendingSimple1>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Decimal> sortedPrices =
                    from p in context.Products
                    orderby p.ListPrice descending
                    select p.ListPrice;

                Console.WriteLine("The list price from highest to lowest:");
                foreach (Decimal price in sortedPrices)
                {
                    Console.WriteLine(price);
                }
            }
            // </SnippetOrderByDescendingSimple1>
        }

        static void OrderByDescendingSimple1_MQ()
        {
            // <SnippetOrderByDescendingSimple1_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Decimal> sortedPrices = context.Products
                    .OrderByDescending(p => p.ListPrice)
                    .Select(lp => lp.ListPrice);

                Console.WriteLine("The list price from highest to lowest:");
                foreach (Decimal price in sortedPrices)
                {
                    Console.WriteLine(price);
                }
            }
            // </SnippetOrderByDescendingSimple1_MQ>
        }

        static void ThenByDescendingSimple()
        {
            //<SnippetThenByDescendingSimple>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Product> query =
                    from product in context.Products
                    orderby product.Name, product.ListPrice descending
                    select product;

                foreach (Product product in query)
                {
                    Console.WriteLine("Product ID: {0} Product Name: {1} List Price {2}",
                        product.ProductID,
                        product.Name,
                        product.ListPrice);
                }
            }
            //</SnippetThenByDescendingSimple>
        }

        static void ThenByDescending_MQ()
        {
            //<SnippetThenByDescending_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IOrderedQueryable<Product> query = context.Products
                    .OrderBy(product => product.ListPrice)
                    .ThenByDescending(product => product.Name);

                foreach (Product product in query)
                {
                    Console.WriteLine("Product ID: {0} Product Name: {1} List Price {2}",
                        product.ProductID,
                        product.Name,
                        product.ListPrice);
                }
            }
            //</SnippetThenByDescending_MQ>
        }

        static void Reverse()
        {
            // Reverse not supported in L2E
            /*using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                IQueryable<SalesOrderHeader> query = (
                    from order in orders
                    where order.OrderDate < new DateTime(2002, 02, 20)
                    select order).Reverse();

                Console.WriteLine("A backwards list of orders where OrderDate < Feb 20, 2002");
                foreach (SalesOrderHeader order in query)
                {
                    Console.WriteLine(order.OrderDate);
                }
            }
            */
        }
        # endregion

        #region Grouping Operators

        static void GroupBySimple2()
        {
            //<SnippetGroupBySimple2>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = (
                    from contact in context.Contacts
                    group contact by contact.LastName.Substring(0, 1) into contactGroup
                    select new { FirstLetter = contactGroup.Key, Names = contactGroup }).
                        OrderBy(letter => letter.FirstLetter);

                foreach (var contact in query)
                {
                    Console.WriteLine("Last names that start with the letter '{0}':",
                        contact.FirstLetter);
                    foreach (var name in contact.Names)
                    {
                        Console.WriteLine(name.LastName);
                    }
                }
            }
            //</SnippetGroupBySimple2>
        }

        static void GroupBySimple2_MQ()
        {
            //<SnippetGroupBySimple2_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = context.Contacts
                    .GroupBy(c => c.LastName.Substring(0,1))
                    .OrderBy(c => c.Key);

                foreach (IGrouping<string, Contact> group in query)
                {
                    Console.WriteLine("Last names that start with the letter '{0}':",
                        group.Key);
                    foreach (Contact contact in group)
                    {
                        Console.WriteLine(contact.LastName);
                    }
                }
            }
            //</SnippetGroupBySimple2_MQ>
        }

        static void GroupBySimple3()
        {
            //<SnippetGroupBySimple3>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query =
                    from address in context.Addresses
                    group address by address.PostalCode into addressGroup
                    select new { PostalCode = addressGroup.Key,
                                 AddressLine = addressGroup };

                foreach (var addressGroup in query)
                {
                    Console.WriteLine("Postal Code: {0}", addressGroup.PostalCode);
                    foreach (var address in addressGroup.AddressLine)
                    {
                        Console.WriteLine("\t" + address.AddressLine1 +
                            address.AddressLine2);
                    }
                }
            }
            //</SnippetGroupBySimple3>
        }

        static void GroupBySimple3_MQ()
        {
            //<SnippetGroupBySimple3_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = context.Addresses
                    .GroupBy( address => address.PostalCode);

                foreach (IGrouping<string, Address> addressGroup in query)
                {
                    Console.WriteLine("Postal Code: {0}", addressGroup.Key);
                    foreach (Address address in addressGroup)
                    {
                        Console.WriteLine("\t" + address.AddressLine1 +
                            address.AddressLine2);
                    }
                }
            }
            //</SnippetGroupBySimple3_MQ>
        }

        static void GroupByCount()
        {
            //<SnippetGroupByCount>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from order in context.SalesOrderHeaders
                            group order by order.CustomerID into idGroup
                            select new {CustomerID = idGroup.Key,
                                OrderCount = idGroup.Count(),
                                Sales = idGroup};

                foreach (var orderGroup in query)
                {
                    Console.WriteLine("Customer ID: {0}", orderGroup.CustomerID);
                    Console.WriteLine("Order Count: {0}", orderGroup.OrderCount);

                    foreach (SalesOrderHeader sale in orderGroup.Sales)
                    {
                        Console.WriteLine("   Sale ID: {0}", sale.SalesOrderID);
                    }

                    Console.WriteLine("");
                }
            }
            //</SnippetGroupByCount>
        }

        static void GroupByCount_MQ()
        {
            //<SnippetGroupByCount_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = context.SalesOrderHeaders
                    .GroupBy(order => order.CustomerID);

                foreach (IGrouping<int, SalesOrderHeader> group in query)
                {
                    Console.WriteLine("Customer ID: {0}", group.Key);
                    Console.WriteLine("Order count: {0}", group.Count());

                    foreach (SalesOrderHeader sale in group)
                    {
                        Console.WriteLine("   Sale ID: {0}", sale.SalesOrderID);
                    }
                    Console.WriteLine("");
                }
            }
            //</SnippetGroupByCount_MQ>
        }

        static void GroupByNested()
        {
            //Don't know how to mimic SalesOrderContact DataRelation object.
            // Neither of the following work:
            //where Enumerable.Contains(saleContacts, contact.ContactID)
            //where saleContacts.Contains(contact.ContactID)
            //<SnippetGroupByNested>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> sales = context.SalesOrderHeaders;

                var saleContacts = sales.Select(s => s.Contact.ContactID);

                var query =
                    from contact in contacts
                    select new
                    {
                        ContactID = contact.ContactID,
                        YearGroups =
                            from order in sales
                            group order by order.OrderDate.Year into yg
                            select new
                            {
                                Year = yg.Key,
                                MonthGroups =
                                    from order in yg
                                    group order by order.OrderDate.Month into mg
                                    select new { Month = mg.Key, Orders = mg }
                            }
                    };

                foreach (var contactGroup in query)
                {
                    Console.WriteLine("ContactID = {0}", contactGroup.ContactID);
                    foreach (var yearGroup in contactGroup.YearGroups)
                    {
                        Console.WriteLine("\t Year= {0}", yearGroup.Year);
                        foreach (var monthGroup in yearGroup.MonthGroups)
                        {
                            Console.WriteLine("\t\t Month= {0}", monthGroup.Month);
                            foreach (var order in monthGroup.Orders)
                            {
                                Console.WriteLine("\t\t\t OrderID= {0} ",
                                    order.SalesOrderID);
                                Console.WriteLine("\t\t\t OrderDate= {0} ",
                                    order.OrderDate);
                            }
                        }
                    }
                }
            }
            //</SnippetGroupByNested>
        }

        #endregion  //Grouping Operators

        #region Set Operators

        static void Except1()
        {
            // <SnippetExcept1>
            string title = "Ms.";
            string firstName = "Sandra";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> query1 = from c in context.Contacts
                                             where c.Title == title
                                             select c;

                IQueryable<Contact> query2 = from c in context.Contacts
                                             where c.FirstName == firstName
                                             select c;

                //var contacts = query1.Except(query2);  //Old, problematic line.
                //var contacts = Queryable.Except(query1, query2); //This similarly fails.
                var contacts = Enumerable.Except(query1, query2);

                Console.WriteLine("Except of contacts sequences:");
                foreach (Contact c in contacts)
                {
                    Console.WriteLine("Id: {0}\t FirstName: {1}\t LastName: {2} ",
                        c.ContactID, c.FirstName, c.LastName);
                }
            }
            // </SnippetExcept1>
        }

        static void Except1_MQ()
        {
            // <SnippetExcept1_MQ>
            string title = "Ms.";
            string firstName = "Sandra";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> query1 = context.Contacts
                    .Where(c => c.Title == title);

                IQueryable<Contact> query2 = context.Contacts
                    .Where(c => c.FirstName == firstName);

                //var contacts = query1.Except(query2);  //Old, problematic line.
                var contacts = Enumerable.Except(query1, query2);

                Console.WriteLine("Except of contacts sequences:");
                foreach (Contact c in contacts)
                {
                    Console.WriteLine("Id: {0}\t FirstName: {1}\t LastName: {2} ",
                        c.ContactID, c.FirstName, c.LastName);
                }
            }
            // </SnippetExcept1_MQ>
        }

        static void Union1()
        {
            // <SnippetUnion1>
            string title = "Ms.";
            string firstName = "Sandra";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> query1 = from c in context.Contacts
                                             where c.Title == title
                                             select c;

                IQueryable<Contact> query2 = from c in context.Contacts
                                             where c.FirstName == firstName
                                             select c;

                //var contacts = query1.Union(query2);  //old, problematic line
                var contacts = Enumerable.Union(query1, query2);

                Console.WriteLine("Union of contacts sequences:");
                foreach (Contact c in contacts)
                {
                    Console.WriteLine("Id: {0}\t FirstName: {1}\t LastName: {2} ",
                        c.ContactID, c.FirstName, c.LastName);
                }
            }
            // </SnippetUnion1>
        }

        static void Union1_MQ()
        {
            // <SnippetUnion1_MQ>
            string title = "Ms.";
            string firstName = "Sandra";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> query1 = context.Contacts
                    .Where(c => c.Title == title);

                IQueryable<Contact> query2 = context.Contacts
                    .Where(c => c.FirstName == firstName);

                var contacts = query1.Union(query2);
                //var contacts = Enumerable.Union(query1, query2);

                Console.WriteLine("Union of contacts sequences:");
                foreach (Contact c in contacts)
                {
                    Console.WriteLine("Id: {0}\t FirstName: {1}\t LastName: {2} ",
                        c.ContactID, c.FirstName, c.LastName);
                }
            }
            // </SnippetUnion1_MQ>
        }

        static void Intersect1()
        {
            // <SnippetIntersect1>
            string title = "Ms.";
            string firstName = "Sandra";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contact = context.Contacts;

                IQueryable<Contact> query1 = from c in contact
                                             where c.Title == title
                                             select c;

                IQueryable<Contact> query2 = from c in contact
                                             where c.FirstName == firstName
                                             select c;

                // var contacts = query1.Intersect(query2); //old, problematic statement
                var contacts = Enumerable.Intersect(query1, query2);

                Console.WriteLine("Intersect of contacts sequences:");
                foreach (Contact c in contacts)
                {
                    Console.WriteLine("Id: {0}\t FirstName: {1}\t LastName: {2} ",
                        c.ContactID, c.FirstName, c.LastName);
                }
            }
            // </SnippetIntersect1>
        }

        static void Intersect1_MQ()
        {
            // <SnippetIntersect1_MQ>
            string title = "Ms.";
            string firstName = "Sandra";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contact = context.Contacts;

                IQueryable<Contact> query1 = contact
                    .Where(c => c.Title == title);

                IQueryable<Contact> query2 = contact
                    .Where(c => c.FirstName == firstName);

                // var contacts = query1.Intersect(query2);
                var contacts = Enumerable.Intersect(query1, query2);

                Console.WriteLine("Intersect of contacts sequences:");
                foreach (Contact c in contacts)
                {
                    Console.WriteLine("Id: {0}\t FirstName: {1}\t LastName: {2} ",
                        c.ContactID, c.FirstName, c.LastName);
                }
            }
            // </SnippetIntersect1_MQ>
        }

        static void DistinctRows()
        {
            //<SnippetDistinctRows>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contact = context.Contacts;

                IQueryable<Contact> first100Contacts = contact.Take(100);
                IQueryable<Contact> doubledContacts = first100Contacts.Union(contact.Take(100));

                //This next line blows up at runtime.
                IEnumerable<Contact> uniqueContact = doubledContacts.Distinct();
                // = doubledContacts.AsEnumerable().Distinct();
                // = Enumerable.Distinct(doubledContacts.AsEnumerable());

                Console.WriteLine("Initial number of contacts: {0}", contact.Count());
                Console.WriteLine("First 100, then doubled: {0}", doubledContacts.Count());
                Console.WriteLine("Number of unique contacts: {0}", uniqueContact.Count());
            }
            //</SnippetDistinctRows>
        }
        #endregion

        #region "Conversion Operators"

        static void ToArray()
        {
            //<SnippetToArray>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                Product[] prodArray = (
                    from product in products
                    orderby product.ListPrice descending
                    select product).ToArray();

                Console.WriteLine("Every price from highest to lowest:");
                foreach (Product product in prodArray)
                {
                    Console.WriteLine(product.ListPrice);
                }
            }
            //</SnippetToArray>
        }

        static void ToList()
        {
            //<SnippetToList>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                List<Product> query =
                    (from product in products
                     orderby product.Name
                     select product).ToList();

                Console.WriteLine("The product list, ordered by product name:");
                foreach (Product product in query)
                {
                    Console.WriteLine(product.Name.ToLower(CultureInfo.InvariantCulture));
                }
            }
            //</SnippetToList>
        }

        static void ToDictionary()
        {
            //<SnippetToDictionary>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                Dictionary<String, Product> scoreRecordsDict = products.
                        ToDictionary(record => record.Name);

                Console.WriteLine("Top Tube's ProductID: {0}",
                        scoreRecordsDict["Top Tube"].ProductID);
            }
            //</SnippetToDictionary>
        }
        #endregion //"Conversion Operators"

        #region "Element Operators"

        static void FirstSimple()
        {
            //<SnippetFirstSimple>
            string firstName = "Brooke";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;

                Contact query = (
                    from contact in contacts
                    where contact.FirstName == firstName
                    select contact)
                    .First();

                Console.WriteLine("ContactID: " + query.ContactID);
                Console.WriteLine("FirstName: " + query.FirstName);
                Console.WriteLine("LastName: " + query.LastName);
            }
            //</SnippetFirstSimple>
        }

        static void FirstCondition_MQ()
        {
            //<SnippetFirstCondition_MQ>
            string name = "caroline";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;

                Contact query = contacts.First(contact =>
                    contact.EmailAddress.StartsWith(name));

                Console.WriteLine("An email address starting with 'caroline': {0}",
                    query.EmailAddress);
            }
            //</SnippetFirstCondition_MQ>
        }

        static void ElementAt()
        {
            // ElementAt not supported by L2E.
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Address> addresses = context.Addresses;

                String fifthAddress = (
                    from address in addresses
                    where address.PostalCode == "M4B 1V7"
                    select address.AddressLine1)
                    .ElementAt(5);

                Console.WriteLine("Fifth address where PostalCode = 'M4B 1V7': {0}",
                    fifthAddress);

            }
            */
        }
        #endregion //"Element Operators"

        #region "Quantifier Operators"

        static void AnyGrouped_MQ()
        {
            //<SnippetAnyGrouped_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                var query =
                    from product in products
                    group product by product.Color into g
                    where g.Any(product => product.ListPrice == 0)
                    select new { Color = g.Key, Products = g };

                foreach (var productGroup in query)
                {
                    Console.WriteLine(productGroup.Color);
                    foreach (var product in productGroup.Products)
                    {
                        Console.WriteLine("\t {0}, {1}",
                            product.Name,
                            product.ListPrice);
                    }
                }
            }
            //</SnippetAnyGrouped_MQ>
        }

        static void AllGrouped_MQ()
        {
            //<SnippetAllGrouped_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                var query =
                    from product in products
                    group product by product.Color into g
                    where g.All(product => product.ListPrice > 0)
                    select new { Color = g.Key, Products = g };

                foreach (var productGroup in query)
                {
                    Console.WriteLine(productGroup.Color);
                    foreach (var product in productGroup.Products)
                    {
                        Console.WriteLine("\t {0}, {1}",
                            product.Name,
                            product.ListPrice);
                    }
                }
            }
            //</SnippetAllGrouped_MQ>
        }
        #endregion //"Element Operators"

        #region "Aggregate Operators"

        static void Aggregate_MQ()
        {
            // Aggregate not supported in L2E
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;

                string nameList =
                    contacts.Take(5).Select(contact => contact.LastName)
                        .Aggregate((workingList, next) => workingList + "," + next);

                Console.WriteLine(nameList);
            }
            */
        }

        static void Average_MQ()
        {
            //<SnippetAverage_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                Decimal averageListPrice =
                    products.Average(product => product.ListPrice);

                Console.WriteLine("The average list price of all the products is ${0}",
                    averageListPrice);
            }
            //</SnippetAverage_MQ>
        }

        static void Average2_MQ()
        {
            //<SnippetAverage2_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                var query = from product in products
                            group product by product.Style into g
                            select new
                            {
                                Style = g.Key,
                                AverageListPrice =
                                    g.Average(product => product.ListPrice)
                            };

                foreach (var product in query)
                {
                    Console.WriteLine("Product style: {0} Average list price: {1}",
                        product.Style, product.AverageListPrice);
                }
            }
            //</SnippetAverage2_MQ>
        }

        static void Count()
        {
            //<SnippetCount>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                int numProducts = products.Count();

                Console.WriteLine("There are {0} products.", numProducts);
            }
            //</SnippetCount>
        }

        static void CountNested()
        {
            //<SnippetCountNested>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;

                //Can't find field SalesOrderContact
                var query =
                    from contact in contacts
                    select new
                    {
                        CustomerID = contact.ContactID,
                        OrderCount = contact.SalesOrderHeaders.Count()
                    };

                foreach (var contact in query)
                {
                    Console.WriteLine("CustomerID = {0} \t OrderCount = {1}",
                        contact.CustomerID,
                        contact.OrderCount);
                }
            }
            //</SnippetCountNested>
        }

        static void CountGrouped()
        {
            //<SnippetCountGrouped>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                var query =
                    from product in products
                    group product by product.Color into g
                    select new { Color = g.Key, ProductCount = g.Count() };

                foreach (var product in query)
                {
                    Console.WriteLine("Color = {0} \t ProductCount = {1}",
                        product.Color,
                        product.ProductCount);
                }
            }
            //</SnippetCountGrouped>
        }

        static void LongCountSimple()
        {
            //<SnippetLongCountSimple>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;

                long numberOfContacts = contacts.LongCount();
                Console.WriteLine("There are {0} Contacts", numberOfContacts);
            }
            //</SnippetLongCountSimple>
        }

        static void SumProjection_MQ()
        {
            //<SnippetSumProjection_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderDetail> orders = context.SalesOrderDetails;

                double totalOrderQty = orders.Sum(o => o.OrderQty);
                Console.WriteLine("There are a total of {0} OrderQty.",
                    totalOrderQty);
            }
            //</SnippetSumProjection_MQ>
        }

        static void SumGrouped_MQ()
        {
            //<SnippetSumGrouped_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from order in orders
                    group order by order.Contact.ContactID into g
                    select new
                    {
                        Category = g.Key,
                        TotalDue = g.Sum(order => order.TotalDue)
                    };

                foreach (var order in query)
                {
                    Console.WriteLine("ContactID = {0} \t TotalDue sum = {1}",
                        order.Category, order.TotalDue);
                }
            }
            //</SnippetSumGrouped_MQ>
        }

        static void MinProjection_MQ()
        {
            //<SnippetMinProjection_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                Decimal smallestTotalDue = orders.Min(totalDue => totalDue.TotalDue);
                Console.WriteLine("The smallest TotalDue is {0}.",
                    smallestTotalDue);
            }
            //</SnippetMinProjection_MQ>
        }

        static void MinGrouped_MQ()
        {
            //<SnippetMinGrouped_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from order in orders
                    group order by order.Contact.ContactID into g
                    select new
                    {
                        Category = g.Key,
                        smallestTotalDue =
                            g.Min(order => order.TotalDue)
                    };

                foreach (var order in query)
                {
                    Console.WriteLine("ContactID = {0} \t Minimum TotalDue = {1}",
                        order.Category, order.smallestTotalDue);
                }
            }
            //</SnippetMinGrouped_MQ>
        }

        static void MinElements_MQ()
        {
            //<SnippetMinElements_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from order in orders
                    group order by order.Contact.ContactID into g
                    let minTotalDue = g.Min(order => order.TotalDue)
                    select new
                    {
                        Category = g.Key,
                        smallestTotalDue =
                            g.Where(order => order.TotalDue == minTotalDue)
                    };

                foreach (var orderGroup in query)
                {
                    Console.WriteLine("ContactID: {0}", orderGroup.Category);
                    foreach (var order in orderGroup.smallestTotalDue)
                    {
                        Console.WriteLine("Minimum TotalDue {0} for SalesOrderID {1}: ",
                            order.TotalDue,
                            order.SalesOrderID);
                    }
                    Console.Write("\n");
                }
            }
            //</SnippetMinElements_MQ>
        }

        static void AverageProjection_MQ()
        {
            //<SnippetAverageProjection_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                Decimal averageTotalDue = orders.Average(order => order.TotalDue);
                Console.WriteLine("The average TotalDue is {0}.", averageTotalDue);
            }
            //</SnippetAverageProjection_MQ>
        }

        static void AverageGrouped_MQ()
        {
            //<SnippetAverageGrouped_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from order in orders
                    group order by order.Contact.ContactID into g
                    select new
                    {
                        Category = g.Key,
                        averageTotalDue = g.Average(order => order.TotalDue)
                    };

                foreach (var order in query)
                {
                    Console.WriteLine("ContactID = {0} \t Average TotalDue = {1}",
                        order.Category, order.averageTotalDue);
                }
            }
            //</SnippetAverageGrouped_MQ>
        }

        static void AverageElements_MQ()
        {
            //<SnippetAverageElements_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from order in orders
                    group order by order.Contact.ContactID into g
                    let averageTotalDue = g.Average(order => order.TotalDue)
                    select new
                    {
                        Category = g.Key,
                        CheapestProducts =
                            g.Where(order => order.TotalDue == averageTotalDue)
                    };

                foreach (var orderGroup in query)
                {
                    Console.WriteLine("ContactID: {0}", orderGroup.Category);
                    foreach (var order in orderGroup.CheapestProducts)
                    {
                        Console.WriteLine("Average total due for SalesOrderID {1} is: {0}",
                            order.TotalDue, order.SalesOrderID);
                    }
                    Console.Write("\n");
                }
            }
            //</SnippetAverageElements_MQ>
        }

        static void MaxProjection_MQ()
        {
            //<SnippetMaxProjection_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                Decimal maxTotalDue = orders.Max(w => w.TotalDue);
                Console.WriteLine("The maximum TotalDue is {0}.",
                    maxTotalDue);
            }
            //</SnippetMaxProjection_MQ>
        }

        static void MaxGrouped_MQ()
        {
            //<SnippetMaxGrouped_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from order in orders
                    group order by order.Contact.ContactID into g
                    select new
                    {
                        Category = g.Key,
                        maxTotalDue =
                            g.Max(order => order.TotalDue)
                    };

                foreach (var order in query)
                {
                    Console.WriteLine("ContactID = {0} \t Maximum TotalDue = {1}",
                        order.Category, order.maxTotalDue);
                }
            }
            //</SnippetMaxGrouped_MQ>
        }

        static void MaxElements_MQ()
        {
            //<SnippetMaxElements_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from order in orders
                    group order by order.Contact.ContactID into g
                    let maxTotalDue = g.Max(order => order.TotalDue)
                    select new
                    {
                        Category = g.Key,
                        CheapestProducts =
                            g.Where(order => order.TotalDue == maxTotalDue)
                    };

                foreach (var orderGroup in query)
                {
                    Console.WriteLine("ContactID: {0}", orderGroup.Category);
                    foreach (var order in orderGroup.CheapestProducts)
                    {
                        Console.WriteLine("MaxTotalDue {0} for SalesOrderID {1}: ",
                            order.TotalDue,
                            order.SalesOrderID);
                    }
                    Console.Write("\n");
                }
            }
            //</SnippetMaxElements_MQ>
        }
        #endregion //"Aggregate Operators"

        #region "Join Operators"

        static void Join()
        {
            //<SnippetJoin>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;
                ObjectSet<SalesOrderDetail> details = context.SalesOrderDetails;

                var query =
                    from order in orders
                    join detail in details
                    on order.SalesOrderID equals detail.SalesOrderID
                    where order.OnlineOrderFlag == true
                    && order.OrderDate.Month == 8
                    select new
                    {
                        SalesOrderID = order.SalesOrderID,
                        SalesOrderDetailID = detail.SalesOrderDetailID,
                        OrderDate = order.OrderDate,
                        ProductID = detail.ProductID
                    };

                foreach (var order in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2:d}\t{3}",
                        order.SalesOrderID,
                        order.SalesOrderDetailID,
                        order.OrderDate,
                        order.ProductID);
                }
            }
            //</SnippetJoin>
        }

        static void JoinSimple_MQ()
        {
            //<SnippetJoinSimple_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    contacts.Join(
                        orders,
                        order => order.ContactID,
                        contact => contact.Contact.ContactID,
                        (contact, order) => new
                        {
                            ContactID = contact.ContactID,
                            SalesOrderID = order.SalesOrderID,
                            FirstName = contact.FirstName,
                            Lastname = contact.LastName,
                            TotalDue = order.TotalDue
                        });

                foreach (var contact_order in query)
                {
                    Console.WriteLine("ContactID: {0} "
                                    + "SalesOrderID: {1} "
                                    + "FirstName: {2} "
                                    + "Lastname: {3} "
                                    + "TotalDue: {4}",
                        contact_order.ContactID,
                        contact_order.SalesOrderID,
                        contact_order.FirstName,
                        contact_order.Lastname,
                        contact_order.TotalDue);
                }
            }
            //</SnippetJoinSimple_MQ>
        }

        static void JoinWithGroupedResults_MQ()
        {
            //<SnippetJoinWithGroupedResults_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query = contacts.Join(
                    orders,
                    order => order.ContactID,
                    contact => contact.Contact.ContactID,
                    (contact, order) => new
                    {
                        ContactID = contact.ContactID,
                        SalesOrderID = order.SalesOrderID,
                        FirstName = contact.FirstName,
                        Lastname = contact.LastName,
                        TotalDue = order.TotalDue
                    })
                        .GroupBy(record => record.ContactID);

                foreach (var group in query)
                {
                    foreach (var contact_order in group)
                    {
                        Console.WriteLine("ContactID: {0} "
                                        + "SalesOrderID: {1} "
                                        + "FirstName: {2} "
                                        + "Lastname: {3} "
                                        + "TotalDue: {4}",
                            contact_order.ContactID,
                            contact_order.SalesOrderID,
                            contact_order.FirstName,
                            contact_order.Lastname,
                            contact_order.TotalDue);
                    }
                }
            }
            //</SnippetJoinWithGroupedResults_MQ>
        }

        static void GroupJoin()
        {
            //<SnippetGroupJoin>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query =
                    from contact in contacts
                    join order in orders
                    on contact.ContactID
                    equals order.Contact.ContactID into contactGroup
                    select new
                    {
                        ContactID = contact.ContactID,
                        OrderCount = contactGroup.Count(),
                        Orders = contactGroup
                    };

                foreach (var group in query)
                {
                    Console.WriteLine("ContactID: {0}", group.ContactID);
                    Console.WriteLine("Order count: {0}", group.OrderCount);
                    foreach (var orderInfo in group.Orders)
                    {
                        Console.WriteLine("   Sale ID: {0}", orderInfo.SalesOrderID);
                    }
                    Console.WriteLine("");
                }
            }
            //</SnippetGroupJoin>
        }

        static void GroupJoin_MQ()
        {
            //<SnippetGroupJoin_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var query = contacts.GroupJoin(orders,
                    contact => contact.ContactID,
                    order => order.Contact.ContactID,
                    (contact, contactGroup) => new
                    {
                        ContactID = contact.ContactID,
                        OrderCount = contactGroup.Count(),
                        Orders = contactGroup
                    });

                foreach (var group in query)
                {
                    Console.WriteLine("ContactID: {0}", group.ContactID);
                    Console.WriteLine("Order count: {0}", group.OrderCount);
                    foreach (var orderInfo in group.Orders)
                    {
                        Console.WriteLine("   Sale ID: {0}", orderInfo.SalesOrderID);
                    }
                    Console.WriteLine("");
                }
                }
                //</SnippetGroupJoin_MQ>
            }

        static void GroupJoin2()
        {
            //<SnippetGroupJoin2>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;
                ObjectSet<SalesOrderDetail> details = context.SalesOrderDetails;

                var query =
                    from order in orders
                    join detail in details
                    on order.SalesOrderID
                    equals detail.SalesOrderID into orderGroup
                    select new
                    {
                        CustomerID = order.SalesOrderID,
                        OrderCount = orderGroup.Count()
                    };

                foreach (var order in query)
                {
                    Console.WriteLine("CustomerID: {0}  Orders Count: {1}",
                        order.CustomerID,
                        order.OrderCount);
                }
            }
            //</SnippetGroupJoin2>
        }

        static void GroupJoin2_MQ()
        {
            //<SnippetGroupJoin2_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;
                ObjectSet<SalesOrderDetail> details = context.SalesOrderDetails;

                var query = orders.GroupJoin(details,
                    order => order.SalesOrderID,
                    detail => detail.SalesOrderID,
                    (order, orderGroup) => new
                    {
                        CustomerID = order.SalesOrderID,
                        OrderCount = orderGroup.Count()
                    });

                foreach (var order in query)
                {
                    Console.WriteLine("CustomerID: {0}  Orders Count: {1}",
                        order.CustomerID,
                        order.OrderCount);
                }
            }
            //</SnippetGroupJoin2_MQ>
        }

        #endregion //"Join Operators"

        #region "Relationship Navigation"

        static void SelectEachContactsOrders_MQ()
        {
            //<SnippetSelectEachContactsOrders_MQ>
            string lastName = "Zhou";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<SalesOrderHeader> ordersQuery = context.Contacts
                    .Where(c => c.LastName == lastName)
                    .SelectMany(c => c.SalesOrderHeaders);

                foreach (var order in ordersQuery)
                {
                    Console.WriteLine("Order ID: {0}, Order date: {1}, Total Due: {2}",
                        order.SalesOrderID, order.OrderDate, order.TotalDue);
                }
            }
            //</SnippetSelectEachContactsOrders_MQ>
        }

        static void SelectEachContactsOrders2()
        {
            //<SnippetSelectEachContactsOrders2>
            string lastName = "Zhou";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;

                var ordersQuery = from contact in contacts
                                  where contact.LastName == lastName
                                  select new
                                  {
                                      ContactID = contact.ContactID,
                                      Total = contact.SalesOrderHeaders.Sum(o => o.TotalDue)
                                  };

                foreach (var contact in ordersQuery)
                {
                    Console.WriteLine("Contact ID: {0} Orders total: {1}", contact.ContactID, contact.Total);
                }
            }
            //</SnippetSelectEachContactsOrders2>
        }

        static void SelectEachContactsOrders2_MQ()
        {
            //<SnippetSelectEachContactsOrders2_MQ>
            string lastName = "Zhou";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var ordersQuery = context.Contacts
                    .Where(c => c.LastName == lastName)
                    .Select(c => new
                    {
                        ContactID = c.ContactID,
                        Total = c.SalesOrderHeaders.Sum(o => o.TotalDue)
                    });

                foreach (var contact in ordersQuery)
                {
                    Console.WriteLine("Contact ID: {0} Orders total: {1}", contact.ContactID, contact.Total);
                }
            }
            //</SnippetSelectEachContactsOrders2_MQ>
        }

        static void SelectEachContactsOrders3()
        {
            //<SnippetSelectEachContactsOrders3>
            string lastName = "Zhou";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Contact> contacts = context.Contacts;

                var ordersQuery = from contact in contacts
                                  where contact.LastName == lastName
                                  select new { LastName = contact.LastName, Orders = contact.SalesOrderHeaders };

                foreach (var order in ordersQuery)
                {
                    Console.WriteLine("Name: {0}", order.LastName);
                    foreach (SalesOrderHeader orderInfo in order.Orders)
                    {
                        Console.WriteLine("Order ID: {0}, Order date: {1}, Total Due: {2}",
                            orderInfo.SalesOrderID, orderInfo.OrderDate, orderInfo.TotalDue);
                    }
                    Console.WriteLine("");
                }
            }
            //</SnippetSelectEachContactsOrders3>
        }

        static void SelectEachContactsOrders3_MQ()
        {
            //<SnippetSelectEachContactsOrders3_MQ>
            string lastName = "Zhou";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var ordersQuery = context.Contacts
                    .Where(c => c.LastName == lastName)
                    .Select(c => new { LastName = c.LastName, Orders = c.SalesOrderHeaders });

                foreach (var order in ordersQuery)
                {
                    Console.WriteLine("Name: {0}", order.LastName);
                    foreach (SalesOrderHeader orderInfo in order.Orders)
                    {
                        Console.WriteLine("Order ID: {0}, Order date: {1}, Total Due: {2}",
                            orderInfo.SalesOrderID, orderInfo.OrderDate, orderInfo.TotalDue);
                    }
                    Console.WriteLine("");
                }
            }
            //</SnippetSelectEachContactsOrders3_MQ>
        }

        static void GetOrderInfoThruRelationships()
        {
            //<SnippetGetOrderInfoThruRelationships>
            string city = "Seattle";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;

                var ordersQuery = from order in orders
                                  where order.Address.City == city
                                  select new
                                  {
                                      ContactLastName = order.Contact.LastName,
                                      ContactFirstName = order.Contact.FirstName,
                                      StreetAddress = order.Address.AddressLine1,
                                      OrderNumber = order.SalesOrderNumber,
                                      TotalDue = order.TotalDue
                                  };

                foreach (var orderInfo in ordersQuery)
                {
                    Console.WriteLine("Name: {0}, {1}", orderInfo.ContactLastName, orderInfo.ContactFirstName);
                    Console.WriteLine("Street address: {0}", orderInfo.StreetAddress);
                    Console.WriteLine("Order number: {0}", orderInfo.OrderNumber);
                    Console.WriteLine("Total Due: {0}", orderInfo.TotalDue);
                    Console.WriteLine("");
                }
            }
            //</SnippetGetOrderInfoThruRelationships>
        }

        static void GetOrderInfoThruRelationships_MQ()
        {
            //<SnippetGetOrderInfoThruRelationships_MQ>
            string city = "Seattle";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var ordersQuery = context.SalesOrderHeaders
                    .Where(o => o.Address.City == city)
                    .Select(o => new
                    {
                        ContactLastName = o.Contact.LastName,
                        ContactFirstName = o.Contact.FirstName,
                        StreetAddress = o.Address.AddressLine1,
                        OrderNumber = o.SalesOrderNumber,
                        TotalDue = o.TotalDue
                    });

                foreach (var orderInfo in ordersQuery)
                {
                    Console.WriteLine("Name: {0}, {1}", orderInfo.ContactLastName, orderInfo.ContactFirstName);
                    Console.WriteLine("Street address: {0}", orderInfo.StreetAddress);
                    Console.WriteLine("Order number: {0}", orderInfo.OrderNumber);
                    Console.WriteLine("Total Due: {0}", orderInfo.TotalDue);
                    Console.WriteLine("");
                }
            }
            //</SnippetGetOrderInfoThruRelationships_MQ>
        }
        #endregion

    }
}
