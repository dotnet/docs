using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class Order1
    {
        //<Snippet17>
        partial void OrderDate_Validate(EntityValidationResultsBuilder results)
        {
            if (this.RequiredDate <= this.OrderDate)
            {
                results.AddEntityError("Due date must be later than order date");
            }
        }
        //</Snippet17>
    }
}
