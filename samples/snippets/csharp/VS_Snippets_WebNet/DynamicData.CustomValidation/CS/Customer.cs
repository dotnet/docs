// <Snippet1>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

[MetadataType(typeof(CustomerMetadata))]
public partial class Customer
{
   

    partial void OnValidate(System.Data.Linq.ChangeAction action)
    {
        if (!char.IsUpper(this._LastName[0]) ||
            !char.IsUpper(this._FirstName[0])  ||
            !char.IsUpper(this._Title[0]))
            throw new ValidationException(
               "Data value must start with an uppercase letter.");
    }


}

public class CustomerMetadata
{
    [Required()]
    public object Title;

}
// </Snippet1>