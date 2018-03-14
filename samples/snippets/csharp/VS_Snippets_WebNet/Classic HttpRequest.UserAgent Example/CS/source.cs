using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
String userAgent;
userAgent = Request.UserAgent;
if (userAgent.IndexOf("MSIE 6.0") > -1) 
{
   // The browser is Microsoft Internet Explorer Version 6.0.
}
   
// </Snippet1>
 }
}
