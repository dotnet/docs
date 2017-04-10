using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
 HttpCookieCollection MyCookieCollection = Response.Cookies;
// <Snippet1>
String CookieName = MyCookieCollection[0].Name;
    
// </Snippet1>
 }
}
