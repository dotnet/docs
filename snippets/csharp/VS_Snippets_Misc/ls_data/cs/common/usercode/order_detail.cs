using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class Order_Detail
    {
        //<Snippet1>
        partial void Subtotal_Compute(ref decimal result)
        {
            result = this.Quantity * this.UnitPrice;
        }
        //</Snippet1>
        partial void QuantityPlusOne_Compute(ref short result)
        {
            Int16 temp = 1;
            result = Convert.ToInt16(this.Quantity + temp);
        }
 

      
    }
}
