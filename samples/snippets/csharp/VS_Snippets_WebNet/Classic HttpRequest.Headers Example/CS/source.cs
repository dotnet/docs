using System;
using System.Web;
using System.Web.UI;
using System.Collections.Specialized;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
int loop1, loop2;
NameValueCollection coll;
 
// Load Header collection into NameValueCollection object.
coll=Request.Headers;

// Put the names of all keys into a string array.
String[] arr1 = coll.AllKeys; 
for (loop1 = 0; loop1<arr1.Length; loop1++) 
{
   Response.Write("Key: " + arr1[loop1] + "<br>");
   // Get all values under this key.
   String[] arr2=coll.GetValues(arr1[loop1]);
   for (loop2 = 0; loop2<arr2.Length; loop2++) 
   {
      Response.Write("Value " + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
   }
}
   
// </Snippet1>
 }
}
