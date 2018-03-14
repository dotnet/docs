using System;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 protected HttpCookie MyCookie;

 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
DateTime dt = DateTime.Now;
 TimeSpan ts = new TimeSpan(0,0,10,0);
 
 MyCookie.Expires = dt.Add(ts);
    
// </Snippet1>
 }
}
