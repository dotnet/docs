using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
string[] arr1;
// <Snippet1>
int loop1;
HttpFileCollection Files;
 
Files = Request.Files; // Load File collection into HttpFileCollection variable.
arr1 = Files.AllKeys;  // This will get names of all files into a string array.
for (loop1 = 0; loop1 < arr1.Length; loop1++) 
{
    Response.Write("File: " + Server.HtmlEncode(arr1[loop1]) + "<br />");
    Response.Write("  size = " + Files[loop1].ContentLength + "<br />");
    Response.Write("  content type = " + Files[loop1].ContentType + "<br />");
}
   
// </Snippet1>
 }
}
