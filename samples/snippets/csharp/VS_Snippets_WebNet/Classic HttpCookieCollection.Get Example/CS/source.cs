using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
HttpCookieCollection MyCookieCollection = Request.Cookies;
 HttpCookie MyCookie = MyCookieCollection.Get("LastVisit");
 MyCookie.Value = DateTime.Now.ToString();
 MyCookieCollection.Set(MyCookie);
   
// </Snippet1>
 }
}
