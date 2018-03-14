using System;
using System.Web;
using System.Web.UI;
using System.Web.Caching;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
Cache.Get("MyTextBox.Value");
   
// </Snippet1>
 }
}
