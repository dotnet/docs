using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
Response.Cache.SetETag("\"50f59e42f4d8bc1:cd7\"");
 
// </Snippet1>
 }
}
