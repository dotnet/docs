using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class Order
    {

        partial void OrderDate_Validate
            (EntityValidationResultsBuilder results)
        {
            if (this.RequiredDate <= DateTime.Today)
            {
                results.AddPropertyError("Due date must be later than order date");
            }

        }

        //<Snippet19>
        partial void RequiredDate_Validate(EntityValidationResultsBuilder results)
        {
            if (this.RequiredDate < this.OrderDate)
            {
                results.AddEntityError
                    ("Required data cannot be earlier than the order date"); 
            }

        }
        //</Snippet19>
        //<Snippet2>
        partial void ShippedDate_Validate(EntityValidationResultsBuilder results)
        {
            if (this.ShippedDate > DateTime.Today)
            {
                results.AddPropertyError("Shipped date cannot be later than today");
            }

        }
        //</Snippet2>
        
 
    }
}
