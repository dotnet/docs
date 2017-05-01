using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
int loop1;
 HttpCookie MyCookie;
 HttpCookieCollection MyCookieCollection;
 
 MyCookieCollection = Request.Cookies;
 
 for (loop1 = 0; loop1 < MyCookieCollection.Count; loop1++)
 {
    MyCookie = MyCookieCollection[loop1];
    if (MyCookie.Name == "UserName")
    {
       //...
    }
 }
    
// </Snippet1>
 }
}
