using System;
using System.IO;
using System.Web;
using System.Web.UI;

public class Page1: Page
{
 private void Page_Load(Object sender, EventArgs e)
 {
// <Snippet1>
String TestString = "This is a <Test String>.";
StringWriter writer = new StringWriter();
Server.HtmlEncode(TestString, writer);
String EncodedString = writer.ToString();
   
// </Snippet1>
 }
}
