using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
int loop1, loop2;
HttpCookieCollection MyCookieColl;
HttpCookie MyCookie;
 
MyCookieColl = Request.Cookies;

// Capture all cookie names into a string array.
String[] arr1 = MyCookieColl.AllKeys;

// Grab individual cookie objects by cookie name.
for (loop1 = 0; loop1 < arr1.Length; loop1++) 
{
   MyCookie = MyCookieColl[arr1[loop1]];
   Response.Write("Cookie: " + MyCookie.Name + "<br>");
   Response.Write ("Secure:" + MyCookie.Secure + "<br>");
 
   //Grab all values for single cookie into an object array.
   String[] arr2 = MyCookie.Values.AllKeys;

   //Loop through cookie Value collection and print all values.
   for (loop2 = 0; loop2 < arr2.Length; loop2++) 
   {
      Response.Write("Value" + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
   }
}
   
// </Snippet1>
 }
}
