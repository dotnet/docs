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
 HttpCookieCollection MyCookieCollection = Response.Cookies;
 
 for(loop1 = 0; loop1 < MyCookieCollection.Count; loop1++)
 {
    MyCookie = MyCookieCollection.Get(loop1);
    if(MyCookie.Value == "LastVisit")
    {
       MyCookie.Value = DateTime.Now.ToString();
       MyCookieCollection.Set(MyCookie);
    }
 }
   
// </Snippet1>
 }
}
