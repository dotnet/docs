using System;
//using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.Data.Objects;
using System.Data.Objects.SqlClient;

namespace CanonicalAndStoreFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            A();
            B();
            C();
            D();
        }

        public static void A()
        {
            //<snippet1>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = from p in AWEntities.Products
                               where EntityFunctions.DiffDays(p.SellEndDate, p.SellStartDate) < 365
                               select p;
                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductID);
                }
            }
            //</snippet1>
        }

        public static void B()
        {
            //<snippet2>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                double? stdDev = EntityFunctions.StandardDeviation(
                    from o in AWEntities.SalesOrderHeaders
                    select o.SubTotal);

                Console.WriteLine(stdDev);
            }
            //</snippet2>
        }

        public static void C()
        {
            //<snippet3>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                // SqlFunctions.CharIndex is executed in the database.
                var contacts = from c in AWEntities.Contacts
                               where SqlFunctions.CharIndex("Si", c.LastName) == 1
                               select c;

                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact.LastName);
                }
            }
            //</snippet3>
        }

        public static void D()
        {
            //<snippet4>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                // SqlFunctions.ChecksumAggregate is executed in the database.
                decimal? checkSum = SqlFunctions.ChecksumAggregate(
                    from o in AWEntities.SalesOrderHeaders
                    select o.SalesOrderID);

                Console.WriteLine(checkSum);
            }
            //</snippet4>
        }
    }
}
