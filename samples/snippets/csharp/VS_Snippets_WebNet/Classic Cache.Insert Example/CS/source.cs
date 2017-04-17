using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
 String connectionString = "";
// <Snippet1>
Cache.Insert("DSN", connectionString);
   
// </Snippet1>
 }
}
