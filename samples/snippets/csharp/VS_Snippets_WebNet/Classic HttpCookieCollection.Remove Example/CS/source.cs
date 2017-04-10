using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
protected string MyCookie;
 private void Page_Load(Object sender, EventArgs e)
 {
 HttpCookieCollection MyCookieCollection = Response.Cookies;
// <Snippet1>
MyCookieCollection.Remove(MyCookie);
    
// </Snippet1>
 }
}
