using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
namespace LightSwitchApplication
{
    public partial class OrdersListDetail
    {
        //<Snippet8>
        partial void RetrieveCustomer_Execute()
        {
            Order order = this.DataWorkspace.NorthwindData.Orders_Single
                (Orders.SelectedItem.OrderID);

            Customer cust = order.Customer;
            //Perform some task on the customer entity.

        }
        //</Snippet8>
    }
}
