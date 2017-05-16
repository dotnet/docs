using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
// Create the one-dimensional target array.
 // Dimension it large enough to hold the cookies collection.
 Array MyArray = Array.CreateInstance( typeof(String), Request.Cookies.Count );
 
 // Copy the entire collection to the array.
 Request.Cookies.CopyTo( MyArray, 0 );
    
// </Snippet1>
 }
}
