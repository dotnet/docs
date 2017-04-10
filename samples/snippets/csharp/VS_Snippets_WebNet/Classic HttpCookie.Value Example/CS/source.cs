using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 protected HttpCookie MyCookie;

 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
MyCookie.Value = "abc123";
    
// </Snippet1>
 }
}
