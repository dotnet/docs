using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
   Response.Cache.SetExpires(DateTime.Now.AddSeconds(60));
   Response.Cache.SetCacheability(HttpCacheability.Public);
   Response.Cache.SetValidUntilExpires(false);
   Response.Cache.VaryByParams["Category"] = true;

   if (Response.Cache.VaryByParams["Category"])
   {
      //...
   }
// </Snippet1>
 }
}
