using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs_DLinqQueryExamples
{
    // LINQ to SQL Query Example Snippets
    class Program
    {

        static void Main(string[] args)
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            ////////////////////////// A G G R E G A T E S /////////////////

            /////////////////////////////// A V E R A G E //////////////////

            // <Snippet1>
            System.Nullable<Decimal> averageFreight =
                (from ord in db.Orders
                select ord.Freight)
                .Average();

            Console.WriteLine(averageFreight);
            // </Snippet1>

            // <Snippet2>
            System.Nullable<Decimal> averageUnitPrice =
                (from prod in db.Products
                select prod.UnitPrice)
                .Average();

            Console.WriteLine(averageUnitPrice);
            // </Snippet2>

            // <Snippet3>
            var priceQuery =
                from prod in db.Products
                group prod by prod.CategoryID into grouping
                select new
                {
                    grouping.Key,
                    ExpensiveProducts =
                        from prod2 in grouping
                        where prod2.UnitPrice > grouping.Average(prod3 =>
                            prod3.UnitPrice)
                    select prod2
                };

            foreach (var grp in priceQuery)
            {
                Console.WriteLine(grp.Key);
                foreach (var listing in grp.ExpensiveProducts)
                {
                    Console.WriteLine(listing.ProductName);
                }
            }
            // </Snippet3>

            ///////////////////////// C O U N T ////////////////////////////
            // <Snippet4>
            System.Int32 customerCount = db.Customers.Count();
            Console.WriteLine(customerCount);
            // </Snippet4>

            // <Snippet5>
            System.Int32 notDiscontinuedCount =
                (from prod in db.Products
                where !prod.Discontinued
                select prod)
                .Count();

            Console.WriteLine(notDiscontinuedCount);
            // </Snippet5>

            ///////////////////////////////////// M A X ///////////////////////////

            // <Snippet6>
            System.Nullable<DateTime> latestHireDate =
                (from emp in db.Employees
                select emp.HireDate)
                .Max();

            Console.WriteLine(latestHireDate);
            // </Snippet6>

            // <Snippet7>
            System.Nullable<Int16> maxUnitsInStock =
                (from prod in db.Products
                select prod.UnitsInStock)
                .Max();

            Console.WriteLine(maxUnitsInStock);
            // </Snippet7>

            // <Snippet8>
            var maxQuery =
                from prod in db.Products
                group prod by prod.CategoryID into grouping
                select new
                {
                    grouping.Key,
                    MostExpensiveProducts =
                        from prod2 in grouping
                        where prod2.UnitPrice == grouping.Max(prod3 =>
                            prod3.UnitPrice)
                        select prod2
                };

            foreach (var grp in maxQuery)
            {
                Console.WriteLine(grp.Key);
                foreach (var listing in grp.MostExpensiveProducts)
                {
                    Console.WriteLine(listing.ProductName);
                }
            }
            // </Snippet8>

            //////////////////////////////////////// M I N ////////////////////////////
            // <Snippet9>
            System.Nullable<Decimal> lowestUnitPrice =
                (from prod in db.Products
                select prod.UnitPrice)
                .Min();

            Console.WriteLine(lowestUnitPrice);
            // </Snippet9>

            // <Snippet10>
            System.Nullable<Decimal> lowestFreight =
                (from ord in db.Orders
                select ord.Freight)
                .Min();

            Console.WriteLine(lowestFreight);
            // </Snippet10>

            // <Snippet11>
            var minQuery =
                from prod in db.Products
                group prod by prod.CategoryID into grouping
                select new
                {
                    grouping.Key,
                    LeastExpensiveProducts =
                        from prod2 in grouping
                        where prod2.UnitPrice == grouping.Min(prod3 =>
                        prod3.UnitPrice)
                        select prod2
                };

            foreach (var grp in minQuery)
            {
                Console.WriteLine(grp.Key);
                foreach (var listing in grp.LeastExpensiveProducts)
                {
                    Console.WriteLine(listing.ProductName);
                }
            }
            // </Snippet11>

            ///////////////////////////// S U M //////////////////////
            // <Snippet12>
            System.Nullable<Decimal> totalFreight =
                (from ord in db.Orders
                select ord.Freight)
                .Sum();

            Console.WriteLine(totalFreight);
            // </Snippet12>

            // <Snippet13>
            System.Nullable<long> totalUnitsOnOrder =
                (from prod in db.Products
                select (long)prod.UnitsOnOrder)
                .Sum();

            Console.WriteLine(totalUnitsOnOrder);
            // </Snippet13>
            /////////////////////////////// END OF AGGREGATES //////////////////////

            //////////////////////// F I R S T ///////////////////////
            // <Snippet14>
            Shipper shipper = db.Shippers.First();
            Console.WriteLine("ID = {0}, Company = {1}", shipper.ShipperID,
                shipper.CompanyName);
            // </Snippet14>

            // <Snippet15>
            Customer custQuery =
                (from custs in db.Customers
                where custs.CustomerID == "BONAP"
                select custs)
                .First();

            Console.WriteLine("ID = {0}, Contact = {1}", custQuery.CustomerID,
                custQuery.ContactName);
            // </Snippet15>

            ////////////////////////// T A K E / S K I P /////////////////////
            // <Snippet16>
            IQueryable<Employee> firstHiredQuery =
                (from emp in db.Employees
                orderby emp.HireDate
                select emp)
                .Take(5);

            foreach (Employee empObj in firstHiredQuery)
            {
                Console.WriteLine("{0}, {1}", empObj.EmployeeID,
                    empObj.HireDate);
            }
            // </Snippet16>

            // <Snippet17>
            IQueryable<Product> lessExpensiveQuery =
                (from prod in db.Products
                orderby prod.UnitPrice descending
                select prod)
                .Skip(10);

            foreach (Product prodObj in lessExpensiveQuery)
            {
                Console.WriteLine(prodObj.ProductName);
            }
            // </Snippet17>

            // <Snippet18>
            var custQuery2 =
                (from cust in db.Customers
                orderby cust.ContactName
                select cust)
                .Skip(50).Take(10);

            foreach (var custRecord in custQuery2)
            {
                Console.WriteLine(custRecord.ContactName);
            }
            // </Snippet18>

            // <Snippet19>
            IQueryable<Customer> custQuery3 =
                (from custs in db.Customers
                 where custs.City == "London"
                 orderby custs.CustomerID
                 select custs)
                .Skip(1).Take(1);

            foreach (var custObj in custQuery3)
            {
                Console.WriteLine(custObj.CustomerID);
            }
            // </Snippet19>

            /////////////////////////// S O R T ///////////////////////
            // <Snippet20>
            IOrderedQueryable<Employee> hireQuery =
                from emp in db.Employees
                orderby emp.HireDate
                select emp;

            foreach (Employee empObj in hireQuery)
            {
                Console.WriteLine("EmpID = {0}, Date Hired = {1}",
                    empObj.EmployeeID, empObj.HireDate);
            }
            // </Snippet20>

            // <Snippet21>
            IOrderedQueryable<Order> freightQuery =
                from ord in db.Orders
                where ord.ShipCity == "London"
                orderby ord.Freight
                select ord;

            foreach (Order ordObj in freightQuery)
            {
                Console.WriteLine("Order ID = {0}, Freight = {1}",
                    ordObj.OrderID, ordObj.Freight);
            }
            // </Snippet21>

            // S22, S23, S24 live in outofscope methods

            // <Snippet25>
            IOrderedQueryable<Order> ordQuery =
                from ord in db.Orders
                where ord.EmployeeID == 1
                orderby ord.ShipCountry, ord.Freight descending
                select ord;

            foreach (Order ordObj in ordQuery)
            {
                Console.WriteLine("Country = {0}, Freight = {1}",
                    ordObj.ShipCountry, ordObj.Freight);
            }
            // </Snippet25>

            // <Snippet26>
            var highPriceQuery =
                from prod in db.Products
                group prod by prod.CategoryID into grouping
                orderby grouping.Key
                select new
                {
                    grouping.Key,
                    MostExpensiveProducts =
                        from prod2 in grouping
                        where prod2.UnitPrice == grouping.Max(p3 => p3.UnitPrice)
                        select prod2
                };

            foreach (var prodObj in highPriceQuery)
            {
                Console.WriteLine(prodObj.Key);
                foreach (var listing in prodObj.MostExpensiveProducts)
                {
                    Console.WriteLine(listing.ProductName);
                }
            }
            // </Snippet26>

            ////////////////////// G R O U P //////////////////////////////
            // <Snippet27>
            IQueryable<IGrouping<Int32?, Product>> prodQuery =
                from prod in db.Products
                group prod by prod.CategoryID into grouping
                select grouping;

            foreach (IGrouping<Int32?, Product> grp in prodQuery)
            {
                Console.WriteLine($"\nCategoryID Key = {grp.Key}:");
                foreach (Product listing in grp)
                {
                    Console.WriteLine($"\t{listing.ProductName}");
                }
            }
            // </Snippet27>

            // <Snippet28>
            var q =
                from p in db.Products
                group p by p.CategoryID into g
                select new
                {
                    g.Key,
                    MaxPrice = g.Max(p => p.UnitPrice)
                };
            // </Snippet28>

            // <Snippet29>
            var q2 =
                from p in db.Products
                group p by p.CategoryID into g
                select new
                {
                    g.Key,
                    AveragePrice = g.Average(p => p.UnitPrice)
                };
            // </Snippet29>

            // S30 lives in separate method.

            // <Snippet31>
            var disconQuery =
                from prod in db.Products
                group prod by prod.CategoryID into grouping
                select new
                {
                    grouping.Key,
                    NumProducts = grouping.Count(p => p.Discontinued)
                };

            foreach (var prodObj in disconQuery)
            {
                Console.WriteLine("CategoryID = {0}, Discontinued# = {1}",
                    prodObj.Key, prodObj.NumProducts);
            }
            // </Snippet31>

            // <Snippet32>
            var prodCountQuery =
                from prod in db.Products
                group prod by prod.CategoryID into grouping
                where grouping.Count() >= 10
                select new
                {
                    grouping.Key,
                    ProductCount = grouping.Count()
                };

            foreach (var prodCount in prodCountQuery)
            {
                Console.WriteLine("CategoryID = {0}, Product count = {1}",
                    prodCount.Key, prodCount.ProductCount);
            }
            // </Snippet32>

            // S33, S34 live in separate methods.

            // <Snippet35>
            var custRegionQuery =
                from cust in db.Customers
                group cust.ContactName by new { City = cust.City, Region = cust.Region };

            foreach (var grp in custRegionQuery)
            {
                Console.WriteLine($"\nLocation Key: {grp.Key}");
                foreach (var listing in grp)
                {
                    Console.WriteLine($"\t{listing}");
                }
            }
            // </Snippet35>

            //////////////////// D I S T I N C T ///////////////////////

            // <Snippet36>
            IQueryable<String> cityQuery =
                (from cust in db.Customers
                select cust.City).Distinct();

            foreach (String cityString in cityQuery)
            {
                Console.WriteLine(cityString);
            }
            // </Snippet36>

            //////////////////// A N Y   O R   A L L /////////////////
            // <Snippet37>
            var OrdersQuery =
                from cust in db.Customers
                where cust.Orders.Any()
                select cust;
            // </Snippet37>

            // <Snippet38>
            var custEmpQuery =
                from cust in db.Customers
                where cust.Orders.All(o => o.ShipCity.StartsWith("C"))
                orderby cust.CustomerID
                select cust;

            foreach (Customer custObj in custEmpQuery)
            {
                if (custObj.Orders.Count > 0)
                    Console.WriteLine($"CustomerID: {custObj.CustomerID}");
                foreach (Order ordObj in custObj.Orders)
                {
                    Console.WriteLine($"\t OrderID: {ordObj.OrderID}; ShipCity: {ordObj.ShipCity}");
                }
            }
            // </Snippet38>

            ////////////////////// C O N C A T E N A T E /////////////////

            // S39 lives in separate method.

            // <Snippet40>
            var infoQuery =
                (from cust in db.Customers
                select new { Name = cust.CompanyName, cust.Phone }
                )
               .Concat
                   (from emp in db.Employees
                   select new
                   {
                       Name = emp.FirstName + " " + emp.LastName,
                       Phone = emp.HomePhone
                   }
                   );

            foreach (var infoData in infoQuery)
            {
                Console.WriteLine("Name = {0}, Phone = {1}",
                    infoData.Name, infoData.Phone);
            }
            // </Snippet40>

            /////////////////// S E T   D I F F E R E N C E ////////////////////

            // S41 lives in separate method.

            ////////////////// S E T   I N T E R S E C T I O N //////////////
            // S42 lives in separate method.

            /////////////////// S E T   U N I O N ///////////////////////
            // S43 lives in separate method.

            ////////// C O N V E R T   S E Q   T O   A R R A Y ///////////
            // S44 lives in separate method.

            //////// C O N V E R T   S E Q   T O   G E N   L I S T ////////
            // <Snippet45>
            var empQuery =
                from emp in db.Employees
                where emp.HireDate >= new DateTime(1994, 1, 1)
                select emp;
                List<Employee> qList = empQuery.ToList();
            // </Snippet45>

            ////// C O N V E R T   T Y P E   T O   G E N   I E N U M //////
            // Code for this topic is in separate section below.

            /////////////////// J O I N S   E T C . /////////////////////////
            // There are 10 of these. All live in separate methods.
            // S47, S48, S49, S50, S51, S52, S53, S54, S55, S56 live in separate methods.

            ////////////// F O R M U L A T E   P R O J E C T I O N S ////////////////
            // There are 9 of these.

            // <Snippet57>
            var nameQuery =
                from cust in db.Customers
                select cust.ContactName;
            // </Snippet57>

            //S58 lives in separate method.

            // <Snippet59>
            var info2Query =
                from emp in db.Employees
                select new
                {
                    Name = emp.FirstName + " " + emp.LastName,
                    Phone = emp.HomePhone
                };
            // </Snippet59>

            // <Snippet60>
            var specialQuery =
                from prod in db.Products
                select new { prod.ProductID, HalfPrice = prod.UnitPrice / 2 };
            // </Snippet60>

            // S61, S62 live in separate methods.

            // <Snippet63>
            var contactQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust.ContactName;
            // </Snippet63>

            // S64, S65 live in a separate methods.

            /////////////////// E N D   O F   Q U E R I E S ////////
        } //end of Main

        //////////////////////// OUT OF SCOPE METHODS ////////////////
        // Separated to prevent repeating local variables.

        void method22()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet22>
            IOrderedQueryable<Product> priceQuery =
                from prod in db.Products
                orderby prod.UnitPrice descending
                select prod;

            foreach (Product prodObj in priceQuery)
            {
                Console.WriteLine("Product ID = {0}, Unit Price = {1}",
                    prodObj.ProductID, prodObj.UnitPrice);
            }
            // </Snippet22>
        }

        //    // this was a dup of 22
        //    void method23()
        //    {
        //        Northwnd db = new Northwnd(@"c:\northwnd.mdf");
        //        // <Snippet23>
        //        IOrderedQueryable<Product> priceQuery =
        //from prod in db.Products
        //orderby prod.UnitPrice descending
        //select prod;

        //        foreach (Product prodObj in priceQuery)
        //        {
        //            Console.WriteLine("Product ID = {0}, Unit Price = {1}",
        //                prodObj.ProductID, prodObj.UnitPrice);
        //        }

        //        // </Snippet23>
        //    }

        void method24()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet24>
            IOrderedQueryable<Customer> custQuery =
                from cust in db.Customers
                orderby cust.City, cust.ContactName
                select cust;

            foreach (Customer custObj in custQuery)
            {
                Console.WriteLine("City = {0}, Name = {1}", custObj.City,
                    custObj.ContactName);
            }

            // </Snippet24>
        }

        void method30()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet30>
            var priceQuery =
                from prod in db.Products
                group prod by prod.CategoryID into grouping
                select new
                {
                    grouping.Key,
                    TotalPrice = grouping.Sum(p => p.UnitPrice)
                };

            foreach (var grp in priceQuery)
            {
                Console.WriteLine("Category = {0}, Total price = {1}",
                    grp.Key, grp.TotalPrice);
            }

            // </Snippet30>
        }

        void method33()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet33>
            var prodQuery =
                from prod in db.Products
                group prod by new
                {
                    prod.CategoryID,
                    prod.SupplierID
                }
                into grouping
                select new { grouping.Key, grouping };

            foreach (var grp in prodQuery)
            {
                Console.WriteLine("\nCategoryID {0}, SupplierID {1}",
                    grp.Key.CategoryID, grp.Key.SupplierID);
                foreach (var listing in grp.grouping)
                {
                    Console.WriteLine($"\t{listing.ProductName}");
                }
            }
            // </Snippet33>
        }

        void method34()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet34>
            var priceQuery =
                from prod in db.Products
                group prod by new
                {
                    Criterion = prod.UnitPrice > 10
                }
                into grouping
                select grouping;

            foreach (var prodObj in priceQuery)
            {
                if (prodObj.Key.Criterion == false)
                    Console.WriteLine("Prices 10 or less:");
                else
                    Console.WriteLine("\nPrices greater than 10");
                foreach (var listing in prodObj)
                {
                    Console.WriteLine("{0}, {1}", listing.ProductName,
                        listing.UnitPrice);
                }
            }
            // </Snippet34>
        }

        void method39()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet39>
            IQueryable<String> custQuery =
                (from cust in db.Customers
                select cust.Phone)
                .Concat
                (from cust in db.Customers
                select cust.Fax)
                .Concat
                (from emp in db.Employees
                select emp.HomePhone)
            ;

            foreach (var custData in custQuery)
            {
                Console.WriteLine(custData);
            }

            // </Snippet39>
        }

        void method41()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet41>
            var infoQuery =
                (from cust in db.Customers
                select cust.Country)
                .Except
                    (from emp in db.Employees
                    select emp.Country)
            ;
            // </Snippet41>
        }

        void method42()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet42>
            var infoQuery =
                (from cust in db.Customers
                select cust.Country)
                .Intersect
                    (from emp in db.Employees
                    select emp.Country)
            ;
            // </Snippet42>
        }

        void method43()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet43>
            var infoQuery =
                (from cust in db.Customers
                select cust.Country)
                .Union
                    (from emp in db.Employees
                    select emp.Country)
            ;
            // </Snippet43>
        }

        void method44()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet44>
            var custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;
                Customer[] qArray = custQuery.ToArray();

            // </Snippet44>
        }

        void method47()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet47>
            var infoQuery =
                from cust in db.Customers
                from ord in cust.Orders
                where cust.City == "London"
                select ord;
            // </Snippet47>
        }

        void method48()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet48>
            var infoQuery =
                from prod in db.Products
                where prod.Supplier.Country == "USA" && prod.UnitsInStock == 0
                select prod;
            // </Snippet48>
        }

        void method49()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet49>
            var infoQuery =
                from emp in db.Employees
                from empterr in emp.EmployeeTerritories
                where emp.City == "Seattle"
                select new
                {
                    emp.FirstName,
                    emp.LastName,
                    empterr.Territory.TerritoryDescription
                };
            // </Snippet49>
        }

        void method50()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet50>
            var infoQuery =
                from emp1 in db.Employees
                from emp2 in emp1.Employees
                where emp1.City == emp2.City
                select new
                {
                    FirstName1 = emp1.FirstName,
                    LastName1 = emp1.LastName,
                    FirstName2 = emp2.FirstName,
                    LastName2 = emp2.LastName,
                    emp1.City
                };

            // </Snippet50>
        }

        void method51()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet51>
            var q =
                from c in db.Customers
                join o in db.Orders on c.CustomerID equals o.CustomerID
                    into orders
                select new { c.ContactName, OrderCount = orders.Count() };
            // </Snippet51>
        }

        void method52()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet52>
            var q =
                from c in db.Customers
                join o in db.Orders on c.CustomerID equals o.CustomerID
                    into ords
                join e in db.Employees on c.City equals e.City into emps
                select new
                {
                    c.ContactName,
                    ords = ords.Count(),
                    emps = emps.Count()
                };
            // </Snippet52>
        }

        void method53()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet53>
            var q =
                from e in db.Employees
                join o in db.Orders on e equals o.Employee into ords
                    from o in ords.DefaultIfEmpty()
                    select new { e.FirstName, e.LastName, Order = o };
            // </Snippet53>
        }

        void method54()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet54>
            var q =
                from c in db.Customers
                join o in db.Orders on c.CustomerID equals o.CustomerID
                    into ords
                let z = c.City + c.Country
                    from o in ords
                    select new { c.ContactName, o.OrderID, z };
            // </Snippet54>
        }

        void method55()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet55>
            var q =
                from o in db.Orders
                from p in db.Products
                join d in db.OrderDetails
                    on new { o.OrderID, p.ProductID } equals new
                {
                    d.OrderID,
                    d.ProductID
                } into details
                    from d in details
                    select new { o.OrderID, p.ProductID, d.UnitPrice };
            // </Snippet55>
        }

        void method56()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet56>
            var q =
                from o in db.Orders
                join e in db.Employees
                    on o.EmployeeID equals (int?)e.EmployeeID into emps
                    from e in emps
                    select new { o.OrderID, e.FirstName };
            // </Snippet56>
        }

        void method58()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet58>
            var infoQuery =
                from cust in db.Customers
                select new { cust.ContactName, cust.Phone };
            // </Snippet58>
        }

        void method61()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet61>
            var prodQuery =
                from prod in db.Products
                select new
                {
                    prod.ProductName,
                    Availability =
                        prod.UnitsInStock - prod.UnitsOnOrder < 0
                    ? "Out Of Stock" : "In Stock"
                };
            // </Snippet61>
        }

        void method64()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet64>
            var custQuery =
                from cust in db.Customers
                select new
                {
                    cust.CustomerID,
                    CompanyInfo = new { cust.CompanyName, cust.City, cust.Country },
                    ContactInfo = new { cust.ContactName, cust.ContactTitle }
                };
            // </Snippet64>
        }

        void method65()
        {
            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            // <Snippet65>
            var ordQuery =
                from ord in db.Orders
                select new
                {
                    ord.OrderID,
                    DiscountedProducts =
                        from od in ord.OrderDetails
                        where od.Discount > 0.0
                        select od,
                    FreeShippingDiscount = ord.Freight
                };
        // </Snippet65>
  } //end of class Program

        // <Snippet46>
        private bool isValidProduct(Product prod)
        {
            return prod.ProductName.LastIndexOf('C') == 0;
        }

        void ConvertToIEnumerable()
        {
            Northwnd db = new Northwnd(@"c:\test\northwnd.mdf");
            Program pg = new Program();
            var prodQuery =
                from prod in db.Products.AsEnumerable()
                where isValidProduct(prod)
                select prod;
        }
        // </Snippet46>

        // <Snippet62>
        public class Name
        {
            public string FirstName = "";
            public string LastName = "";
        }

         void empMethod()
         {
         Northwnd db = new Northwnd(@"c:\northwnd.mdf");
         var empQuery =
             from emp in db.Employees
             select new Name
             {
                 FirstName = emp.FirstName,
                 LastName = emp.LastName
             };
        }
        // </Snippet62>
        }
    }
