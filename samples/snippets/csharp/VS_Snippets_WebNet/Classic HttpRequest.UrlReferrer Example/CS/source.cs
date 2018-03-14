using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
Uri MyUrl = Request.UrlReferrer;
 Response.Write("Referrer URL Port: " + Server.HtmlEncode(MyUrl.Port.ToString()) + "<br>");
 Response.Write("Referrer URL Protocol: " + Server.HtmlEncode(MyUrl.Scheme) + "<br>");
   
// </Snippet1>
 }
}
