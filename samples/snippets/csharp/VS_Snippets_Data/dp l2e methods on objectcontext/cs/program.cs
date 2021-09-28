using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Reflection;
using System.Linq.Expressions;

namespace MethodsOnObjectContext
{
    class Program
    {
        static void Main(string[] args)
        {
            A();
            B();
            C();
        }

        public static void A()
        {
            //<snippet3>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                int productId = 776;

                Console.WriteLine(AWEntities.GetProductRevenue(productId));
            }
            //</snippet3>
        }

        public static void B()
        {
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = from p in AWEntities.Products
                               where GetProductRevenue(from s in AWEntities.SalesOrderDetails
                                                       where s.ProductID == p.ProductID
                                                       select s) > 2500000
                               select p;

                foreach (var product in products)
                {
                    Console.WriteLine(product.ProductID);
                }
            }
        }

        public static void C()
        {
            //<snippet6>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                int productId = 776;

                var details = from s in AWEntities.SalesOrderDetails
                              where s.ProductID == productId select s;

                Console.WriteLine(MyClass.GetProductRevenue(details));
            }
            //</snippet6>
        }

	public static void D()
        {
            //<snippet9>
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                int productId = 776;

                var lineTotals = AWEntities.GetDetailsById(productId).Select(d =>d.LineTotal);

                foreach(var lineTotal in lineTotals)
                {
                    Console.WriteLine(lineTotal);
                }
            }
            //</snippet9>
        }

        [EdmFunction("AdventureWorksModel", "GetProductRevenue")]
        public static decimal? GetProductRevenue(IQueryable<SalesOrderDetail> details)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
    }

    //<snippet2>
    public partial class AdventureWorksEntities : ObjectContext
    {
        [EdmFunction("AdventureWorksModel", "GetProductRevenue")]
        public decimal? GetProductRevenue(int productId)
        {
            return this.QueryProvider.Execute<decimal?>(Expression.Call(
                Expression.Constant(this),
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                Expression.Constant(productId, typeof(int))));
        }
    }
    //</snippet2>

    //<snippet5>
    public class MyClass
    {
        [EdmFunction("AdventureWorksModel", "GetProductRevenue")]
        public static decimal? GetProductRevenue(IQueryable<SalesOrderDetail> details)
        {
            return details.Provider.Execute<decimal?>(Expression.Call(
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                Expression.Constant(details, typeof(IQueryable<SalesOrderDetail>))));
        }
    }
    //</snippet5>

    //<snippet8>
    public partial class AdventureWorksEntities : ObjectContext
    {
        [EdmFunction("AdventureWorksModel", "GetDetailsById")]
        public IQueryable<SalesOrderDetail> GetDetailsById(int productId)
        {
            return this.QueryProvider.CreateQuery<SalesOrderDetail>(Expression.Call(
                Expression.Constant(this),
                (MethodInfo)MethodInfo.GetCurrentMethod(),
                Expression.Constant(productId, typeof(int))));
        }
    }
    //</snippet8>
}
