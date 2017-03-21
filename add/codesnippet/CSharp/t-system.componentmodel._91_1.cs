using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

[MetadataType(typeof(CustomerMetaData))]
public partial class Customer
{

   
}

public class CustomerMetaData
{
    // Require that the Title is not null.
    // Use custom validation error.
    [Required(ErrorMessage = "Title is required.")]
    public object Title;
    
    // Require that the MiddleName is not null.
    // Use standard validation error.
    [Required()]
    public object MiddleName;

}
