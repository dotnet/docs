// <Snippet2>
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

[MetadataType(typeof(CustomerMetadata))]
public partial class Customer
{

}

public class CustomerMetadata
{
    [PhoneMask("999-999-9999",
        ErrorMessage = "{0} value does not match the mask {1}.")]
    public object Phone; 
}
// </Snippet2>