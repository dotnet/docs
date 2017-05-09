using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
namespace LightSwitchApplication
{
    public partial class NorthwindDataService
    {
        //<Snippet4>
        partial void Orders_Validate
            (Order entity, EntitySetValidationResultsBuilder results)
        {
            if (!CustomerCreditApproval(entity.Customer))
            {
                results.AddEntityError
                    ("Customer Credit has not yet been approved");
            }
        }

        private bool CustomerCreditApproval(Customer entity)
        {
            //Some custom code to check the customer's credit status.
            return true;
        }

        //</Snippet4>
        //<Snippet9>
        partial void Orders_Inserting(Order entity)
        {
            foreach (Order_Detail detail in entity.Order_Details)
            {
                detail.Product.UnitsInStock = 
                    (short?)(detail.Product.UnitsInStock - detail.Quantity);
            }
        }
        //</Snippet9>
        //<Snippet13>
        partial void Customers_CanUpdate(ref bool result)
        {
            result = this.Application.User.HasPermission(Permissions.RoleUpdate);
        }
        //</Snippet13>
        partial void TopNSalesOrders_PreprocessQuery
            (short? TopN, ref IQueryable<Customer> query)
        {
            query = (from myCustomer in query
                     where myCustomer.Orders.Count() > 0
                     orderby myCustomer.Orders.Count() descending
                     select myCustomer).Take(System.Convert.ToInt16(TopN));

        }
        //<Snippet18>
        partial void Order_Details_Inserting(Order_Detail entity)
        {
            var topCustomers =
                from myCustomers in
                this.DataWorkspace.NorthwindData.TopNSalesOrders(10).Execute()
                select myCustomers;

            var top_Germany_Customers =
                from customers in topCustomers
                where customers.Country == "Germany"
                select customers;

            foreach (Customer cust in top_Germany_Customers)
            {
                if (cust.CustomerID == entity.Order.Customer.CustomerID)
                    entity.Discount = 0.1F;
            }

        }
        //</Snippet18>
    }
}
