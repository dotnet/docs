using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
TimeSpan ts = new TimeSpan(0,30,0);
 Response.Cache.SetProxyMaxAge(ts);
 
// </Snippet1>
 }
}
