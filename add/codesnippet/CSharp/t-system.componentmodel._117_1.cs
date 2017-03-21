using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;


[MetadataType(typeof(CustomerMetaData))]
public partial class Customer
{

 
}

public class CustomerMetaData
{

    // Add type information.
    [DataType(DataType.EmailAddress)]
    public object EmailAddress;

}
