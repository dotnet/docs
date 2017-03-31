using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 protected HttpCookie MyCookie;
 private void Page_Load(Object sender, EventArgs e)
 {
 HttpCookieCollection MyCookieCollection = Response.Cookies;
// <Snippet1>
MyCookie.Value = DateTime.Now.ToString();
 MyCookieCollection.Set(MyCookie);
    
// </Snippet1>
 }
}
