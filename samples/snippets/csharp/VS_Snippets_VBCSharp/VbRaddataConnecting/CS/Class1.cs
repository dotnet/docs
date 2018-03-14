using System;

namespace ObjectBindingWalkthrough
{
    public class Class1
    {
        void OtherSnips()
        {
            System.Windows.Forms.BindingSource customerBindingSource = 
                new System.Windows.Forms.BindingSource();
        
            //<Snippet5>
            Customer currentCustomer = new Customer();
            customerBindingSource.Add(currentCustomer);
            //</Snippet5>

            //<Snippet6>
            Order currentOrder = new Order();
            currentCustomer.Orders.Add(currentOrder);
            //</Snippet6>

            //<Snippet7>
            int customerIndex = customerBindingSource.Find("CustomerID", "ALFKI");
            customerBindingSource.RemoveAt(customerIndex);
            //</Snippet7>
        }
    }
}


namespace WrapOrders
{
    public class Order{}

    //<Snippet8>
    /// <summary>
    /// A collection of Orders
    /// </summary>
    public class Orders: System.ComponentModel.BindingList<Order>
    {
        // Add any additional functionality required by your collection.
    }
    //</Snippet8>
}
