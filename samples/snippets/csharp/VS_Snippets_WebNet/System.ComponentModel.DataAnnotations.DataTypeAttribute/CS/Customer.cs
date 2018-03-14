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

    // <Snippet11>
    // Add type information.
    [DataType(DataType.EmailAddress)]
    public object EmailAddress;
    // </Snippet11>

}

//</Snippet1>