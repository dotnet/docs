using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

[MetadataType(typeof(ProductMetaData))]
public partial class Product
{

}


public class ProductMetaData
{
    
    [Range(10, 1000, 
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public object Weight;

    [Range(300, 3000)]
    public object ListPrice;

    [Range(typeof(DateTime), "1/2/2004", "3/4/2004",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
    public object SellEndDate;

}
 