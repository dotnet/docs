// <Snippet5>
using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

[MetadataType(typeof(ProductMetadata))]
public partial class Product 
{

}

public partial class ProductMetadata
{
    [UIHint("UnitsInStock")]
    [Range(100, 10000, 
    ErrorMessage = "Units in stock should be between {1} and {2}.")]
    public object UnitsInStock;

}
// </Snippet5>