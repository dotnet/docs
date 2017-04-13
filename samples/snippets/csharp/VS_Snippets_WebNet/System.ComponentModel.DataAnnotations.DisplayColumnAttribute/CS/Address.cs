//<Snippet1>
using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

//<Snippet2>
[DisplayColumn("City", "PostalCode", false)]
public partial class Address
{
   
}
//</Snippet2>


//<Snippet3>
[DisplayColumn("LastName")]
public partial class Customer
{


}
//</Snippet3>


//</Snippet1>

