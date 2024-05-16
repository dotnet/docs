
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;

namespace L2E_ConceptualExamplesCS
{
    class Program
    {
        static void Main(string[] args)
        {
            FunctionMapping2();
            //*** Misc ***//
            // UIntAsQueryParam();
            // UIntAsQueryParam_MQ();
            // SBUDT496552A();
            // SBUDT496552B();
            //SBUDT544351();
            //EndsWithComparison();
            //SBUDT543840();
            //SBUDT551087();
            //SBUDT543574();
            // SBUDT555877();

            //*** How to examples
            //QueryReturnsPrimitiveValue();
            //DistinctHowTo();
            //CSWalkthrough();

            //*** Expression examples. ***//
            // ConstantExpression();
            // RestrictionExpression();
            // RestrictionExpression_MQ();
            // DateTimeComparison();
            // DateTimeComparison_MQ();
             //PropertyAsConstant();
           // MethodAsConstantFails();
            // NullComparison(); // Needs work
            // CastResultsIsNull(); // Needs work
            // JoinOnNull();
            // AnonymousTypeInitialization();
            // AnonymousTypeInitialization_MQ();
            // TypeInitialization();
            // TypeInitialization_MQ();

            //WhereExpression();
            //LiteralParameter1();
            //int orderID = 51987;
            //MethodParameterExample(orderID);
            // NullCastToString();
            //CastToNullable();
            // ConstructorForLiteral();
            //CanonicalFuncVsCLRBaseType();
            //ConvertExpression();
            //NonSymmetricGetterSetter();

            //*** Nav property examples ***//
            //NavPropLoadError();
            // NavProperty_MQ();

            //*** Query examples ***//
            // Query1();
            // Query1_MQ();
            // QueryExpression();
            // MethodQuery();
            // composing1();
            // composing2();

            //*** Query results examples ***//
            //QueryResults1();

            //*** Canonical Function Mapping***//
            // FunctionMapping();
            // FunctionMapping2();  // Not used in docs.
            // FunctionMappingWorkAround();

            //*** Compiled Query examples ***//
            //CompiledQuery1_MQ();
            //CompiledQuery2();
            //CompiledQuery2_MQ();
            //CompiledQuery3_MQ();
            //CompiledQuery4_MQ();
            //CompiledQuery5();
            //CompiledQuery6();
            //CompiledQuery7();

            Console.WriteLine("Hit enter...");
            Console.Read();
        }

        # region Expression Examples
        static void ConstantExpression()
        {
            // <SnippetConstantExpression>
            Decimal totalDue = 200 + 3;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<string> salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.TotalDue >= totalDue
                    select s.SalesOrderNumber;

                Console.WriteLine("Sales order numbers:");
                foreach (string orderNum in salesInfo)
                {
                    Console.WriteLine(orderNum);
                }
            }
            // </SnippetConstantExpression>
        }

