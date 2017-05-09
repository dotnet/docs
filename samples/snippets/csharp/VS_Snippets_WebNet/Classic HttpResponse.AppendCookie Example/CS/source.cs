using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
HttpCookie MyCookie = new HttpCookie("LastVisit");
 MyCookie.Value = DateTime.Now.ToString();
 Response.AppendCookie(MyCookie);
    
// </Snippet1>
 }
}
