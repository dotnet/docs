using System;
using System.Web;
using System.Web.UI;

using System.Collections.Specialized;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
int loop1;
NameValueCollection coll;
 
//Load Form variables into NameValueCollection variable.
coll=Request.Form;
// Get names of all forms into a string array.
String[] arr1 = coll.AllKeys;
for (loop1 = 0; loop1 < arr1.Length; loop1++) 
{
   Response.Write("Form: " + arr1[loop1] + "<br>");
}
   
// </Snippet1>
 }
}
