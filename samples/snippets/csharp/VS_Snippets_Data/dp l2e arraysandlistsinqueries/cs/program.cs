using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L2E_ArraysAndListsInQueriesCS
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

        static void A()
        {
            //<snippet1>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                int?[] productModelIds = {19, 26, 118};
                var products = from p in AWEntities.Products
                               where productModelIds.Contains(p.ProductModelID)
                               select p;
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.ProductModelID}: {product.ProductID}");
                }
            }
            //</snippet1>
        }

        static void B()
        {
            //<snippet2>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = from p in AWEntities.Products
                               where (new int?[] { 19, 26, 18 }).Contains(p.ProductModelID) ||
                                     (new string[] { "L", "XL" }).Contains(p.Size)
                               select p;
                foreach (var product in products)
                {
                    Console.WriteLine("{0}: {1}, {2}", product.ProductID,
                                                       product.ProductModelID,
                                                       product.Size);
                }
            }
            //</snippet2>
        }

        static void C()
        {
            //<snippet3>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                int?[] productModelIds = { 19, 26, 118 };
                var products = AWEntities.Products.
                    Where(p => productModelIds.Contains(p.ProductModelID));

                foreach (var product in products)
                {
                    Console.WriteLine($"{product.ProductModelID}: {product.ProductID}");
                }
            }
            //</snippet3>
        }

        static void D()
        {
            //<snippet4>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Products.
                    Where(p => (new int?[] { 19, 26, 18 }).Contains(p.ProductModelID) ||
                               (new string[] { "L", "XL" }).Contains(p.Size));

                foreach (var product in products)
                {
                    Console.WriteLine("{0}: {1}, {2}", product.ProductID,
                                                       product.ProductModelID,
                                                       product.Size);
                }
            }
            //</snippet4>
        }
    }
}
