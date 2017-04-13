//<Snippet1>
using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

// <Snippet2>
[MetadataType(typeof(CustomerMetaData))]
public partial class Customer
{

   
}

// </Snippet2>

public class CustomerMetaData
{
    // <Snippet3>
    // Apply RequiredAttribute
    [Required(ErrorMessage = "Title is required.")]
    public object Title;
    // </Snippet3>

   
}

//</Snippet1>