        static void RestrictionExpression()
        {
            // <SnippetRestrictionExpression>
            string salesOrderNumber = "SO43663";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<SalesOrderHeader> salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.SalesOrderNumber == salesOrderNumber
                    select s;

                Console.WriteLine("Sales info-");
                foreach (SalesOrderHeader sale in salesInfo)
                {
                    Console.WriteLine("Sales ID: " + sale.SalesOrderID);
                    Console.WriteLine("Ship date: " + sale.ShipDate);
                }
            }
            // </SnippetRestrictionExpression>
        }

        static void RestrictionExpression_MQ()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // <SnippetRestrictionExpression_MQ>
                string salesOrderNumber = "SO43663";
                IQueryable<SalesOrderHeader> salesInfo =
                    context.SalesOrderHeaders
                    .Where(s => s.SalesOrderNumber == salesOrderNumber)
                    .Select(s => s);

                Console.WriteLine("Sales info-");
                foreach (SalesOrderHeader sale in salesInfo)
                {
                    Console.WriteLine("Sales ID: " + sale.SalesOrderID);
                    Console.WriteLine("Ship date: " + sale.ShipDate);
                }
            }
            // </SnippetRestrictionExpression_MQ>
        }

        static void DateTimeComparison()
        {
            // <SnippetDateTimeComparison>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                DateTime dt = new DateTime(2001, 7, 8);

                IQueryable<SalesOrderHeader> salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.ShipDate == dt
                    select s;

                Console.WriteLine("Orders shipped on August 7, 2001:");
                foreach (SalesOrderHeader sale in salesInfo)
                {
                    Console.WriteLine("Sales ID: " + sale.SalesOrderID);
                    Console.WriteLine("Total due: " + sale.TotalDue);
                    Console.WriteLine();
                }
            }
            // </SnippetDateTimeComparison>
        }

        static void DateTimeComparison_MQ()
        {
            // <SnippetDateTimeComparison_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                DateTime dt = new DateTime(2001, 7, 8);

                IQueryable<SalesOrderHeader> salesInfo =
                    context.SalesOrderHeaders
                    .Where(s => s.ShipDate == dt)
                    .Select(s => s);

                Console.WriteLine("Orders shipped on August 7, 2001:");
                foreach (SalesOrderHeader sale in salesInfo)
                {
                    Console.WriteLine("Sales ID: " + sale.SalesOrderID);
                    Console.WriteLine("Total due: " + sale.TotalDue);
                    Console.WriteLine();
                }
            }
            // </SnippetDateTimeComparison_MQ>
        }

        // <SnippetMyClass>
        class AClass { public int ID;}
        // </SnippetMyClass>
        static void PropertyAsConstant()
        {
            // <SnippetPropertyAsConstant>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                AClass aClass = new AClass();
                aClass.ID = 43663;

                IQueryable<SalesOrderHeader> salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.SalesOrderID == aClass.ID
                    select s;

                Console.WriteLine("Order info-");
                foreach (SalesOrderHeader sale in salesInfo)
                {
                    Console.WriteLine("Sales order number: " + sale.SalesOrderNumber);
                    Console.WriteLine("Total due: " + sale.TotalDue);
                    Console.WriteLine();
                }
            }
            // </SnippetPropertyAsConstant>
        }

        // <SnippetMyClass2>
        class MyClass2
        {
            public int returnInt() { return 5; }
        }
        // </SnippetMyClass2>

        static void MethodAsConstantFails()
        {
            // <SnippetMethodAsConstantFails>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                MyClass2 myClass = new MyClass2();

                //Throws a NotSupportedException
                IQueryable<SalesOrderHeader> salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.SalesOrderID == myClass.returnInt()
                    select s;

                Console.WriteLine("Order info-");
                try
                {
                    foreach (SalesOrderHeader sale in salesInfo)
                    {
                        Console.WriteLine("Sales order number: " + sale.SalesOrderNumber);
                        Console.WriteLine("Total due: " + sale.TotalDue);
                        Console.WriteLine();
                    }
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                }
            }
            // </SnippetMethodAsConstantFails>
        }

        static void NullComparison()
        {
            // <SnippetNullComparison>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectQuery<SalesOrderHeader> sales = context.SalesOrderHeaders;

                //Throws a NotSupportedException
                /* var orders = from c in edm.Customers
              join c2 in edm.Orders
           on c.Region == c2.ShipRegion
              where c.Region == null
              select c.CustomerID;

                 Console.WriteLine("Order info-");
                 foreach (SalesOrderHeader sale in salesInfo)
                 {
                     Console.WriteLine("Sales order number: " + sale.SalesOrderNumber);
                     Console.WriteLine("Total due: " + sale.TotalDue);
                     Console.WriteLine();
                 }*/
            }
            // </SnippetNullComparison>
        }

        class NewProduct : Product { public DateTime Introduced; }

        static void CastResultsIsNull()
        {
            // <SnippetCastResultsIsNull>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                DateTime dt = new DateTime();
                var query = context.Products
                    .Where(p => (p as NewProduct).Introduced > dt)
                    .Select(x => x);
            }
            // </SnippetCastResultsIsNull>
        }

        static void JoinOnNull()
        {

            // <SnippetJoinOnNull>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<SalesOrderHeader> orders = context.SalesOrderHeaders;
                ObjectSet<SalesOrderDetail> details = context.SalesOrderDetails;

                var query =
                    from order in orders
                    join detail in details
                    on order.SalesOrderID
                    equals detail.SalesOrderID
                    where order.ShipDate == null
                    select order.SalesOrderID;

                foreach (var OrderID in query)
                {
                    Console.WriteLine("OrderID : {0}", OrderID);
                }
            }
            // </SnippetJoinOnNull>
        }

        static void AnonymousTypeInitialization()
        {
            // <SnippetAnonymousTypeInitialization>
            Decimal totalDue = 200;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.TotalDue >= totalDue
                    select new { s.SalesOrderNumber, s.TotalDue };

                Console.WriteLine("Sales order numbers:");
                foreach (var sale in salesInfo)
                {
                    Console.WriteLine("Order number: " + sale.SalesOrderNumber);
                    Console.WriteLine("Total due: " + sale.TotalDue);
                    Console.WriteLine("");
                }
            }
            // </SnippetAnonymousTypeInitialization>
        }

        static void AnonymousTypeInitialization_MQ()
        {
            // <SnippetAnonymousTypeInitialization_MQ>
            Decimal totalDue = 200;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                var salesInfo =
                    context.SalesOrderHeaders
                    .Where(s => s.TotalDue >= totalDue)
                    .Select(s => new { s.SalesOrderNumber, s.TotalDue });

                Console.WriteLine("Sales order numbers:");
                foreach (var sale in salesInfo)
                {
                    Console.WriteLine("Order number: " + sale.SalesOrderNumber);
                    Console.WriteLine("Total due: " + sale.TotalDue);
                    Console.WriteLine("");
                }
            }
            // </SnippetAnonymousTypeInitialization_MQ>
        }

        // <SnippetMyOrder>
        class MyOrder { public string SalesOrderNumber; public DateTime? ShipDate; }
        // </SnippetMyOrder>
        static void TypeInitialization()
        {
            // <SnippetTypeInitialization>
            Decimal totalDue = 200;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<MyOrder> salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.TotalDue >= totalDue
                    select new MyOrder
                    {
                        SalesOrderNumber = s.SalesOrderNumber,
                        ShipDate = s.ShipDate
                    };

                Console.WriteLine("Sales order info:");
                foreach (MyOrder order in salesInfo)
                {
                    Console.WriteLine("Order number: " + order.SalesOrderNumber);
                    Console.WriteLine("Ship date: " + order.ShipDate);
                    Console.WriteLine("");
                }
            }
            // </SnippetTypeInitialization>
        }

        static void TypeInitialization_MQ()
        {
            // <SnippetTypeInitialization_MQ>
            Decimal totalDue = 200;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<MyOrder> salesInfo =
                    context.SalesOrderHeaders
                    .Where(s => s.TotalDue >= totalDue)
                    .Select(s => new MyOrder
                    {
                        SalesOrderNumber = s.SalesOrderNumber,
                        ShipDate = s.ShipDate
                    });

                Console.WriteLine("Sales order info:");
                foreach (MyOrder order in salesInfo)
                {
                    Console.WriteLine("Order number: " + order.SalesOrderNumber);
                    Console.WriteLine("Ship date: " + order.ShipDate);
                    Console.WriteLine("");
                }
            }
            // </SnippetTypeInitialization_MQ>
        }

        static void NavProperty_MQ()
        {
            // <SnippetNavProperty_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var contactOrders =
                    context.Contacts
                    .Select(c => new
                    {
                        ContactID = c.ContactID,
                        Orders = c.SalesOrderHeaders
                    });

                Console.WriteLine("Orders by contact:");
                foreach (var contactOrder in contactOrders)
                {
                    Console.WriteLine("Contact ID: " + contactOrder.ContactID);

                    foreach (SalesOrderHeader order in contactOrder.Orders)
                    {
                        Console.WriteLine("   Order ID: " + order.SalesOrderID);
                        Console.WriteLine("   Total due: " + order.TotalDue);
                    }

                    Console.WriteLine("");
                }
            }
            // </SnippetNavProperty_MQ>
        }

        public static void NavPropLoadError()
        {
            //<SnippetNavPropLoadError>
            string lastName = "Johnson";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Contact> contacts =
                        context.Contacts
                        .Where(c => c.LastName == lastName)
                        .Select(c => c);

                try
                {

                    foreach (Contact contact in contacts)
                    {
                        Console.WriteLine("Name: {0}, {1}", contact.LastName, contact.FirstName);

                        // Throws a EntityCommandExecutionException if
                        // MultipleActiveResultSets is set to False in the
                        // connection string.
                        contact.SalesOrderHeaders.Load();

                        foreach (SalesOrderHeader order in contact.SalesOrderHeaders)
                        {
                            Console.WriteLine("Order ID: {0}", order.SalesOrderID);
                        }
                    }
                }
                catch (EntityCommandExecutionException ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
            //</SnippetNavPropLoadError>
        }

        public static void WhereExpression()
        {
            // <SnippetWhereExpression>
            Decimal totalDue = 200;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<int> salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.TotalDue >= totalDue
                    select s.SalesOrderID;

                Console.WriteLine("Sales order info:");
                foreach (int orderNumber in salesInfo)
                {
                    Console.WriteLine("Order number: " + orderNumber);
                }
            }
            // </SnippetWhereExpression>
        }

        public static void LiteralParameter1()
        {

            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                //<SnippetLiteralParameter1>
                int orderID = 51987;

                IQueryable<SalesOrderHeader> salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.SalesOrderID == orderID
                    select s;
                //</SnippetLiteralParameter1>

                foreach (SalesOrderHeader sale in salesInfo)
                {
                    Console.WriteLine(sale.SalesOrderID);
                }
            }
        }

        //<SnippetMethodParameterExample>
        public static void MethodParameterExample(int orderID)
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                IQueryable<SalesOrderHeader> salesInfo =
                    from s in context.SalesOrderHeaders
                    where s.SalesOrderID == orderID
                    select s;

                foreach (SalesOrderHeader sale in salesInfo)
                {
                    Console.WriteLine("OrderID: {0}, Total due: {1}", sale.SalesOrderID, sale.TotalDue);
                }
            }
        }
        //</SnippetMethodParameterExample>

        public static void NullCastToString()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                //<SnippetNullCastToString>
                IQueryable<Contact> query =
                    from c in context.Contacts
                    where c.EmailAddress == (string)null
                    select c;
                //</SnippetNullCastToString>

                foreach (Contact contact in query)
                {
                    Console.WriteLine("Name: {0}", contact.LastName);
                }
            }
        }

        public static void CastToNullable()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                //<SnippetCastToNullable>
                var weight = (decimal?)23.77;
                IQueryable<Product> query =
                    from product in context.Products
                    where product.Weight == weight
                    select product;
                //</SnippetCastToNullable>

                foreach (Product p in query)
                {
                    Console.WriteLine("Name: {0}", p.Name);
                }
            }
        }

        public static void ConstructorForLiteral()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                //<SnippetConstructorForLiteral>
                var weight = new decimal(23.77);
                IQueryable<Product> query =
                    from product in context.Products
                    where product.Weight == weight
                    select product;
                //</SnippetConstructorForLiteral>

                foreach (Product p in query)
                {
                    Console.WriteLine("Name: {0}", p.Name);
                }
            }
        }

        public static void CanonicalFuncVsCLRBaseType()
        {
            //<SnippetCanonicalFuncVsCLRBaseType>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<string> query = from p in context.Products
                                           where p.Name == "Reflector"
                                           select p.Name;

                IEnumerable<bool> q = query.Select(c => c.EndsWith("Reflector "));

                Console.WriteLine("LINQ to Entities returns: " + q.First());
                Console.WriteLine("CLR returns: " + "Reflector".EndsWith("Reflector "));
            }
            //</SnippetCanonicalFuncVsCLRBaseType>
        }

        public static void ConvertExpression()
        {
            // <SnippetConvertExpression>
            int orderQty = 1;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var sales = from sale in context.SalesOrderDetails
                            where sale.OrderQty > orderQty
                            select new { Sale = sale, TotalValue = (decimal)sale.OrderQty * sale.UnitPrice };

                foreach (var s in sales)
                {
                    Console.WriteLine("Sale ID: {0}, Value: {1}", s.Sale.SalesOrderID, s.TotalValue);
                }
            }
            // </SnippetConvertExpression>
        }

        # endregion
        # region Query Examples
        static void Query1()
        {
            //<SnippetQuery1>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Product> productNames =
                   from p in context.Products
                   select p;
            }
            //</SnippetQuery1>
        }
        static void Query1_MQ()
        {
            //<SnippetQuery1_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                ObjectSet<Product> products = context.Products;

                IQueryable<Product> productNames = products.Select(p => p);
            }
            //</SnippetQuery1_MQ>
        }

        static void QueryExpression()
        {
            //<SnippetQueryExpression>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<string> productNames =
                   from p in context.Products
                   select p.Name;

                Console.WriteLine("Product Names:");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }
            }
            //</SnippetQueryExpression>
        }
        static void MethodQuery()
        {
            //<SnippetMethodQuery>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<string> productNames = context.Products.Select(p => p.Name);

                Console.WriteLine("Product Names:");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }
            }
            //</SnippetMethodQuery>
        }
        static void composing1()
        {
            //<SnippetComposing1>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Product> productsQuery =
                    from p in context.Products
                    select p;

                IQueryable<Product> largeProducts = productsQuery.Where(p => p.Size == "L");

                Console.WriteLine("Products of size 'L':");
                foreach (var product in largeProducts)
                {
                    Console.WriteLine(product.Name);
                }
            }
            //</SnippetComposing1>
        }

        static void composing2()
        {
            //<SnippetComposing2>
            string color = "Red";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Product> productsQuery =
                    from p in context.Products
                    select p;

                Console.WriteLine("The list of products:");
                foreach (Product product in productsQuery)
                {
                    Console.WriteLine(product.Name);
                }

                IQueryable<Product> redProducts = productsQuery
                    .Where(p => p.Color == color)
                    .Select(p => p);

                Console.WriteLine("");
                Console.WriteLine("The list of red products:");
                foreach (Product redProduct in redProducts)
                {
                    Console.WriteLine(redProduct.Name);
                }
            }
            //</SnippetComposing2>

            /*
                IQueryable<Product> productsQuery =
                    from p in context.Products
                    select p;

                IEnumerable<Product> productsList = productsQuery.ToList();

                Console.WriteLine("The list of products:");
                foreach (var product in productsList)
                {
                    Console.WriteLine(product.Name);
                }
             */
        }
        # endregion
        # region Query Results Examples
        // <SnippetQueryResults1>
        public static int count = 0;

        static void QueryResults1()
        {
            string lastName = "Jones";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query1 = context
                    .Contacts
                    .Where(c => c.LastName == lastName)
                    .Select(c => new MyContact { LastName = c.LastName });

                // Execute the first query and print the count.
                query1.ToList();
                Console.WriteLine("Count: " + count);

                //Reset the count variable.
                count = 0;

                var query2 = context
                    .Contacts
                    .Where(c => c.LastName == lastName)
                    .Select(c => new MyContact { LastName = c.LastName })
                    .Select(my => my.LastName);

                // Execute the second query and print the count.
                query2.ToList();
                Console.WriteLine("Count: " + count);
            }
        }

        public class MyContact
        {
            String _lastName;

            public string LastName
            {
                get
                {
                    return _lastName;
                }
                set
                {
                    _lastName = value;
                    count++;
                }
            }
        }
        // </SnippetQueryResults1>

        # endregion
        # region Misc

        static void SBUDT551087()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                IQueryable<int> scalarQuery = new ObjectQuery<int>("100", context);
                bool hasResults = scalarQuery.Any();
                Console.Write(hasResults);
            }
        }

        static void SBUDT543840()
        {

            // <SnippetSBUDT543840>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // Ordering information is lost when executed against a SQL Server 2005
                // database running with a compatibility level of "80".
                var results = context.Contacts.SelectMany(c => c.SalesOrderHeaders)
                    .OrderBy(c => c.SalesOrderDetails.Count)
                    .Select(c => new { c.SalesOrderDetails.Count });

                foreach (var result in results)
                    Console.WriteLine(result.Count);
            }
            // </SnippetSBUDT543840>
        }

        static void SBUDT544351()
        {
            // <SnippetSBUDT544351>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // In this query, the ordering is not preserved because Distinct
                // is called after OrderByDescending.
                IQueryable<string> productsList = context.Products
                    .OrderByDescending(p => p.Name)
                    .Select(p => p.Name)
                    .Distinct();

                Console.WriteLine("The list of products:");
                foreach (string productName in productsList)
                {
                    Console.WriteLine(productName);
                }

                // In this query, the ordering is preserved because
                // OrderByDescending is called after Distinct.
                IQueryable<string> productsList2 = context.Products
                    .Select(p => p.Name)
                    .Distinct()
                    .OrderByDescending(p => p);

                Console.WriteLine("The list of products:");
                foreach (string productName in productsList2)
                {
                    Console.WriteLine(productName);
                }
            }
            // </SnippetSBUDT544351>
        }
        static void SBUDT496552B()
        {
            // <SnippetSBUDT496552B>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // Return all contacts, ordered by last name.
                IQueryable<string> contacts = context.Contacts
                    .OrderBy(x => x.LastName)
                    .Select(x => x)
                    .Select(x => x.LastName);

                foreach (var c in contacts)
                {
                    Console.WriteLine(c);
                }
            }
            // </SnippetSBUDT496552B>
        }
        static void SBUDT496552A()
        {

            // <SnippetSBUDT496552A>
            string firstName = "John";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // Return all contacts, ordered by last name. The OrderBy before
                // the Where produces a nested query when translated to
                // canonical command trees and the ordering by last name is lost.
                IQueryable<Contact> contacts = context.Contacts
                    .OrderBy(x => x.LastName)
                    .Where(x => x.FirstName == firstName)
                    .Select(x => x);

                foreach (var c in contacts)
                {
                    Console.WriteLine(c.LastName + ", " + c.FirstName);
                }

                // Return all contacts, ordered by last name.
                IQueryable<Contact> contacts2 = context.Contacts
                    .Where(x => x.FirstName == firstName)
                    .OrderBy(x => x.LastName)
                    .Select(x => x);

                foreach (var c in contacts2)
                {
                    Console.WriteLine(c.LastName + ", " + c.FirstName);
                }
            }
            // </SnippetSBUDT496552A>
        }
        public static void UIntAsQueryParam_MQ()
        {
            // <SnippetUIntAsQueryParam_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                uint saleId = UInt32.Parse("48000");

                IQueryable<SalesOrderDetail> query = context.SalesOrderDetails
                    .Where(sale => sale.SalesOrderID == saleId)
                    .Select(sale => sale);

                try{
                // NotSupportedException exception is thrown here.
                foreach (SalesOrderDetail order in query)
                    Console.WriteLine("SalesOrderID: " + order.SalesOrderID);
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                }
            }
            // </SnippetUIntAsQueryParam_MQ>
        }

        public static void UIntAsQueryParam()
        {
            // <SnippetUIntAsQueryParam>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                uint s = UInt32.Parse("48000");

                IQueryable<SalesOrderDetail> query = from sale in context.SalesOrderDetails
                                                     where sale.SalesOrderID == s
                                                     select sale;

                // NotSupportedException exception is thrown here.
                try
                {
                    foreach (SalesOrderDetail order in query)
                        Console.WriteLine("SalesOrderID: " + order.SalesOrderID);
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                }
            }
            // </SnippetUIntAsQueryParam>
        }

        public static void EndsWithComparison()
        {
            // <SnippetEndsWithComparison>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<string> query = from p in context.Products
                                           where p.Name == "Reflector"
                                           select p.Name;

                IEnumerable<bool> q = query.Select(c => c.EndsWith("Reflector "));
                Console.WriteLine("LINQ to Entities returns: " + q.First());
                Console.WriteLine("CLR returns: " + "Reflector".EndsWith("Reflector "));
            }
            // </SnippetEndsWithComparison>
        }

        public static void SBUDT543574()
        {
            // <SnippetSBUDT543574>
            var totalDue = 11.039M;
            var salesOrderID = 500;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                // The First() and FirstOrDefault() methods which take expressions
                // as input parameters do not preserve order.
                var orders = context.SalesOrderHeaders
                    .Where(c => c.TotalDue == totalDue)
                    .OrderByDescending(c => c.SalesOrderID)
                    .Select(c => c);

                Console.WriteLine("The ordered results:");
                foreach (SalesOrderHeader order in orders)
                    Console.WriteLine("ID: {0} \t Total due: {1}", order.SalesOrderID, order.TotalDue);

                SalesOrderHeader result = context.SalesOrderHeaders
                    .Where(c => c.TotalDue == totalDue)
                    .OrderByDescending(c => c.SalesOrderID)
                    .First(c => c.SalesOrderID > salesOrderID);

                Console.WriteLine("");
                Console.WriteLine("The result returned is not the first result from the ordered list.");
                Console.WriteLine("ID: {0} \t Total due: {1}", result.SalesOrderID, result.TotalDue);
            }
        }
            // </SnippetSBUDT543574>

        public static void SBUDT555877()
        {
            // <SnippetSBUDT555877>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                Contact contact = context.Contacts.FirstOrDefault();

                // Referencing a non-scalar closure in a query will
                // throw an exception when the query is executed.
                IQueryable<string> contacts = from c in context.Contacts
                    where c == contact
                    select c.LastName;

                try
                {
                    foreach (string name in contacts)
                    {
                        Console.WriteLine("Name: ", name);
                    }
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // </SnippetSBUDT555877>
        }

# endregion
        # region "How to examples"
        public static void QueryReturnsPrimitiveValue()
        {
            // <SnippetQueryReturnsPrimitiveValue>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Int32> productQuery = from p in context.Products
                                          select p.Name.Length;

                foreach (Int32 result in productQuery)
                {
                    Console.WriteLine(result);
                }
            }
            // </SnippetQueryReturnsPrimitiveValue>
        }

        public static void DistinctHowTo()
        {
            // <SnippetDistinctHowTo>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<string> contactsQuery = from c in context.Contacts
                                    select c.LastName;

                IQueryable<string> distinctNames = contactsQuery.Distinct();

                foreach (string name in distinctNames)
                {
                    Console.WriteLine("Name: {0}", name);
                }
            }
            // </SnippetDistinctHowTo>
        }

        public static void CSWalkthrough()
        {
            //<SnippetCSWalkthrough>
            string color = "Red";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Product> query =
                    from product in context.Products
                    where product.Color == color
                    select product;

                foreach (Product product in query)
                {
                    Console.WriteLine("Name: {0}", product.Name);
                    Console.WriteLine("List price: ${0}", product.ListPrice);
                    Console.WriteLine("");
                }
            }

            //Prevent the console window from closing.
            Console.WriteLine("Hit Enter...");
            Console.Read();
            //</SnippetCSWalkthrough>
        }

        # endregion

        # region Function Mapping

        static void FunctionMapping()
        {
            // <SnippetFunctionMapping>
            string line1 = "Algiers Dr.";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Address> query = from address in context.Addresses
                                            where address.AddressLine1.Contains(line1)
                                            select address;

                // Addresses on Algiers Dr.
                foreach (Address algiersAddress in query)
                {
                    Console.WriteLine("Address 1: " + algiersAddress.AddressLine1);
                }
            }
            // </SnippetFunctionMapping>
        }

        static void FunctionMapping2()
        {
            // <SnippetFunctionMapping2>
            string line1 = "3842 Algiers Dr.";
            string strToSeek = "Dr.";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                int index = context.Addresses
                    .Where(a => a.AddressLine1.Equals(line1))
                    .Select(a => a.AddressLine1.IndexOf(strToSeek))
                    .First();

                // Addresses on Algiers Dr.
                Console.WriteLine("index: " + index);
                Console.WriteLine("index: " + line1.IndexOf(strToSeek));
            }
            // </SnippetFunctionMapping2>
        }

        static void FunctionMappingWorkAround()
        {
            // <SnippetFunctionMappingWorkAround>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
            }
            // </SnippetFunctionMappingWorkAround>
        }
        # endregion

        # region Compiled Query Examples
        // <SnippetCompiledQuery1_MQ>
        static readonly Func<AdventureWorksEntities, ObjectQuery<SalesOrderHeader>> s_compiledQuery1 =
            CompiledQuery.Compile<AdventureWorksEntities, ObjectQuery<SalesOrderHeader>>(
                    ctx => ctx.SalesOrderHeaders);

        static void CompiledQuery1_MQ()
        {

            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<SalesOrderHeader> orders = s_compiledQuery1.Invoke(context);

                foreach (SalesOrderHeader order in orders)
                    Console.WriteLine(order.SalesOrderID);
            }
        }
        // </SnippetCompiledQuery1_MQ>

        // <SnippetCompiledQuery2>
        static readonly Func<AdventureWorksEntities, Decimal, IQueryable<SalesOrderHeader>> s_compiledQuery2 =
            CompiledQuery.Compile<AdventureWorksEntities, Decimal, IQueryable<SalesOrderHeader>>(
                    (ctx, total) => from order in ctx.SalesOrderHeaders
                                    where order.TotalDue >= total
                                    select order);

        static void CompiledQuery2()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                Decimal totalDue = 200.00M;

                IQueryable<SalesOrderHeader> orders = s_compiledQuery2.Invoke(context, totalDue);

                foreach (SalesOrderHeader order in orders)
                {
                    Console.WriteLine("ID: {0}  Order date: {1} Total due: {2}",
                        order.SalesOrderID,
                        order.OrderDate,
                        order.TotalDue);
                }
            }
        }
        // </SnippetCompiledQuery2>

        static readonly Func<AdventureWorksEntities, Decimal, IQueryable<SalesOrderHeader>> s_compiledQuery2MQ =
            CompiledQuery.Compile<AdventureWorksEntities, Decimal, IQueryable<SalesOrderHeader>>(
                    (ctx, total) => ctx.SalesOrderHeaders
                    .Where(s => s.TotalDue >= total)
                    .Select(s => s));

        static void CompiledQuery2_MQ()
        {
            // <SnippetCompiledQuery2_MQ>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                Decimal totalDue = 200.00M;

                IQueryable<SalesOrderHeader> orders = s_compiledQuery2MQ.Invoke(context, totalDue);

                foreach (SalesOrderHeader order in orders)
                {
                    Console.WriteLine("ID: {0}  Order date: {1} Total due: {2}",
                        order.SalesOrderID,
                        order.OrderDate,
                        order.TotalDue);
                }
            }
        }
        // </SnippetCompiledQuery2_MQ>

        // <SnippetCompiledQuery3_MQ>
        static readonly Func<AdventureWorksEntities, Decimal> s_compiledQuery3MQ = CompiledQuery.Compile<AdventureWorksEntities, Decimal>(
                    ctx => ctx.Products.Average(product => product.ListPrice));

        static void CompiledQuery3_MQ()
        {

            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                Decimal averageProductPrice = s_compiledQuery3MQ.Invoke(context);

                Console.WriteLine("The average of the product list prices is $: {0}", averageProductPrice);
            }
        }
        // </SnippetCompiledQuery3_MQ>

        // <SnippetCompiledQuery4_MQ>
        static readonly Func<AdventureWorksEntities, string, Contact> s_compiledQuery4MQ =
            CompiledQuery.Compile<AdventureWorksEntities, string, Contact>(
                    (ctx, name) => ctx.Contacts.First(contact => contact.EmailAddress.StartsWith(name)));

        static void CompiledQuery4_MQ()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                string contactName = "caroline";
                Contact foundContact = s_compiledQuery4MQ.Invoke(context, contactName);

                Console.WriteLine("An email address starting with 'caroline': {0}",
                    foundContact.EmailAddress);
            }
        }
        // </SnippetCompiledQuery4_MQ>

        // <SnippetCompiledQuery5>
        static readonly Func<AdventureWorksEntities, DateTime, Decimal, IQueryable<SalesOrderHeader>> s_compiledQuery5 =
            CompiledQuery.Compile<AdventureWorksEntities, DateTime, Decimal, IQueryable<SalesOrderHeader>>(
                    (ctx, orderDate, totalDue) => from product in ctx.SalesOrderHeaders
                                                  where product.OrderDate > orderDate
                                                     && product.TotalDue < totalDue
                                                  orderby product.OrderDate
                                                  select product);

        static void CompiledQuery5()
        {
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                DateTime date = new DateTime(2003, 3, 8);
                Decimal amountDue = 300.00M;

                IQueryable<SalesOrderHeader> orders = s_compiledQuery5.Invoke(context, date, amountDue);

                foreach (SalesOrderHeader order in orders)
                {
                    Console.WriteLine("ID: {0} Order date: {1} Total due: {2}", order.SalesOrderID, order.OrderDate, order.TotalDue);
                }
            }
        }
        // </SnippetCompiledQuery5>

        static void CompiledQuery6()
        {
            // <SnippetCompiledQuery6>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var compiledQuery = CompiledQuery.Compile((AdventureWorksEntities ctx, DateTime orderDate) =>
                    from order in ctx.SalesOrderHeaders
                    where order.OrderDate > orderDate
                    select new {order.OrderDate, order.SalesOrderID, order.TotalDue});

                DateTime date = new DateTime(2004, 3, 8);
                var results = compiledQuery.Invoke(context, date);

                foreach (var order in results)
                {
                    Console.WriteLine("ID: {0} Order date: {1} Total due: {2}", order.SalesOrderID, order.OrderDate, order.TotalDue);
                }
            }
            // </SnippetCompiledQuery6>
        }

        //<SnippetMyParamsStruct>
        struct MyParams
        {
            public DateTime startDate;
            public DateTime endDate;
            public decimal totalDue;
        }
        //</SnippetMyParamsStruct>

        // <SnippetCompiledQuery7>
        static Func<AdventureWorksEntities, MyParams, IQueryable<SalesOrderHeader>> s_compiledQuery =
            CompiledQuery.Compile<AdventureWorksEntities, MyParams, IQueryable<SalesOrderHeader>>(
                    (ctx, myparams) => from sale in ctx.SalesOrderHeaders
                                       where sale.ShipDate > myparams.startDate && sale.ShipDate < myparams.endDate
                                       && sale.TotalDue > myparams.totalDue
                                       select sale);
        static void CompiledQuery7()
        {

            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                MyParams myParams = new MyParams();
                myParams.startDate = new DateTime(2003, 3, 3);
                myParams.endDate = new DateTime(2003, 3, 8);
                myParams.totalDue = 700.00M;

                IQueryable<SalesOrderHeader> sales = s_compiledQuery.Invoke(context, myParams);

                foreach (SalesOrderHeader sale in sales)
                {
                    Console.WriteLine("ID: {0}", sale.SalesOrderID);
                    Console.WriteLine("Ship date: {0}", sale.ShipDate);
                    Console.WriteLine("Total due: {0}", sale.TotalDue);
                }
            }
        }
        // </SnippetCompiledQuery7>
        # endregion

	static void ProjectToAnonType()
        {
            //<snippetProjToAnonType1>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var resultWithoutRelatedObjects =
                    context.Contacts.Include("SalesOrderHeaders").Select(c => new { c }).FirstOrDefault();
                if (resultWithoutRelatedObjects.c.SalesOrderHeaders.Count == 0)
                {
                    Console.WriteLine("No orders are included.");
                }
            }
            //</snippetProjToAnonType1>
            //<snippetProjToAnonType2>
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var resultWithRelatedObjects =
                    context.Contacts.Include("SalesOrderHeaders").Select(c => c).FirstOrDefault();
                if (resultWithRelatedObjects.SalesOrderHeaders.Count != 0)
                {
                    Console.WriteLine("Orders are included.");
                }
            }
            //</snippetProjToAnonType2>
        }
    }
}
