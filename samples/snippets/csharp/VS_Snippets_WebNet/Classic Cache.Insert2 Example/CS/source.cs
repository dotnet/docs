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
Cache.Insert("DSN", connectionString, null, DateTime.Now.AddMinutes(2), Cache.NoSlidingExpiration);
// </Snippet1>
// <Snippet2>
Cache.Insert("DSN", connectionString, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10));
// </Snippet2>
    }
}
