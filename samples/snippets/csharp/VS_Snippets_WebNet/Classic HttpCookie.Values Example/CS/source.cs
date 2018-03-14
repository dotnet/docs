using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
HttpCookie MyCookie = new HttpCookie("Cookie1");
 MyCookie.Values["Val1"] = "1";
 MyCookie.Values["Val2"] = "2";
 MyCookie.Values["Val3"] = "3";
 Response.Cookies.Add(MyCookie);
    
// </Snippet1>
 }
}
