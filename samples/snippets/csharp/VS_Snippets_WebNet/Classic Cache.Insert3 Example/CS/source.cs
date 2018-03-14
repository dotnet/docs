using System;
using System.Web;
using System.Web.UI;
using System.Web.Caching;

public class Page1: Page
{
protected  CacheItemRemovedCallback onRemove;
 
 private void Page_Load(Object sender, EventArgs e)
 {
 String connectionString = "";
// <Snippet1>
Cache.Insert("DSN", connectionString, null, DateTime.Now.AddMinutes(2), TimeSpan.Zero, CacheItemPriority.High, onRemove);
   
// </Snippet1>
 }
}
