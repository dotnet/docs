using System;
using System.IO;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
String EncodedString = "This is a &ltTest String&gt.";
StringWriter writer = new StringWriter();
Server.HtmlDecode(EncodedString, writer);
String DecodedString = writer.ToString();
   
// </Snippet1>
 }
}
