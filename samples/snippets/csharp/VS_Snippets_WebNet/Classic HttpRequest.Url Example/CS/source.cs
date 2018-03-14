using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
Uri MyUrl = Request.Url;
 Response.Write("URL Port: " + MyUrl.Port + "<br>");
 Response.Write("URL Protocol: " + Server.HtmlEncode(MyUrl.Scheme) + "<br>");

// </Snippet1>
 }
}
