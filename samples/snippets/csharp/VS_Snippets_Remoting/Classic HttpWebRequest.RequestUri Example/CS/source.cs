using System;
using System.Net;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");
// <Snippet1>
bool hasChanged = (req.RequestUri != req.Address);
 
// </Snippet1>
 }
}
