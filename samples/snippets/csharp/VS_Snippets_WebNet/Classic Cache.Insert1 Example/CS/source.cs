using System;
using System.Web;
using System.Web.UI;
using System.Web.Caching;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
 String connectionString = "";
// <Snippet1>
Cache.Insert("DSN", connectionString, new CacheDependency(Server.MapPath("myconfig.xml")));
   
// </Snippet1>
 }
}
