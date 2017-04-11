using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
int loop1;

 HttpCookieCollection MyCookieCollection = Response.Cookies;
 
 for(loop1 = 0; loop1 < MyCookieCollection.Count; loop1++)
 {
    if(MyCookieCollection.GetKey(loop1) == "LastVisit")
    {
       MyCookieCollection[loop1].Value = DateTime.Now.ToString();
       MyCookieCollection.Set(MyCookieCollection[loop1]);
    }
 }
    
// </Snippet1>
 }
}
