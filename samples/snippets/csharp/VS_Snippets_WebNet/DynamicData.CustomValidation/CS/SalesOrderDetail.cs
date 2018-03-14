// <Snippet2>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

public partial class SalesOrderDetail
{
    partial void OnOrderQtyChanging(short value)
    {
        if (value < 100)
        {
            throw new ValidationException(
                "Quantity is less than the allowed minimum of 100.");
        }
    }
}

// </Snippet2>

