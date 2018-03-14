//<Snippet1>
using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;


[MetadataType(typeof(ProductMetaData))]
public partial class Product
{

}

public class ProductMetaData
{
    
    // Applying DisplayFormatAttribute
    //<Snippet2>
    // Display the text [Null] when the data field is empty.
    // Also, convert empty string to null for storing.
    [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]
    public object Size;
    //</Snippet2>

    //<Snippet3>
    // Display currency data field in the format $1,345.50.
    [DisplayFormat(DataFormatString="{0:C}")]
    public object StandardCost;
    //</Snippet3>

    //<Snippet4>
    // Display date data field in the short format 11/12/08.
    // Also, apply format in edit mode.
    [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:d}")]
    public object SellStartDate;
    //</Snippet4>
}

// </Snippet1>
 
