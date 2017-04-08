using System;
using System.Web;
using System.Web.UI;
using System.Web.Caching;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
 string Source="";

// <Snippet1>
CacheDependency dep = new CacheDependency(Server.MapPath("isbn.xml"));
Cache.Insert("ISBNData", Source, dep);
   
// </Snippet1>
 }
}
