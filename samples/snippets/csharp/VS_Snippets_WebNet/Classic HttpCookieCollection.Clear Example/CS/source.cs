using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
HttpCookieCollection MyCookieCollection = new HttpCookieCollection();
// <Snippet1>
MyCookieCollection.Clear();
    
// </Snippet1>
 }
}
