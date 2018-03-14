//<Snippet1>
using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;


[MetadataType(typeof(CustomerMetaData))]
public partial class Customer
{

   
}

public class CustomerMetaData
{
   
    //<Snippet3>
    // Allow up to 40 uppercase and lowercase 
    // characters. Use custom error.
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", 
         ErrorMessage = "Characters are not allowed.")]
    public object FirstName;
    //</Snippet3>

    //<Snippet2>
    // Allow up to 40 uppercase and lowercase 
    // characters. Use standard error.
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
    public object LastName;
    //</Snippet2>
}

//</Snippet1>