using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Security.Server;
namespace LightSwitchApplication
{
    public partial class ProductDataSourceService
    {
        //<Snippet16>
        partial void Orders_Inserting(Order1 entity)
        {
            foreach (Order_Detail1 detail in entity.Order_Details)
            {
                detail.Product.UnitsInStock = (short?)
                    (detail.Product.UnitsInStock - detail.Quantity);
            }
            this.DataWorkspace.ProductDataSource.SaveChanges();

        }
        //</Snippet16>
    }
}
