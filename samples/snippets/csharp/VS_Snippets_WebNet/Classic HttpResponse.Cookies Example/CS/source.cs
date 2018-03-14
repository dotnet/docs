using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
   private void Page_Load(Object sender, EventArgs e)
   {
// <Snippet1>
HttpCookie MyCookie = new HttpCookie("LastVisit");
DateTime now = DateTime.Now;

MyCookie.Value = now.ToString();
MyCookie.Expires = now.AddHours(1);

Response.Cookies.Add(MyCookie);
   
// </Snippet1>
 }
}
