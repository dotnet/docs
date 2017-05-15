using System;
using System.IO;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 protected string EncodedString;

 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
StringWriter writer = new StringWriter();
Server.UrlDecode(EncodedString, writer);
String DecodedString = writer.ToString();
   
// </Snippet1>
 }
}
