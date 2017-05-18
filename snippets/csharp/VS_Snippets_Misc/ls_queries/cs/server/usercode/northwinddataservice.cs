using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
namespace LS_Queries_CS
{
    public partial class NorthwindDataService
    {
        //<Snippet1>
        partial void TopNSalesOrders_PreprocessQuery
            (short? TopN, ref IQueryable<Customer> query)
        {
            query = (from myCustomer in query
                     where myCustomer.Orders.Count() > 0
                     orderby myCustomer.Orders.Count() descending
                     select myCustomer).Take(System.Convert.ToInt16(TopN));
        }
        //</Snippet1>
        //<Snippet2>
        partial void CustomersWhoBoughtProduct_PreprocessQuery
            (short? ProductID, ref IQueryable<Customer> query)
        {
            query = from myCustomers in query
                    from myOrders in myCustomers.Orders
                    from myOrderDetails in myOrders.Order_Details
                    where myOrderDetails.Product.ProductID == ProductID
                    select myCustomers;
        }
        //</Snippet2>
        partial void  Order_Details_Inserting(Order_Detail entity)
        {
            Good_Customer_Discount(entity);
        }
         //<Snippet3>
        private void Good_Customer_Discount(Order_Detail entity)
        {
            foreach (Customer cust in this.DataWorkspace.NorthwindData.
         TopNSalesOrders(10))
            {
                if (cust.CustomerID == entity.Order.Customer.CustomerID)
                {
                    entity.Discount = 0.1F;
                }
            }
        }
        //</Snippet3>
        //<Snippet4>
        private void Good_Customer_Discount2(Order_Detail entity)
        {
            IDataServiceQueryable<Customer> query;

            query = from myCustomer in this.DataWorkspace.NorthwindData.
                        TopNSalesOrders(10)
                    where myCustomer.CustomerID == entity.Order.Customer.CustomerID
                    select myCustomer;
                 
            if (query.SingleOrDefault() != null)
            {
                entity.Discount = 0.1F;
            }
        }
        }
        //</Snippet4>
        
    }
}
