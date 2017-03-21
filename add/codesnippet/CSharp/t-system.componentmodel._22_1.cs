using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

[MetadataType(typeof(CustomerMetaData))]
public partial class Customer
{

   
}


public class CustomerMetaData
{
    // Apply RequiredAttribute
    [Required(ErrorMessage = "Title is required.")]
    public object Title;

   
}
